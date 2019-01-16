﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Team5_project
{
    public partial class NewCostumer : Form
    {
        public NewCostumer()
        {
            InitializeComponent();
        }
        public void Add_customer(SqlConnection conn, string Id = null,string Name=null,string Phone=null)
        {

            SqlCommand sda1 = new SqlCommand("INSERT INTO Costumers (Costumer_id,Costumer_Full_name,Costumer_Mobile) VALUES ('" + Id + "','" + Name + "','" + Phone + "')", conn);
            SqlDataAdapter da = new SqlDataAdapter(sda1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            

        }
        private void label5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\PROJECT\TEAM5\TEAM5\TEAM5 PROJECT\DATABASE\STOREMANGE.MDF;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select Costumer_id from Costumers where Costumer_id ='" + IDBox.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int parsedValue;

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("This ID is already exists in the system\nPlease go to 'Exiting Costumer page'", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (IDBox.Text == "" || FullnameBox.Text == "" || PhoneBox.Text == "")
                MessageBox.Show("There is still empty fields\nPlease make sure you fill all fields", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!int.TryParse(IDBox.Text, out parsedValue))
                MessageBox.Show("'ID' is a number only field! Enter a vaild id and try again! ");
            else
            {
                string Id = IDBox.Text;
                string Name = FullnameBox.Text;
                string Phone = PhoneBox.Text;
                Add_customer(conn, Id, Name, Phone);
                MessageBox.Show("New costumer has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void IDBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PhoneBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewCostumer_Load(object sender, EventArgs e)
        {

        }
    }
}

