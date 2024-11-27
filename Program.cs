using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using ServicesLab1.Models;
using ServicesLab1.Repositories;
using ServicesLab1.Services;
using System;

namespace ServicesLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = ConfigureServices();
            using var scope = serviceProvider.CreateScope();

            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

            var bankAccountService = scope.ServiceProvider.GetRequiredService<IBankAccountService>();

            var bankingService = scope.ServiceProvider.GetRequiredService<BankServices>();

            User client = new User();

            Console.WriteLine("Enter User Name:");
            client.Name = Console.ReadLine();

            Console.WriteLine("Enter User Email:");
            client.Email = Console.ReadLine();

            userService.AddUser(client);

            Console.WriteLine("Enter User ID to Search:");
            int userId = int.Parse(Console.ReadLine());

            var user = userService.GetUserById(userId);
            Console.WriteLine($"User: {user.Name}, Email: {user.Email}");

            Console.Write("Enter a new account number: ");

            string accountNumber = Console.ReadLine();

            bankAccountService.AddAccount(new BankAccount
            {
                AccountNumber = accountNumber,
                Balance = 0,
                UserId = user.Id
            });

            Console.Write("Enter deposit amount: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine(bankingService.Deposit(1, depositAmount));

            Console.Write("Enter withdrawal amount: ");

            decimal withdrawAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine(bankingService.Withdraw(1, withdrawAmount));

            Console.Write("Enter recipient account ID for transfer: ");

            int recipientAccountId = int.Parse(Console.ReadLine());

            Console.Write("Enter transfer amount: ");

            decimal transferAmount = decimal.Parse(Console.ReadLine());



            Console.WriteLine(bankingService.ExecuteTransfer(1, recipientAccountId, transferAmount));
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IBankAccountRepository, BankAccountRepository>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IBankAccountService, BankAccountService>();

            services.AddScoped<BankServices>();

            return services.BuildServiceProvider();
        }




    }

    
}
