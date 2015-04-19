/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Linq;
using System.Web.UI.WebControls;
using Com.Gt.SomSc.Domain.Entities;
using System.Collections.Generic;

namespace Com.Gt.SomSc.WebApp.Controls
{
    public partial class SaldoGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SaldosObjectData_ObjectDisposing(object sender, ObjectDataSourceDisposingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
