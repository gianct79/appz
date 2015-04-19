/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

namespace Com.Gt.SomSc.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Dynamic;
    using Com.Gt.SomSc.Common.Log;

    public class Saldo
    {
        public Filial Filial { get; set; }
        public Produto Produto { get; set; }
        public double? Qtde { get; set; }
    }

    partial class Movimento
    {
        public double Saldo { get; internal set; }
    }

    partial class Usuario
    {
        public string SenhaPlain { get; set; }
    }

    partial class Produto
    {
        public double Saldo
        {
            get { return Movimentos.Sum(m => m.Quantidade); }
        }

        public string CategoriaDescricao
        {
            get { return string.Concat(Categoria.Descricao, " - ", Descricao); }
        }
    }

    partial class SomScDataContext
    {
        public SomScDataContext()
            : base(ConfigurationManager.ConnectionStrings["SomSc"].ConnectionString)
        {
            Log = new LinqLogger();
        }

        public IList<Movimento> GetMovimentosByProdutoAndFilial(int IdProduto, int IdFilial)
        {
            var query = Movimentos.Where(m => m.IdProduto == IdProduto);

            if (IdFilial != 0)
            {
                query = query.Where(m => m.IdFilial == IdFilial);
            }

            query = query.OrderBy(m => m.Data).ThenBy(m => m.Id);

            IList<Movimento> movimentos = query.ToList();

            double saldo = 0.0;
            foreach (Movimento movimento in movimentos)
            {
                saldo += movimento.Quantidade;
                movimento.Saldo = saldo;
            }

            return movimentos;
        }

        public IList<Saldo> GetSaldos(int IdCategoria, int IdProduto, int IdFilial, string Sort)
        {
            var query = Filiais
                .SelectMany(p => Produtos, (f, p) =>
                    new Saldo { Filial = f, Produto = p, Qtde = f.Movimentos.Where(m => m.IdProduto == p.Id).Any() ? f.Movimentos.Where(m => m.IdProduto == p.Id).Sum(m => m.Quantidade) : 0.0 });

            if (IdCategoria != 0)
            {
                query = query.Where(p => p.Produto.Categoria.Id == IdCategoria);
            }

            if (IdProduto != 0)
            {
                query = query.Where(p => p.Produto.Id == IdProduto);
            }

            if (IdFilial != 0)
            {
                query = query.Where(f => f.Filial.Id == IdFilial);
            }

            if (string.IsNullOrEmpty(Sort))
            {
                query = query.OrderBy(f => f.Filial.Nome).ThenBy(p => p.Produto.Descricao);
            }
            else
            {
                query = query.OrderBy(Sort);
            }

            return query.ToList();
        }

        public IList<Saldo> GetCriticos(int IdCategoria, int IdFornecedor, string Sort)
        {
            var query = Produtos
                .Select(p => new Saldo { Produto = p, Qtde = p.Movimentos.Any() ? p.Movimentos.Sum(m => m.Quantidade) : 0.0 })
                .Where(p => p.Qtde <= p.Produto.Critico);

            if (IdCategoria != 0)
            {
                query = query.Where(p => p.Produto.Categoria.Id == IdCategoria);
            }

            if (IdFornecedor != 0)
            {
                query = query.Where(p => p.Produto.Fornecedor.Id == IdFornecedor);
            }

            if (string.IsNullOrEmpty(Sort))
            {
                query = query.OrderBy(p => p.Qtde);
            }
            else
            {
                query = query.OrderBy(Sort);
            }

            return query.ToList();
        }

        public IList<Produto> GetProdutosByDescricao()
        {
            IList<Produto> produtos = Produtos.ToList();

            return produtos.OrderBy(p => p.CategoriaDescricao).ToList();
        }

        public IList<Filial> GetFiliaisByNome()
        {
            return Filiais.OrderBy(f => f.Nome).ToList();
        }

        public IList<Usuario> GetUsuariosByNome()
        {
            return Usuarios.OrderBy(u => u.Nome).ToList();
        }

        public IList<Categoria> GetCategoriasByDescricao()
        {
            return Categorias.OrderBy(c => c.Descricao).ToList();
        }

        public IList<Fornecedor> GetFornecedoresByRazao()
        {
            return Fornecedores.OrderBy(f => f.RazaoSocial).ToList();
        }

        public IList<Unidade> GetUnidadesByDescricao()
        {
            return Unidades.OrderBy(u => u.Descricao).ToList();
        }
    }
}
