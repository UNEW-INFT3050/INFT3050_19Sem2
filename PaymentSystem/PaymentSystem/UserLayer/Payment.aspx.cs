using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PaymentSystem.BusinessLayer;
using INFT3050.PaymentSystem;
namespace PaymentSystem.UserLayer
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void PaymentButton_Click(object sender, EventArgs e)
        {
            PaymentRequest paymentRequest = new PaymentRequest();
            decimal amount;
            decimal.TryParse(AmountText.Text, out amount);
            int cvc;
            int.TryParse(CVCText.Text, out cvc);
            paymentRequest.Amount = amount;
            paymentRequest.CardName = NameText.Text;
            paymentRequest.CardNumber = NumberText.Text;
            paymentRequest.CVC = cvc;
            paymentRequest.Description = "Test payment";
            paymentRequest.Expiry = DateTime.Parse(ExpiryText.Text);
            PaymentAction payment = new PaymentAction(paymentRequest);
            payment.StartPayment();
            Session["ActivePayment"] = payment;
            Response.Redirect("Thankyou.aspx");
        }
    }
}