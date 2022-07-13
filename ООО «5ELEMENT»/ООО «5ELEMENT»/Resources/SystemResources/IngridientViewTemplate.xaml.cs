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
    /// Логика взаимодействия для IngridientViewTemplate.xaml
    /// </summary>
    public partial class IngridientViewTemplate : UserControl
    {
        string ID = "";
        public IngridientViewTemplate(string ID)
        {
            InitializeComponent();

            DataTable Ingridient = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Ingridients WHERE IngridientID = " + ID, Class_Constant_Data.Connection);
            Adapter.Fill(Ingridient);

            TextBlock_Name.Text = "" + Ingridient.Rows[0][1];
            TextBlock_Quantity.Text = "Количество: " + Ingridient.Rows[0][2] + " (Шт.)";

            this.ID = ID;
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Class_Frame_Manager.Admin_Template_Work.Navigate(new Pages.Employees.Stockman.Ingridients.Page_Ingridients_Work(ID));
        }
    }
}
