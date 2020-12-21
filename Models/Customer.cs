namespace TRPZ.Models
{
    using System;

    public class Customer
    {
        public int Id {get; set; }
        public string login, password, email, phone;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Customer() { }
        public Customer(String login, String password, String email, String phone)
        {
            this.login = login;
            this.password = password;
            this.email = email;
            this.phone = phone;
        }
    }
}
