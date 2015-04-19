/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Com.Gt.SomSc.WebApp.Controls
{
    [DefaultProperty("Password")]
    [ToolboxData("<{0}:PasswordTextBox runat=server></{0}:PasswordTextBox>")]
    [ViewStateModeById]
    public class PasswordTextBox : TextBox
    {
        private static readonly string FakePass = " pass ";

        public PasswordTextBox()
        {
            TextMode = TextBoxMode.Password;
        }

        [Bindable(false)]
        [DefaultValue("")]
        public virtual string Password
        {
            get
            {
                string s = (string)ViewState["pass"];
                return (s == null) ? string.Empty : s;
            }
            set
            {
                ViewState["pass"] = value;
            }
        }

        public override string Text
        {
            get
            {
                if (base.Text.Equals(FakePass))
                    return this.Password;
                else
                    return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!string.IsNullOrEmpty(this.Password) && !string.IsNullOrEmpty(this.Text))
                Attributes["value"] = FakePass;
        }
    }
}
