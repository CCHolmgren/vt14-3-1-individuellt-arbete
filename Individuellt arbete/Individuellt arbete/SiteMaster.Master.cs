﻿using Individuellt_arbete.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individuellt_arbete
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //TODO: Remove this. It's only for debugging.
            if (Session["currentuser"] == null)
                Session["currentuser"] = 1;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}