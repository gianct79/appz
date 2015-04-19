/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Web.Security;
using Com.Gt.SomSc.Domain.Entities;
using NLog;

namespace Com.Gt.SomSc.WebApp
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SairButton_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["User"];
            logger.Info("Usuário \"{0}\" saindo...", usuario.Apelido);

            FormsAuthentication.SignOut();
            Session.RemoveAll();

            Response.Redirect("~/Login.aspx");
        }
    }
}
