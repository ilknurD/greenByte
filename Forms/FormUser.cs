using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using GreenByte.Models;
using GreenByte.DataAccess;

namespace greenByte.Forms
{
    public partial class FormUser : Form
    {
        public UserModel User { get; private set; }
        public bool IsEditMode { get; private set; }

        public FormUser(UserModel user = null)
        {
            InitializeComponent();

            if (user != null && user.Id > 0)
            {
                User = user;
                txtUsername.Text = user.Username;
                txtEmail.Text = user.Email;
                txtPassword.Text = user.Password;
                IsEditMode = true;
            }
            else
            {
                User = new UserModel();
                IsEditMode = false;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Kullanıcı adı kontrolü (sadece eklemede)
            if (!IsEditMode)
            {
                var userDal = new UserDataAccess();
                var exists = userDal.GetAll().Any(u => u.Username == txtUsername.Text);
                if (exists)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LogDataAccess.Add(new LogModel
                    {
                        UserId = CurrentUser.Id,
                        LogType = LogType.Error,
                        Message = "Kullanıcı adı zaten kayıtlı!",
                        LogTime = DateTime.Now
                    });
                    return;
                }
            }

            // E-posta regex kontrolü
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Geçersiz e-posta adresi!",
                    LogTime = DateTime.Now
                });
            }

            User.Username = txtUsername.Text;
            User.Email = txtEmail.Text;
            User.Password = txtPassword.Text;
            User.RegistrationDate = DateTime.Now;
            User.GreenhouseId = CurrentGreenhouse.Selected?.Id ?? 0;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
