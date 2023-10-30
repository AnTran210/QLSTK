using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLiSoTietKiem
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        string connectStr = @"Data Source=LAPTOP-9VMFMRRH\SQLEXPRESS;Initial Catalog=QLSTK;Integrated Security=True";

        private void Form6_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectStr);
            connection.Open();
            SqlCommand command;
            command = connection.CreateCommand();
            command.CommandText = "select LOAITK from LOAITIETKIEM";
            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                comboLoaiTK.Items.Add(row[0]);
            }
            connection.Close();
        }

        private void buttonQD1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectStr);
            connection.Open();
            SqlCommand command;
            command = connection.CreateCommand();
            command.CommandText = "update HANMUC set TIENTOITHIEU = "+textTien.Text+" where MYKEY = 1";
            int flag = command.ExecuteNonQuery();
            if (flag == 1)
            {
                MessageBox.Show("Cập nhật hạn mức thành công.");
            }
            connection.Close();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectStr);
            connection.Open();
            SqlCommand command;
            command = connection.CreateCommand();
            command.CommandText = "insert into LOAITIETKIEM values('" + comboLoaiTK.Text + "'," + textKyhan.Text + "," + textLaisuat.Text + ")";
            int flag = command.ExecuteNonQuery();
            if (flag == 1)
            {
                MessageBox.Show("Thêm loại kỳ hạn thành công.");
            }
            connection.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectStr);
            connection.Open();
            SqlCommand command;
            command = connection.CreateCommand();
            command.CommandText = "delete from LOAITIETKIEM where LOAITK = N'" + comboLoaiTK.Text + "'";
            int flag = command.ExecuteNonQuery();
            if (flag == 1)
            {
                MessageBox.Show("Xóa loại kỳ hạn thành công.");
            }
            connection.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectStr);
            connection.Open();
            SqlCommand command;
            command = connection.CreateCommand();
            command.CommandText = "update LOAITIETKIEM set LAISUAT = " + textLaisuat.Text + " where LOAITK = '" + comboLoaiTK.Text + "'";
            int flag = command.ExecuteNonQuery();
            if (flag == 1)
            {
                MessageBox.Show("Cập nhật lãi suất thành công.");
            }
            connection.Close();
        }
    }
}
