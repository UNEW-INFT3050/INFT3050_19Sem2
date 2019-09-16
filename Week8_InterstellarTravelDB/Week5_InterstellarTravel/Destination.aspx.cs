using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week8_InterstellarTravel
{
    public partial class Destination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get id from query string and try to parse
            var idString = Request.QueryString["id"];
            int id;
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out id))
            {
                // using dummy database
                DAL.IDestinationsDataAccess db = new DAL.DummyDb();

                if (!IsPostBack)
                {
                    // get a destination from our db
                    var destination = db.GetDestinationById(id);
                    if (destination != null)
                    {
                        // set up page elements
                        descriptionLabel.Text = destination.LongDescription;
                        destinationImg.ImageUrl = destination.ImagePath;
                        nameLabel.Text = destination.Name;
                    }
                }
            }
        }
    }
}