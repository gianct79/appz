using System;
using System.Linq;
using Com.Gt.SomSc.Domain.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Collections;
using System.Collections.Generic;

namespace Com.Gt.SomSc.DynApp
{
    public partial class Saldo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                Produto produto = context.Produtos.Skip(1).First();

                Response.Write(produto.SaldoString);
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                Usuario usuario = context.Usuarios.First();

                usuario.Senha = "pass";

                context.SubmitChanges();
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                IEnumerable<Movimento> movimentos = context.GetMovimentosByProduto(2);

                ListView1.DataSource = movimentos;
                ListView1.DataBind();
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                IEnumerable<Com.Gt.SomSc.Domain.Entities.Saldo> saldos = context.GetSaldos();

                DataList1.DataSource = saldos;
                DataList1.DataBind();
            }
        }
    }
}
