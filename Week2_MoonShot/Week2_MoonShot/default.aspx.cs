using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week2_MoonShot
{
    public partial class _default : System.Web.UI.Page
    {
        // a list of possible destinations - for the moment hardcoded, but we could add to a db
        Dictionary<string, float> destinations = new Dictionary<string, float>() {
            { "Sydney", 150 },
            { "Perth", 4000 },
            { "London", 17000 },
            { "Moon", 384400 },
            { "Titan", 1400000000 }
        };

        // a list of possible speeds - for the moment hardcoded, but we could add to a db
        Dictionary<string, float> speeds = new Dictionary<string, float>() {
            { "Walking speed", 5 },
            { "Driving speed", 100 },
            { "Flying speed", 933 },
            { "Rocket speed", 40000 },
            { "0.8 Light speed", 863402279 }
        };

        public Dictionary<string, float> Destinations { get { return destinations; } }
        public Dictionary<string, float> Speeds { get { return speeds; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (var speed in speeds)
                {
                    SpeedDdl.Items.Add(new ListItem(speed.Key, speed.Value.ToString()));
                }
                foreach (var destination in destinations)
                {
                    DestinationDdl.Items.Add(new ListItem(destination.Key, destination.Value.ToString()));
                }
            }
        }

        protected void CalculateButton_Click(object sender, EventArgs e)
        {
            float speed = 0;
            float distance = 0;

            // attempt to parse result - should always succeed
            if (float.TryParse(SpeedDdl.SelectedValue, out speed) && float.TryParse(DestinationDdl.SelectedValue, out distance))
            {
                float timeInHours = distance / speed;
                ResultLabel.Text = "Expected time to get to " + DestinationDdl.SelectedItem + " is:" + timeInHours.ToString("N") + " Hours (" + (timeInHours / 8760).ToString("N") + " years)";
            }
            else
            {
                // the previous should always succeed, otherwise something has gone wrong
                System.Diagnostics.Debug.Assert(false);
            }
        }
    }
}