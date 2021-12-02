using PaymentService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Services
{
    internal class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {

            double basicInstallment = contract.TotalValue / months;


            for (int i = 1; i <= months; i++)
            {
                DateTime dueDate = contract.Date.AddMonths(i);

                double instFee = _onlinePaymentService.PaymentFee(basicInstallment);
                double totalInst = _onlinePaymentService.Interest(instFee, i);

                contract.AddInstallment(new Installment(dueDate, totalInst));


            }
        }
    }
}
