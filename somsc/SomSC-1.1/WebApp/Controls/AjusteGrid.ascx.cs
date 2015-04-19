/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Web.UI.WebControls;
using Com.Gt.SomSc.Domain.Entities;

namespace Com.Gt.SomSc.WebApp.Controls
{
    public partial class AjusteGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataFilterTextBox.Text = DateTime.Now.ToShortDateString();
            }
        }

        protected void AjustesListView_ItemInserting(object sender, System.Web.UI.WebControls.ListViewInsertEventArgs e)
        {
            Usuario usuario = (Usuario)Session["User"];
            e.Values["IdUsuario"] = usuario.Id;
        }

        protected void AjustesListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
                AjustesListView.InsertItemPosition = InsertItemPosition.None;
            else
                AjustesListView.InsertItemPosition = InsertItemPosition.FirstItem;
        }

        protected void AjustesListView_DataBound(object sender, EventArgs e)
        {
            TextBox data = AjustesListView.InsertItem.FindControl("DataTextBox") as TextBox;
            data.Text = DateTime.Now.ToShortDateString();

            SetFocus();
        }

        protected void AjustesLinqData_Load(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            AjustesLinqData.Where = string.Empty;
            AjustesLinqData.WhereParameters.Clear();

            if (!string.IsNullOrEmpty(DataFilterTextBox.Text))
            {
                AjustesLinqData.Where = "Data = @data";
                AjustesLinqData.WhereParameters.Add("data", System.Data.DbType.DateTime, DataFilterTextBox.Text);
            }

            if (!string.IsNullOrEmpty(ProdutoFilterComboBox.DataBindID))
            {
                if (AjustesLinqData.WhereParameters.Count > 0)
                    AjustesLinqData.Where += " And ";

                AjustesLinqData.Where += "IdProduto = @idProduto";
                AjustesLinqData.WhereParameters.Add("idProduto", System.Data.DbType.Int32, ProdutoFilterComboBox.DataBindID);
            }

            if (!string.IsNullOrEmpty(FilialFilterComboBox.DataBindID))
            {
                if (AjustesLinqData.WhereParameters.Count > 0)
                    AjustesLinqData.Where += " And ";

                AjustesLinqData.Where += "IdFilial = @idFilial";
                AjustesLinqData.WhereParameters.Add("idFilial", System.Data.DbType.Int32, FilialFilterComboBox.DataBindID);
            }

            if (!string.IsNullOrEmpty(UsuarioFilterComboBox.DataBindID))
            {
                if (AjustesLinqData.WhereParameters.Count > 0)
                    AjustesLinqData.Where += " And ";

                AjustesLinqData.Where += "IdUsuario = @idUsuario";
                AjustesLinqData.WhereParameters.Add("idUsuario", System.Data.DbType.Int32, UsuarioFilterComboBox.DataBindID);
            }
        }

        private void SetFocus()
        {
            ListViewItem item = AjustesListView.EditItem ?? AjustesListView.InsertItem;

            if (item != null)
            {
                ComboBox produto = item.FindControl("ProdutoComboBox") as ComboBox;

                if (produto != null)
                {
                    produto.Focus();
                }
            }
        }
    }
}