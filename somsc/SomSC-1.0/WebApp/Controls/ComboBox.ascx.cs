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
    public partial class ComboBox : System.Web.UI.UserControl
    {
        public string DataSourceTypeName;
        public string DataSourceMethod;
        public string DataTextField;
        public string DataValueField;

        public string Width;
        public string OnClientChange;

        public bool Enabled = true;
        public bool ShowAll = false;
        public bool AutoPostBack = false;

        public string DataBindID
        {
            get
            {
                return (DropDown != null) ? DropDown.SelectedValue : String.Empty;
            }

            set
            {
                if (DropDown != null && DropDown.Items.Count > 0 &&
                    DropDown.Items.FindByValue(value) != null)
                {
                    DropDown.SelectedValue = value;
                }
            }
        }

        public override string ClientID
        {
            get { return DropDown.ClientID; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DropDown.Width = new Unit(Width);
            DropDown.Enabled = Enabled;
            DropDown.AutoPostBack = AutoPostBack;
        }

        protected void DropDown_Init(object sender, EventArgs e)
        {
            if (DropDown == null)
                return;

            if (!string.IsNullOrEmpty(this.OnClientChange))
                DropDown.Attributes["onchange"] = this.OnClientChange;

            Assembly assembly = null;
            foreach (AssemblyName assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                if (DataSourceTypeName.Contains(assemblyName.Name))
                {
                    assembly = Assembly.Load(assemblyName);
                    break;
                }
            }

            if (assembly == null)
                return;

            Type dsType = assembly.GetType(DataSourceTypeName);
            if (dsType == null)
                return;

            using (IDisposable o = (IDisposable)Activator.CreateInstance(dsType))
            {
                MethodInfo dsMethod = dsType.GetMethod(DataSourceMethod);
                if (dsMethod == null)
                    return;

                DropDown.DataTextField = this.DataTextField;
                DropDown.DataValueField = this.DataValueField;
                DropDown.DataSource = dsMethod.Invoke(o, null);
                DropDown.DataBind();

                if (ShowAll)
                {
                    DropDown.Items.Insert(0, new ListItem { Text = "-- Todos --", Value = "" });
                }
            }
        }
    }
}
