using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;
using Model;

namespace Client
{
    public class MainWindowViewModel : ObservableRecipient
    {
         public RestCollection<Message> Messages2 { get; set; }
        private string message;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private string user;

        public string User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }







        public ICommand SendMessageCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
        {


            if (!IsInDesignMode)
            {
                Messages2 = new RestCollection<Message>("https://localhost:44339/", "message", "hub");
                SendMessageCommand = new RelayCommand(() =>
                {
                    Messages2.Add(new Message()
                    {
                        UserID = User,
                        Text = Message,
                        date = DateTime.Now
                    });
                });

            }
        }
    }
}

