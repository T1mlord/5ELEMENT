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
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using System.Runtime;
using System.Data;
using System.Data.SqlClient;

namespace ООО__5ELEMENT_.Pages.Employees.Admin.Dishes
{
    /// <summary>
    /// Логика взаимодействия для Page_Dish_Work.xaml
    /// </summary>
    public partial class Page_Dish_Work : Page
    {
        DataTable Types = new DataTable();
        string ID;
        public Page_Dish_Work(string ID)
        {
            InitializeComponent();

            SqlDataAdapter TypeAdapter = new SqlDataAdapter("SELECT [DishTypeID], [DishTypeTitle] FROM DishType", Classes.Class_Constant_Data.Connection);
            TypeAdapter.Fill(Types);
            for (int i = 0; i < Types.Rows.Count; i++)
            {
                ComboBoxItem Type = new ComboBoxItem();
                Type.Content = CreateTextBlock(Types.Rows[i][1].ToString());
                ComboBox_Type.Items.Add(Type);
            }

            DataTable Table = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM DishesView WHERE DishID LIKE '" + ID + "'", Classes.Class_Constant_Data.Connection);
            Adapter.Fill(Table);
            if (Table.Rows.Count > 0)
            {
                TextBox_Name.Text = "" + Table.Rows[0][2];
                TextBox_Cost.Text = "" + Table.Rows[0][3];
                TextBox_Quantity.Text = "" + Table.Rows[0][4];
                TextBox_Description.Text = "" + Table.Rows[0][5];
            }


            this.ID = ID;
        }
        string Image_Path = Classes.Class_Constant_Data.Exe_Directory + @"\Resources\Dishes\picture.png";
        private TextBlock CreateTextBlock(string Text)
        {
            TextBlock TextBlock_Role_Item = new TextBlock();
            TextBlock_Role_Item.TextWrapping = TextWrapping.Wrap;
            TextBlock_Role_Item.Width = 170;
            TextBlock_Role_Item.FontFamily = new FontFamily("Comic Sans MS");
            TextBlock_Role_Item.FontSize = 20;
            TextBlock_Role_Item.Text = Text;

            return TextBlock_Role_Item;
        }

        private void StackPanel_ImageDish_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (Files.Length > 1)
                    MessageBox.Show("Выберите один файл для загрузки!");
                else
                {
                    Image_Path = Files[0];
                    Image_Dish.Source = new BitmapImage(new Uri(Image_Path));
                }
            }

            TextBlock_ImageHint.Visibility = Visibility.Hidden;
        }

        private void StackPanel_ImageDish_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog SelectedFile = new OpenFileDialog();
            SelectedFile.Filter = "Image Files (*.BMP; *.JPG; *.GIF; *.PNG)|*.BMP; *.JPG; *.GIF; *.PNG";
            SelectedFile.InitialDirectory = Classes.Class_Constant_Data.Exe_Directory + @"\Resources\Dishes";
            SelectedFile.Title = "Выберите картинку";

            if (SelectedFile.ShowDialog() == true)
            {
                Image_Path = SelectedFile.FileName;
                Image_Dish.Source = new BitmapImage(new Uri(Image_Path));
            }
            else
            {
                Image_Path = Classes.Class_Constant_Data.Exe_Directory + @"\Resources\Dishes\picture.png";
                Image_Dish.Source = new BitmapImage(new Uri(Image_Path));
            }

            TextBlock_ImageHint.Visibility = Visibility.Hidden;
        }
        bool IsGoodLetters(char c)
        {
            if (c >= '0' && c <= '9')
                return true;

            if (c >= 'a' && c <= 'z')
                return true;
            if (c >= 'A' && c <= 'Z')
                return true;
            return false;
        }
        bool IsGoodNumbers(char c)
        {
            if (c >= 'a' && c <= 'z')
                return true;
            if (c >= 'A' && c <= 'Z')
                return true;

            return false;
        }

        private void TextBox_PreviewTextInput_VerificationNumbers(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(IsGoodNumbers);
        }
        private void TextBox_PreviewTextInput_VerificationLetters(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.All(IsGoodLetters);
        }
        private string TypeDetection()
        {
            for (int i = 0; i < Types.Rows.Count; i++)
            {
                if (ComboBox_Type.Text == Types.Rows[i][1].ToString())
                    return Types.Rows[i][0].ToString();
            }
            return "";
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFieldsNull())
            {
                Classes.Class_Constant_Data.Connection.Open();

                byte[] Image_AsBytes = null;
                FileStream FileStream = new FileStream(Image_Path, FileMode.Open, FileAccess.Read);
                BinaryReader BinaryReader = new BinaryReader(FileStream);
                Image_AsBytes = BinaryReader.ReadBytes((int)FileStream.Length);

                SqlCommand CommandUpdate = new SqlCommand("UPDATE Dishes SET DishType = '" + TypeDetection() + "', DishName = '" + TextBox_Name.Text + "', DishCost = '" + TextBox_Cost.Text + "', DishQuantity = '" + TextBox_Quantity.Text + "', DishDescription = '" + TextBox_Description.Text + "' WHERE DishID = " + ID, Classes.Class_Constant_Data.Connection);
                CommandUpdate.ExecuteNonQuery();

                MessageBox.Show("Блюдо обновлено!");

                Classes.Class_Constant_Data.Connection.Close();
            }
            else
                MessageBox.Show("Вы заполнили не все поля!");

            Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Page_Dishes_View());
        }
        private bool IsFieldsNull()
        {
            if (ComboBox_Type.Text == "" && TextBox_Name.Text == "" && TextBox_Cost.Text == "" && TextBox_Description.Text == "" && TextBox_Quantity.Text == "")
                return true;
            return false;
        }
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFieldsNull())
            {
                Classes.Class_Constant_Data.Connection.Open();

                byte[] Image_AsBytes = null;
                FileStream FileStream = new FileStream(Image_Path, FileMode.Open, FileAccess.Read);
                BinaryReader BinaryReader = new BinaryReader(FileStream);
                Image_AsBytes = BinaryReader.ReadBytes((int)FileStream.Length);

                SqlCommand CommandInsert = new SqlCommand("INSERT INTO Dishes (DishType, DishName, DishCost, DishQuantity, DishDescription, DishImage) VALUES ('" + TypeDetection() + "', '" + TextBox_Name.Text + "', '" + TextBox_Cost.Text + "', '" + TextBox_Quantity.Text + "', '" + TextBox_Description.Text + "', @Image)", Classes.Class_Constant_Data.Connection);
                CommandInsert.Parameters.Add("Image", Image_AsBytes);
                CommandInsert.ExecuteNonQuery();

                MessageBox.Show("Блюдо добавлено!");

                Classes.Class_Constant_Data.Connection.Close();
            }
            else
                MessageBox.Show("Вы заполнили не все поля!");

            Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Page_Dishes_View());
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ID != null || ID != "")
            {
                Classes.Class_Constant_Data.Connection.Open();
                try
                {
                    SqlCommand CommandDelete = new SqlCommand("DELETE FROM Dishes WHERE DishID = " + ID, Classes.Class_Constant_Data.Connection);
                    CommandDelete.ExecuteNonQuery();

                    MessageBox.Show("Блюдо удалено!");
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить блюдо!");
                }

                Classes.Class_Constant_Data.Connection.Close();

                Classes.Class_Frame_Manager.Admin_Template_View.Navigate(new Page_Dishes_View());

            }
        }
    }
}
