﻿namespace TRPZ.Commons
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using HumanResourcesDepartment.WPF.Comands;
    using TRPZ.Models;
    using TRPZ.ViewModels;

    public class LoginCommand : AsyncCommandBase
    {
        readonly LoginViewModel loginViewModel;
        readonly DatebaseAppContext db;
        readonly LoginWindow lw;
        public static string transferLogin;

        public LoginCommand(LoginViewModel loginViewModel, DatebaseAppContext db, LoginWindow lw)
        {
            this.loginViewModel = loginViewModel;
            this.db = db;
            this.lw = lw;
        }

        public async override Task ExecuteAsync(object parameter)

        {
            bool invalidData = false;
            List<Customer> customers = db.Customers.ToList();
            var inputLogin = loginViewModel.Login.Trim();
            var inputPassword = loginViewModel.Password.Trim();

            // Ultra very bad validation
            foreach (Customer customer in customers)
            {
                if (customer.login == inputLogin && customer.password == inputPassword)
                {
                    transferLogin = customer.login;
                    invalidData = false;
                    OrderWindow owLog = new OrderWindow();
                    owLog.Show();
                    lw.Hide();
                    break;
                }

                invalidData = true;
            }

            if (invalidData)
            {
                MessageBox.Show("Invalid Login or Password");
            }
        }
    }
}
