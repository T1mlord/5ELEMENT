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

namespace ООО__5ELEMENT_.Pages.NoDataBase
{
    /// <summary>
    /// Логика взаимодействия для Page_NoDataBase.xaml
    /// </summary>
    public partial class Page_NoDataBase : Page
    {
        public Page_NoDataBase()
        {
            InitializeComponent();
        }

        private void Button_CheckConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.Class_Constant_Data.Connection.Open();
                Classes.Class_Constant_Data.Connection.Close();

                Classes.Class_Frame_Manager.Authorization_Frame.Navigate(new Authorization.Page_Authorization_User());
            }
            catch
            {
                MessageBox.Show("Подключение всё ещё невозможно.");
            }
        }
    }
}
