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

namespace inputValidator
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }

        public void BtnSave_Click(object sender, EventArgs e)
        {
            String name = txtName.Text;
            String number = txtPhone.Text;
            String email = txtMail.Text;
            CheckIfValid(name, number, email);
        }

        public static bool ValidName(String name)
        {
            return Regex.IsMatch(name, @"^([A-Za-z]|s)+$");
        }

        public static bool ValidNumber(String number)
        {
            return Regex.IsMatch(number, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}$");
        }

        public static bool ValidMail(String mail)
        {
            return Regex.IsMatch(mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public void CheckIfValid(String name, String number, String mail)
        {
            if(name.Length == 0 || number.Length == 0 || mail.Length == 0)
            {
                MessageBox.Show("Something is missing");
            }
            else
            {
                if (!ValidName(name))
                {
                    MessageBox.Show("Name is invalid (only alphabetical characters are avaible)");
                }

                if (!ValidNumber(number))
                {
                    MessageBox.Show("Not a valid US phone number");
                }

                if (!ValidMail(mail))
                {
                    MessageBox.Show("Not a valid e-mail");
                }

                if(ValidName(name) && ValidMail(mail) && ValidNumber(number))
                {
                    ReformatPhone(number);
                }
            }
        }

        static string ReformatPhone(string s)
        {
            Match m = Regex.Match(s, @"^(?(\d{3}))?[\s-]?(\d{3})-?(\d{4})$");
            return String.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}