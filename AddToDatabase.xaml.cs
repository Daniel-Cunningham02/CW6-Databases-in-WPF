/* Name: Daniel Cunningham
 * Date: 2/14/2023
 * Creates a window which allows the user to enter in certain data to add to the database.
 */
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
        public AddToDatabase()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\EmployeeDB.accdb");

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeeID.Text != null && EmployeeID.Text != "EmployeeID:")
            {
                    
                    string query = "insert into Employees (EmployeeID, LastName, FirstName) values (@ID, @LN, @FN)";
                    OleDbCommand cmd = new OleDbCommand(query, cn);
                    cn.Open();
                    cmd.Parameters.AddWithValue("@ID", Int32.Parse(EmployeeID.Text));
                    cmd.Parameters.AddWithValue("@LN", LastName.Text);
                    cmd.Parameters.AddWithValue("@FN", FirstName.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    this.Close();
                        
                
            }
        }
    }
}
