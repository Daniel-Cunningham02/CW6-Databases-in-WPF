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
using System.Windows.Shapes;
using System.Data.OleDb;

namespace CW6_Databases_WPF
{
    /// <summary>
    /// Interaction logic for AddToDatabase.xaml
    /// </summary>
    public partial class AddToDatabase : Window
    {
        OleDbConnection cn;
        bool isAsset = false;
        public AddToDatabase(bool isAsset)
        {
            InitializeComponent();
            this.isAsset = isAsset;
            if(isAsset)
            {
                FirstNameText.Text = "ItemID";
                FirstName.Text = "ItemID";
                LastNameText.Text = "Item";
                LastName.Text = "Key";
            }
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\EmployeeDB.accdb");

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeeID.Text != null && EmployeeID.Text != "EmployeeID:")
            {
                if(FirstName.Text != null && LastName.Text != null)
                {
                    if(isAsset)
                    {
                        string query = "insert into Assets (EmployeeID, AssetID, Description) values (@ID, @FN, @LN)";
                        OleDbCommand cmd = new OleDbCommand(query, cn);
                        cn.Open();
                        cmd.Parameters.AddWithValue("@ID", Int32.Parse(EmployeeID.Text));
                        cmd.Parameters.AddWithValue("@FN", Int32.Parse(FirstName.Text));
                        cmd.Parameters.AddWithValue("@LN", LastName.Text);
                        cmd.ExecuteNonQuery();
                        
                    }
                    else if(!isAsset)
                    {
                        string query = "insert into Employees (EmployeeID, LastName, FirstName) values (@ID, @LN, @FN)";
                        OleDbCommand cmd = new OleDbCommand(query, cn);
                        cn.Open();
                        cmd.Parameters.AddWithValue("@ID", Int32.Parse(EmployeeID.Text));
                        cmd.Parameters.AddWithValue("@LN", LastName.Text);
                        cmd.Parameters.AddWithValue("@FN", FirstName.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
