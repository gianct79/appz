/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Linq;
using System.Web.UI.WebControls;
using Com.Gt.SomSc.Domain.Entities;
using System.Collections.Generic;

namespace Com.Gt.SomSc.WebApp.Controls
{
    public partial class MovimentoGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                int idProduto = Convert.ToInt32(ProdutoFilterComboBox.DataBindID);

                int idFilial = 0;
                if (!string.IsNullOrEmpty(FilialFilterComboBox.DataBindID))
                {
                    idFilial = Convert.ToInt32(FilialFilterComboBox.DataBindID);
                }

                MovimentosListView.DataSource = context.GetMovimentosByProdutoAndFilial(idProduto, idFilial);
                MovimentosListView.DataBind();
            }
        }
    }
}