using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week5_InterstellarTravel
{
    public partial class RegisterInterest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dateToGoCompareValidator.ValueToCompare = DateTime.Today.ToShortDateString();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Models.CustomerQuery query = new Models.CustomerQuery();
                DateTime date;
                if (DateTime.TryParse(dateToGoText.Text, out date))
                {
                    query.Date = date;
                    query.Name = nameText.Text;
                    query.Email = email1Text.Text;

                    Session["customerQuery"] = query;
                    Response.Redirect("Thanks.aspx");
                }

            }
        }
    }
}