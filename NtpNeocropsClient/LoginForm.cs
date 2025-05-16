using ClassLibrary;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Entity;

namespace NtpNeocropsClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            WindowPosition.LoadWindowPosition(this);
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void buttonCreateAccount_Move(object sender, EventArgs e)
        {
            WindowPosition.SaveWindowPosition(this);
        }

        private void LoginForm_Move(object sender, EventArgs e)
        {
            WindowPosition.SaveWindowPosition(this);
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            if (!Validator.IsRequired(email) || !Validator.IsRequired(password))
            {
                MessageBox.Show("All fields are required!");
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Email is not in correct format!");
                return;
            }

            try
            {
                var data = await ApiClient.PostAsync<AuthenticationResponseDto>("/login", new AuthenticationRequestDto
                {
                    Email = email,
                    Password = password
                });

                if (data != null)
                {
                    MessageBox.Show($"Welcome, {data.User.FullName}!");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
