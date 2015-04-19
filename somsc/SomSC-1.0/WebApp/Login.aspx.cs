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

namespace Com.Gt.SomSc.WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {
            SiteLogin.Focus();
        }

        protected bool Authenticate(string username, string password)
        {
            using (SomScDataContext context = new SomScDataContext())
            {
                Usuario usuario = context.Usuarios.SingleOrDefault(u => u.Apelido.Equals(username));

                if (usuario == null)
                {
                    return false;
                }

                if (!usuario.Senha.Equals(HashingUtils.Hash(password)))
                {
                    return false;
                }

                Session["User"] = usuario;
                logger.Info("Usuário \"{0}\" entrando...", usuario.Apelido);
            }

            return true;
        }

        protected void SiteLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated = Authenticate(SiteLogin.UserName, SiteLogin.Password);
        }
    }
}
