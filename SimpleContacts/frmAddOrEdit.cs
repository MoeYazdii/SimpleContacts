using SimpleContacts.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleContacts
{
    public partial class frmAddOrEdit : Form
    {
        IContactsRepository repository;
        public int contactId = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {


            if (contactId == 0)
            {
                this.Text = "Add New Contact";
            }
            else
            {
                this.Text = "Edit Contact";
                DataTable dt = repository.SelectRow(contactId);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtMobile.Text = dt.Rows[0][3].ToString();
                txtEmail.Text = dt.Rows[0][4].ToString();
                txtAge.Text = dt.Rows[0][5].ToString();
                txtAddress.Text = dt.Rows[0][6].ToString();
                btnSubmit.Text = "Edit";
            }
            ;
        }
        bool ValidateInput()

        {

            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter Name", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtFamily.Text == "")
            {
                MessageBox.Show("Please Enter Family", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtAge.Value == 0)
            {
                MessageBox.Show("Please Enter Age", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Please Enter Email", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtMobile.Text == "")
            {
                MessageBox.Show("Please Enter PhoneNumber", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                bool isSuccess;
                if (contactId == 0)
                {
                    isSuccess = repository.InsertContacts(txtName.Text, txtFamily.Text,
                           txtMobile.Text, txtEmail.Text, (int)txtAge.Value, txtAddress.Text);
                    if (isSuccess)
                    {
                        MessageBox.Show("Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    isSuccess = repository.UpdateContacts(contactId, txtName.Text, txtFamily.Text,
                           txtMobile.Text, txtEmail.Text, (int)txtAge.Value, txtAddress.Text);
                    if (isSuccess)
                    {
                        MessageBox.Show("Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
