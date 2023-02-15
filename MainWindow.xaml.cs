using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;

namespace CW6_Databases_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
             cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\EmployeeDB.accdb");
        }

        private void AssetButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            TextArea.Text = "";
            while(read.Read())
            {
                data += read[0].ToString() + "\t" + read[1].ToString() + "\t" + read[2].ToString() + "\n";
            }
            TextArea.Text = data;
            cn.Close();
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            TextArea.Text = "";
            while(read.Read())
            {
                data += read[0].ToString() + "\t" + read[1].ToString() + "\t\t" + read[2].ToString() + "\n";
            }
            TextArea.Text = data;
            cn.Close();
        }


        private void AddAsset_Click(object sender, RoutedEventArgs e)
        {
            AddToDatabase add = new AddToDatabase();
            add.Show();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddToDatabase add = new AddToDatabase();
            add.Show();
        }
    }
}
