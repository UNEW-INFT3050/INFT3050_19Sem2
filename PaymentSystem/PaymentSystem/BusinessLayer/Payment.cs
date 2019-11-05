using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050.PaymentSystem;
using System.Threading.Tasks;

namespace PaymentSystem.BusinessLayer
{
    public class PaymentAction
    {
        public PaymentAction(PaymentRequest request) {
            Request = request;
        }

        public void StartPayment()
        {
            IPaymentSystem paymentSystem = INFT3050PaymentFactory.Create();
            ActivePayment = paymentSystem.MakePayment(Request);
        }

        // will block until complete
        public PaymentResult GetResult()
        {
            return ActivePayment.Result;
        }
        private PaymentRequest Request { get; set; }
        private Task<PaymentResult> ActivePayment { get; set; }
    }
}