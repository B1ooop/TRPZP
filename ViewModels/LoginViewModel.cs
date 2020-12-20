using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesDepartment.WPF.ViewModels;

namespace TRPZ.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        private string _login;

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
    }
}
