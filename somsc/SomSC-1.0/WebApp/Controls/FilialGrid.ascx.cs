/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Web.UI.WebControls;

namespace Com.Gt.SomSc.WebApp.Controls
{
    public partial class FilialGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FiliaisListView_ItemCommand(object sender, System.Web.UI.WebControls.ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
                FiliaisListView.InsertItemPosition = InsertItemPosition.None;
            else
                FiliaisListView.InsertItemPosition = InsertItemPosition.LastItem;
        }
    }
}