using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public MyProfile(User user)
        {
            InitializeComponent();
            _user = user;
            Username = $"{_user.Usersurname} {_user.Username} {_user.Userpatronymicname}";
            DataContext = this;
        }

        public string Username { get; set; }


        //private void LoadUserData()
        //{
        //    // Пример использования контекста базы данных для получения данных пользователя
        //    using (var context = new PolyclinicContext())
        //    {
        //        // Предполагается, что текущий авторизованный пользователь имеет ID = 1
        //        // Замените на фактический ID авторизованного пользователя
        //        int userId = 1;

        //        var user = context.Users
        //                          .Where(u => u.Id == userId)
        //                          .Select(u => new
        //                          {
        //                              FullName = u.Usersurname + " " + u.Username + " " + u.Userpatronymicname
        //                          })
        //                          .FirstOrDefault();

        //        if (user != null)
        //        {
        //            Username = user.FullName;
        //        }
        //    }

        //    // Привязка значения к элементу управления
        //    DataContext = this;
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
