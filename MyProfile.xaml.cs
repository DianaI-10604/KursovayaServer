using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Курсовая_работа2.Context;
using Курсовая_работа2.Models;

namespace Курсовая_работа2
{
    /// <summary>
    /// Логика взаимодействия для MyProfile.xaml
    /// </summary>
    public partial class MyProfile : UserControl, INotifyPropertyChanged
    {
        private User _user;

        public MyProfile()
        {
            InitializeComponent();
        }
        public MyProfile(User user)
        {
            InitializeComponent();
            _user = user;
            LoadUserData();
            DataContext = _user;
        }

        private void LoadUserData()
        {
            Username = $"{_user.Usersurname} {_user.Username} {_user.Userpatronymicname}";
            Email = _user.Email;
            Phonenumber = _user.Phonenumber;
            Birthdate = _user.Birthdate;
            Gender = _user.Gender;
            Snils = _user.Snils;
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _usersurname;
        public string Usersurname
        {
            get => _usersurname;
            set
            {
                _usersurname = value;
                OnPropertyChanged(nameof(Usersurname));
            }
        }

        private string _userpatronymicname;
        public string Userpatronymicname
        {
            get => _userpatronymicname;
            set
            {
                _userpatronymicname = value;
                OnPropertyChanged(nameof(Userpatronymicname));
            }
        }

        private string _userpassword;
        public string Userpassword
        {
            get => _userpassword;
            set
            {
                _userpassword = value;
                OnPropertyChanged(nameof(Userpassword));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _snils;
        public string Snils
        {
            get => _snils;
            set
            {
                _snils = value;
                OnPropertyChanged(nameof(Snils));
            }
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        private string _phonenumber;
        public string Phonenumber
        {
            get => _phonenumber;
            set
            {
                _phonenumber = value;
                OnPropertyChanged(nameof(Phonenumber));
            }
        }

        private DateOnly? _birthdate;
        public DateOnly? Birthdate
        {
            get => _birthdate;
            set
            {
                _birthdate = value;
                OnPropertyChanged(nameof(Birthdate));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //меняем пароль пользователя
        private void UpdatePassword_ButtonClick(object sender, RoutedEventArgs e)
        {
            PasswordBox newpassword = (PasswordBox)this.FindName("NewPassword"); // Находим элемент PasswordBox по его имени
            string newPassword = newpassword.Password; // Получаем введенный новый пароль

            PasswordBox repeatpassword = (PasswordBox)this.FindName("NewPassword"); // Находим элемент PasswordBox по его имени
            string repeatPassword = repeatpassword.Password; // Получаем повтор пароля

            if (newPassword != repeatPassword)
            {
                MessageBox.Show("Пароли не совпадают!");
            }

            else if (newPassword == repeatPassword) //если пароли совпадают
            {
                UpdatePassword(newPassword);
                MessageBox.Show("Пароль успешно изменен!");
            }
        }

        private void UpdatePassword(string newPassword)
        {
            using (var dbContext = new User999Context()) // Создаем экземпляр контекста базы данных
            {
                var existingUser = dbContext.Users.FirstOrDefault(u => u.Id == _user.Id); // Находим пользователя в базе данных по его идентификатору

                if (existingUser != null)
                {
                    existingUser.Userpassword = newPassword; // Обновляем пароль пользователя

                    dbContext.SaveChanges(); // Сохраняем изменения в базе данных
                }
            }
        }
    }
}
