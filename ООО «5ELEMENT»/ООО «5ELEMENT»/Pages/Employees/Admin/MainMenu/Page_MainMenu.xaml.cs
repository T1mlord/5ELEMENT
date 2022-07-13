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

namespace ООО__5ELEMENT_.Pages.Employees.Admin.MainMenu
{
    /// <summary>
    /// Логика взаимодействия для Page_MainMenu.xaml
    /// </summary>
    public partial class Page_MainMenu : Page
    {
        public Page_MainMenu()
        {
            InitializeComponent();
            if (Classes.Class_Constant_Data.ButtonBack != null)
                Classes.Class_Constant_Data.ButtonBack.Visibility = Visibility.Hidden;
        }

        private void Button_Employees_Click(object sender, RoutedEventArgs e)
        {
            Classes.Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new Page_Frames_Template());
            Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Employees.Page_Employee_View());
            Classes.Class_Frame_Manager.Admin_Template_Work.Navigate(new Employees.Page_Employee_Work(""));

            Classes.Class_Constant_Data.ButtonBack.Visibility = Visibility.Visible;

            Classes.Class_Current_User.CurrentPage = "Сотруднкии";
        }

        private void Button_Dishes_Click(object sender, RoutedEventArgs e)
        {
            Classes.Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new Page_Frames_Template());
            Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Dishes.Page_Dishes_View());
            Classes.Class_Frame_Manager.Admin_Template_Work.Navigate(new Dishes.Page_Dish_Work(""));

            Classes.Class_Constant_Data.ButtonBack.Visibility = Visibility.Visible;

            Classes.Class_Current_User.CurrentPage = "Блюда";
        }

        private void Button_StopList_Click(object sender, RoutedEventArgs e)
        {
            Classes.Class_Frame_Manager.Admin_MainMenu_Frame.Navigate(new StopList.Page_StopList_View());

            Classes.Class_Constant_Data.ButtonBack.Visibility = Visibility.Visible;

            Classes.Class_Current_User.CurrentPage = "Стоплист";
        }
    }
}
