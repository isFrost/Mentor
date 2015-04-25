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

namespace TeacherModule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string installationPath = @"E:\w3schools_demo\VirtualClassroom";

        public MainWindow()
        {
            InitializeComponent();
        }

        /*Форма входа*/
        private void AutoButton_Click(object sender, RoutedEventArgs e)
        {
            User userToCheck = new User();
            userToCheck.UserName = authoTextBox.Text.ToString();

            User storedUser = UserManager.FindUser(userToCheck);

            userToCheck.Salt = storedUser.Salt;
            userToCheck.UserPass = PassEncryptor.GetPassword(authoPassBox.Password.ToString(), userToCheck.Salt);

            if (userToCheck.UserPass.Equals(storedUser.UserPass))
            {
                MainWorkbench bench = new MainWorkbench();
                bench.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }


        /*форма регистрации*/
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (!regNameBox.Text.Equals("") && !regDepBox.Text.Equals("") && !regUserBox.Text.Equals("") && !regPassBox.Password.Equals(""))
            {
                User user = new User();
                user.UserID = 0;
                user.UserName = regUserBox.Text.ToString();
                user.Salt = PassEncryptor.GetSalt();
                user.UserPass = PassEncryptor.GetPassword(regPassBox.Password.ToString(), user.Salt);

                user = UserManager.CreateUser(user);

                using (var db = new Entities.Entities())
                {
                    var tutor = new Entities.Tutor
                    {
                        T_Id = user.UserID,
                        T_Name = regNameBox.Text.ToString(),
                        T_Tel = regTelBox.Text.ToString(),
                        T_Mail = regMailBox.Text.ToString(),
                        T_Department = regDepBox.Text.ToString()
                    };

                    db.Tutors.Add(tutor);
                    db.SaveChanges();
                }

                MainWorkbench bench = new MainWorkbench();
                bench.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Поля со звездочками обязательны для заполнения");
            }
        }
    }
}
