using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PaymentSystem.BusinessLayer;
namespace PaymentSystem.UserLayer
{
    public partial class Thankyou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var paymentObj = Session["ActivePayment"];
            if (paymentObj!=null)
            {
                var paymentAction = (PaymentAction)paymentObj;
                var result = paymentAction.GetResult();
                // deal with the result here
                ResultLabel.Text = result.TransactionResult.ToString() + ": recieptId" + result.ReceiptId.ToString();
            }
        }
    }
}