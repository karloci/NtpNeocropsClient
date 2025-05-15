using ClassLibrary;

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
    }
}
