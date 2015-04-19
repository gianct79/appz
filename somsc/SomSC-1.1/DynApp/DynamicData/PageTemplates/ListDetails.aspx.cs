﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;

namespace Com.Gt.SomSc.DynApp
{
    public partial class ListDetails : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            DynamicDataManager1.RegisterControl(GridView1, true /*setSelectionFromUrl*/);
            DynamicDataManager1.RegisterControl(DetailsView1);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MetaTable table = GridDataSource.GetTable();
            Title = table.DisplayName;



            // Disable various options if the table is readonly
            if (table.IsReadOnly)
            {
                DetailsPanel.Visible = false;
                GridView1.AutoGenerateSelectButton = false;
                GridView1.AutoGenerateEditButton = false;
                GridView1.AutoGenerateDeleteButton = false;
            }
        }
        protected void OnGridViewDataBound(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                DetailsView1.ChangeMode(DetailsViewMode.Insert);
            }
        }
        protected void OnFilterSelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.PageIndex = 0;
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        }
        protected void OnGridViewRowEditing(object sender, EventArgs e)
        {
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        }
        protected void OnGridViewSelectedIndexChanging(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        }

        protected void OnGridViewRowCreated(object sender, GridViewRowEventArgs e)
        {
            SetDeleteConfirmation(e.Row);
        }

        protected void OnGridViewRowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            DetailsView1.DataBind();
        }

        protected void OnGridViewRowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            DetailsView1.DataBind();
        }

        protected void OnDetailsViewItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void OnDetailsViewItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void OnDetailsViewItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void OnDetailsViewModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.NewMode != DetailsViewMode.ReadOnly)
            {
                GridView1.EditIndex = -1;
            }
        }

        protected void OnDetailsViewPreRender(object sender, EventArgs e)
        {
            int rowCount = DetailsView1.Rows.Count;
            if (rowCount > 0)
            {
                SetDeleteConfirmation(DetailsView1.Rows[rowCount - 1]);
            }
        }

        private void SetDeleteConfirmation(TableRow row)
        {
            foreach (Control c in row.Cells[0].Controls)
            {
                if (c is LinkButton)
                {
                    LinkButton btn = (LinkButton)c;
                    if (btn.CommandName == DataControlCommands.DeleteCommandName)
                    {
                        btn.OnClientClick = "return confirm('Are you sure you want to delete this item?');";
                    }
                }
            }
        }
    }
}
