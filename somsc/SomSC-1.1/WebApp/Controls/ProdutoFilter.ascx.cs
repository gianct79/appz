/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Reflection;
using System.Web.UI.WebControls;

namespace Com.Gt.SomSc.WebApp.Controls
{
    public partial class ProdutoFilter : System.Web.UI.UserControl
    {
        public string CategoriaId
        {
            get
            {
                return (CategoriaFilterComboBox != null) ? CategoriaFilterComboBox.SelectedValue : String.Empty;
            }
        }

        public string ProdutoId
        {
            get
            {
                return (ProdutoFilterComboBox != null) ? ProdutoFilterComboBox.SelectedValue : String.Empty;
            }
        }
    }
}
