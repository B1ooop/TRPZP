﻿namespace TRPZ.ViewModels
{
    using System.Windows.Input;
    using HumanResourcesDepartment.WPF.ViewModels;
    using TRPZ.Commons;

    public class LoginViewModel: ViewModelBase
    {
        public ICommand LoginCommand { get; set; }

        public LoginViewModel(DatebaseAppContext db, LoginWindow lw)
        {
            LoginCommand = new LoginCommand(this, db, lw);
        }

        private string _login = "";

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password = "";

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }
}
