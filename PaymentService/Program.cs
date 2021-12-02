
using PaymentService.Entities;
using PaymentService.Services;
using System.Globalization;

Console.WriteLine("Enter contract data: ");
Console.Write("Number: ");
int number = int.Parse(Console.ReadLine());

Console.Write("Date (dd/MM/yyyy): ");
DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

Console.Write("Contract value: ");

double value = double.Parse(Console.ReadLine());

Console.Write("Enter number of installments: ");
int instMonths = int.Parse(Console.ReadLine());

Contract contract = new Contract(number, date, value);

ContractService contractService = new ContractService(new PaypalService());
contractService.ProcessContract(contract, instMonths);

Console.WriteLine("Installments: ");
foreach (Installment installment in contract.Installments)
{
    Console.WriteLine(installment);
}





