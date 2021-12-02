using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Services
{
    internal interface IOnlinePaymentService
    {

        public abstract double Interest(double amount, int months);

        public abstract double PaymentFee(double amount);



    
    }
}
