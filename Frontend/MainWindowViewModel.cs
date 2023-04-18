using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Model;

namespace Frontend
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Message> messages { get; set; }

        private Message selectedMessage;

        public Message SelectedMessage
        {
            get { return selectedMessage; }
            set
            {
                if (value != null)
                {
                    selectedMessage = new Message()
                    {
                        UserID = value.UserID,
                        Text = value.Text,
                        date = value.date
                    };
                    OnPropertyChanged();

                }
            }
        }


        public ICommand SendMessage { get; set; }


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
                messages = new RestCollection<Message>("http://localhost:38934", "message", "hub");
                SendMessage = new RelayCommand(() =>
                {
                    messages.Add(new Message()
                    {
                        UserID = SelectedMessage.UserID,
                        Text = SelectedMessage.Text,
                        date = SelectedMessage.date
                    });
                });





            }
        }
    }
}
