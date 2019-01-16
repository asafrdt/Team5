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
    public partial class CeoAddWorker : Form
    {
        public CeoAddWorker()
        {
            InitializeComponent();
        }
        public void Add_Worker(SqlConnection conn,string username=null, string Employee_id = null, string password = null, string type = null, string Employee_full_name = null, string Employee_mobile = null, string Gender = null)
        {

            SqlCommand sda1 = new SqlCommand("INSERT INTO Employees (username,password,type,Employee_id,Employee_full_name,Employee_mobile,Gender) VALUES ('" + username + "','" + password + "','" + type + "','" + Employee_id + "','" + Employee_full_name + "','" + Employee_mobile + "','" + Gender + "')", conn);
            SqlDataAdapter da = new SqlDataAdapter(sda1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            

        }
        private void label5_Click(object sender, EventArgs e)
        {
            int parsedValue;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\PROJECT\TEAM5\TEAM5\TEAM5 PROJECT\DATABASE\STOREMANGE.MDF;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select username from Employees where username ='" + UsernameBox.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("The username is already exists in the system\nPlease select another user name", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UsernameBox.Text == "" || PasswordBox.Text == "" || TypeBox.Text == "" || IDBox.Text == "" || FullnameBox.Text == "" || PhoneBox.Text == "" || GenderBox.Text =="")
                    MessageBox.Show("Fill out the missing text box please!", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!int.TryParse(IDBox.Text, out parsedValue))
                    MessageBox.Show("'ID' is a number only field! Enter a vaild id and try again! ");
                else
                {

                    string username = UsernameBox.Text;
                    string password = PasswordBox.Text;
                    string type = TypeBox.Text;
                    string Employee_id = IDBox.Text;
                    string Employee_full_name = FullnameBox.Text;
                    string Employee_mobile = PhoneBox.Text;
                    string Gender = GenderBox.Text;
                    Add_Worker(conn, username, password, type, Employee_id, Employee_full_name, Employee_mobile, Gender);
                    MessageBox.Show("New worker has been added to the system", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void CeoAddWorker_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IDBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Login ss = new Login();
            ss.Show();
        }

        private void returnCashier_Click(object sender, EventArgs e)
        {
            this.Close();
            Checkout ss = new Checkout();
            ss.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void PhoneBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
