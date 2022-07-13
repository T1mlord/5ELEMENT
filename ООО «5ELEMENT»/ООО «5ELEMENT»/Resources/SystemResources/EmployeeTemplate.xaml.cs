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
using ООО__5ELEMENT_.Classes;
using System.Data.SqlClient;
using System.Data;

namespace ООО__5ELEMENT_.Resources.SystemResources
{
    /// <summary>
    /// Логика взаимодействия для EmployeeTemplate.xaml
    /// </summary>
    public partial class EmployeeTemplate : UserControl
    {
        string ID = "";
        public EmployeeTemplate(string ID)
        {
            InitializeComponent();

            DataTable Employee = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM UsersView WHERE UserID = " + ID, Class_Constant_Data.Connection);
            Adapter.Fill(Employee);

            TextBlock_FIO.Text = "" + Employee.Rows[0][1];
            TextBlock_BirthDate.Text = "" + Employee.Rows[0][2].ToString().Split(' ')[0];
            TextBlock_Phone.Text = "Телефон:\n" + Employee.Rows[0][3];
            TextBlock_Passport.Text = "Паспортные данные:\n" + Employee.Rows[0][4];
            TextBlock_Role.Text = "" + Employee.Rows[0][5];

            this.ID = ID;
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Class_Frame_Manager.Admin_Template_Work.Navigate(new Pages.Employees.Admin.Employees.Page_Employee_Work(ID));
        }
    }
}
