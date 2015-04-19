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

        public IList<Movimento> GetMovimentosByProduto(int IdProduto)
        {
            return GetMovimentosByProdutoAndFilial(IdProduto, 0);
        }

        public IList<Movimento> GetMovimentosByProdutoAndFilial(int IdProduto, int IdFilial)
        {
            IList<Movimento> movimentos = Movimentos
                    .Where(m => m.IdProduto == IdProduto)
                    .OrderBy(m => m.Data)
                    .ThenBy(m => m.Id).ToList();

            if (IdFilial != 0)
            {
                movimentos = movimentos.Where(m => m.IdFilial == IdFilial).ToList();
            }

            double saldo = 0.0;
            foreach (Movimento movimento in movimentos)
            {
                saldo += movimento.Quantidade;
                movimento.Saldo = saldo;
            }

            return movimentos;
        }

        public IList<Saldo> GetSaldos()
        {
            IList<Saldo> saldos = Filiais
                .SelectMany(p => Produtos, (f, p) =>
                    new Saldo { Filial = f, Produto = p, Qtde = f.Movimentos.Where(m => m.IdProduto == p.Id).Any() ? f.Movimentos.Where(m => m.IdProduto == p.Id).Sum(m => m.Quantidade) : 0.0 })
                .OrderBy(f => f.Filial.Nome)
                .OrderBy(p => p.Produto.Codigo).ToList();

            return saldos;
        }

        public IList<Saldo> GetCriticos(int IdCategoria, int IdFornecedor)
        {
            IList<Saldo> criticos = Produtos
                .Select(p => new Saldo { Produto = p, Qtde = p.Movimentos.Any() ? p.Movimentos.Sum(m => m.Quantidade) : 0.0 })
                .Where(p => p.Qtde <= p.Produto.Critico)
                .OrderBy(p => p.Produto.Codigo).ToList();

            if (IdCategoria != 0)
            {
                criticos = criticos.Where(p => p.Produto.Categoria.Id == IdCategoria).ToList();
            }

            if (IdFornecedor != 0)
            {
                criticos = criticos.Where(p => p.Produto.Fornecedor.Id == IdFornecedor).ToList();
            }

            return criticos;
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
