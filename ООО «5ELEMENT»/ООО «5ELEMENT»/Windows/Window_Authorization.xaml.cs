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
using ООО__5ELEMENT_.Classes;
using ООО__5ELEMENT_.Pages;

namespace ООО__5ELEMENT_.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window_Authorization.xaml
    /// </summary>
    public partial class Window_Authorization : Window
    {
        public Window_Authorization()
        {
            InitializeComponent();

            Class_Frame_Manager.Authorization_Frame = this.Frame_Authorization;
            Class_Frame_Manager.Authorization_Frame.Navigate(new Pages.Authorization.Page_Authorization_User());
            Class_Frame_Manager.Authorization_Frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            Class_Frame_Manager.Auth = this;

            Class_Cart.Quantities.Columns.Add();

            try
            {
                Class_Constant_Data.Connection.Open();
                Class_Constant_Data.Connection.Close();
            }
            catch
            {
                Class_Frame_Manager.Authorization_Frame.Navigate(new Pages.NoDataBase.Page_NoDataBase());
            }

        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
