using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Week8_InterstellarTravel.Models;

namespace Week8_InterstellarTravel
{
    public partial class Thanks : System.Web.UI.Page
    {
        const string THANKS_FORMAT = "Thanks for your enquiry {0}, we will be in contact with you soon at {1} about your desire to travel on {2}";

        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerQuery query = (CustomerQuery)Session[CustomerQuery.SESSION_KEY];
            if (query != null)
            {
                thanksMessageLabel.Text = String.Format(THANKS_FORMAT, query.Name, query.Email, query.Date.ToShortDateString());
            }
        }
    }
}