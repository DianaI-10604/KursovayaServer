using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Курсовая_работа2.Context;
using Курсовая_работа2.Models;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Курсовая_работа2
{
    /// <summary>
    /// Логика взаимодействия для RegistrationUser.xaml
    /// </summary>
    public partial class RegistrationUser : UserControl
    {
        public RegistrationUser()
        {
            InitializeComponent();
        }

        //Проверяем все ли поля заполнены. Если нет, то выводим окно с текстом: не все поля заполнены. Если пароли не совпадают то вводить заново
        //Потом добавить кнопку чтобы была возможность увидеть пароль
        //если все данные заполнены и пароли совпадают, то переходим в MainMenu
        //добавить проверку на Radiobutton
        private void ApplyRegistration_ButtonClick(object sender, RoutedEventArgs e)
        {
            string gender = string.Empty;
            if (!string.IsNullOrEmpty(usersurname.Text) && !string.IsNullOrEmpty(username.Text) &&
                !string.IsNullOrEmpty(userpatronymicname.Text) && !string.IsNullOrEmpty(userphone.Text) &&
                !string.IsNullOrEmpty(useremail.Text) && !string.IsNullOrEmpty(userbirth.Text) &&
                (MaleRadioButton.IsChecked == true || FemaleRadioButton.IsChecked == true) &&
                !string.IsNullOrEmpty(usersnils.Text) && !string.IsNullOrEmpty(userpassword.Password) &&
                !string.IsNullOrEmpty(repeatpassword.Password))
            {
                if (userpassword.Password == repeatpassword.Password) //пароли совпадают
                {
                    if (MaleRadioButton.IsChecked == true)
                    {
                        gender = "Мужской";
                    }
                    else if (FemaleRadioButton.IsChecked == true)
                    {
                        gender = "Женский";
                    }

                    User newUser = new User
                    {
                        Username = username.Text,
                        Usersurname = usersurname.Text,
                        Userpatronymicname = userpatronymicname.Text,
                        Gender = gender,
                        Email = useremail.Text,
                        Birthdate = DateOnly.FromDateTime(userbirth.SelectedDate.GetValueOrDefault()),
                        Snils = usersnils.Text,
                        Phonenumber = userphone.Text,
                        Userpassword = userpassword.Password,
                    };

                    //Добавление пользователя в базу данных(псевдокод)
                    using (var dbContext = new User999Context()) // Используйте ваш DbContext
                    {
                        dbContext.Users.Add(newUser);
                        dbContext.SaveChanges(); // Сохранение изменений в базе данных
                    }

                    MessageBox.Show("Пользователь успешно зарегистрирован!");

                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                    mainWindow.ContentControlPage.Content = new Authorization();
                }

                //Пароли не совпадают
                else
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
            }

            //Какое-то из полей пустое
            else
            {
                MessageBox.Show("Пароли не совпадают!");
            }
        }
    }
}
