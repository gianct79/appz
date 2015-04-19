/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Linq;
using System.Web.UI.WebControls;
using Com.Gt.SomSc.Common.Crypto;
using Com.Gt.SomSc.Domain.Entities;
using NLog;


namespace Com.Gt.SomSc.WebApp.Controls
{
    public partial class UsuarioGrid : System.Web.UI.UserControl
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UsuariosListView_ItemUpdating(object sender, System.Web.UI.WebControls.ListViewUpdateEventArgs e)
        {
            e.NewValues["Senha"] = HashingUtils.Hash((string)e.NewValues["SenhaPlain"]);
        }

        protected void UsuariosListView_ItemInserting(object sender, System.Web.UI.WebControls.ListViewInsertEventArgs e)
        {
            e.Values["Senha"] = HashingUtils.Hash((string)e.Values["SenhaPlain"]);
        }

        protected void UsuariosListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
                UsuariosListView.InsertItemPosition = InsertItemPosition.None;
            else
                UsuariosListView.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void UsuariosLinqData_Deleting(object sender, LinqDataSourceDeleteEventArgs e)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                if (context.Usuarios.Count() <= 1)
                {
                    logger.Error("Potencial exclusão de TODOS os usuários encontrada. Abortando!");
                    e.Cancel = true;
                }
            }
        }
    }
}
