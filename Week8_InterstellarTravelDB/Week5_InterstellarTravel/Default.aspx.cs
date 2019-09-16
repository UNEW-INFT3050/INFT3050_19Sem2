using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week8_InterstellarTravel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var db = new DAL.DestinationsDataAccess();
                var destinations = db.GetDestinations();

                ImageRepeater.DataSource = destinations;
                ImageRepeater.DataBind();
            }
        }

        protected void img1_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Destination.aspx?id=" + e.CommandArgument);
        }
    }

   
}