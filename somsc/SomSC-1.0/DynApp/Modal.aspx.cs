using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Gt.SomSc.Domain.Entities;
using System.Web.Services;

namespace Com.Gt.SomSc.DynApp
{
    public partial class Modal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                lstProdutos.DataSource = context.Produtos;
                lstProdutos.DataBind();

                cbxProdutos.DataSource = context.Produtos;
                cbxProdutos.DataBind();

                cbxxProdutos.DataSource = context.Produtos;
                cbxxProdutos.DataBind();
            }

        }
    }
}
