using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week5_InterstellarTravel
{
    public partial class Interstellar : System.Web.UI.MasterPage
    {

        public string Subblurb{set{
                subblurbLabel.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}