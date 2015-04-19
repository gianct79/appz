/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Web.UI.WebControls;

namespace Com.Gt.SomSc.WebApp.Controls
{
    public partial class ProdutoGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ProdutosLinqData_Load(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        protected void ApplyFilter()
        {
            ProdutosLinqData.Where = string.Empty;
            ProdutosLinqData.WhereParameters.Clear();

            if (!string.IsNullOrEmpty(CategoriaFilterComboBox.DataBindID))
            {
                ProdutosLinqData.Where = "IdCategoria = @idCategoria";
                ProdutosLinqData.WhereParameters.Add("idCategoria", System.Data.DbType.Int32, CategoriaFilterComboBox.DataBindID);
            }

            if (!string.IsNullOrEmpty(FornecedorFilterComboBox.DataBindID))
            {
                if (ProdutosLinqData.WhereParameters.Count > 0)
                    ProdutosLinqData.Where += " And ";

                ProdutosLinqData.Where += "IdFornecedor = @idFornecedor";
                ProdutosLinqData.WhereParameters.Add("idFornecedor", System.Data.DbType.Int32, FornecedorFilterComboBox.DataBindID);
            }

            if (!string.IsNullOrEmpty(DescricaoFilterTextBox.Text))
            {
                if (ProdutosLinqData.WhereParameters.Count > 0)
                    ProdutosLinqData.Where += " And ";

                ProdutosLinqData.Where += "Descricao.Contains(@descricao)";
                ProdutosLinqData.WhereParameters.Add("descricao", System.Data.DbType.String, DescricaoFilterTextBox.Text);
            }
        }

        protected void ProdutosListView_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
                ProdutosListView.InsertItemPosition = InsertItemPosition.None;
            else
                ProdutosListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ProdutosListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {

        }

        protected void ProdutosListView_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

        }
    }
}