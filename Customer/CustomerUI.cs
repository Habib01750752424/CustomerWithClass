using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Customer.Model;
using Customer.BLL;

namespace Customer
{
    public partial class CustomerUI : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        Customers customers = new Customers();
        int id;

        public CustomerUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string contact = contactTextBox.Text;

            if (name == ""||address == ""||contact == "")
            {
                MessageBox.Show("Please,,Field must not be empty..");
                return;
            }

            customers.Name = nameTextBox.Text;
            customers.Address = addressTextBox.Text;
            customers.Contact = contactTextBox.Text;

            if (_customerManager.Add(customers))
            {
                MessageBox.Show("Saved");
                showDataGridView.DataSource = _customerManager.Display();
                return;
            }
            else
            {
                MessageBox.Show("Not Saved");
                return;
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_customerManager.Delete(id))
            {
                MessageBox.Show("Deleted");
                showDataGridView.DataSource = _customerManager.Display();
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (showDataGridView.CurrentRow.Index != -1)
            {
                id = Convert.ToInt32(showDataGridView.CurrentRow.Cells[0].Value.ToString());
                nameTextBox.Text = showDataGridView.CurrentRow.Cells[1].Value.ToString();
                addressTextBox.Text = showDataGridView.CurrentRow.Cells[2].Value.ToString();
                contactTextBox.Text = showDataGridView.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string contact = contactTextBox.Text;

            if (name == "" || address == "" || contact == "")
            {
                MessageBox.Show("Please,,Field must not be empty..");
                return;
            }

            customers.Name = nameTextBox.Text;
            customers.Address = addressTextBox.Text;
            customers.Contact = contactTextBox.Text;

            if (_customerManager.Update(customers,id))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _customerManager.Display();
                return;
            }
            else
            {
                MessageBox.Show("Not Updated");
                return;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            customers.Name = nameTextBox.Text;
            customers.Address = addressTextBox.Text;
            customers.Contact = contactTextBox.Text;

            if (nameTextBox.Text == "" && addressTextBox.Text == "" && contactTextBox.Text == "")
            {
                MessageBox.Show("Please fillup any field for searching required value..");
                return;
            }

            showDataGridView.DataSource = "";
            showDataGridView.DataSource = _customerManager.Search(customers);
            return;
        }
    }
}
