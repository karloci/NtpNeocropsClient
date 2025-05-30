﻿using ClassLibrary;
using CredentialManagement;
using NtpNeocropsClient.Dto;
using NtpNeocropsClient.Entity;
using NtpNeocropsClient.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NtpNeocropsClient
{
    public partial class ProfileForm : AuthAbstractForm
    {
        public ProfileForm() : base()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {

            User loggedInUser = NeocropsState.LoggedInUser;

            if (loggedInUser != null)
            {
                textBoxFullName.Text = loggedInUser.FullName;
                textBoxEmail.Text = loggedInUser.Email;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string fullName = textBoxFullName.Text;
            string email = textBoxEmail.Text;

            if (!Validator.IsRequired(fullName) || !Validator.IsRequired(email))
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

            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Wrong email or password!");
                    return;
                }
                else if (ex.StatusCode == HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Server error!");
                    return;
                }
            }
        }
    }
}
