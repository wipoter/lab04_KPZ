using labb04_KPZ.Models;

namespace labb04_KPZ.ViewModels
{
    public class AccountViewModel: ViewModelBase
    {
        private string? loggin;
        private string? password;
        private StudentViewModel student;

        public string? Loggin
        {
            get => loggin;
            set
            {
                loggin = value;
                OnPropertyChanged("Loggin");
            }
        }

        public string? Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public virtual StudentViewModel? Student
        {
            get => student;
            set
            {
                student = value;
                OnPropertyChanged("Student");
            }
        }
    }
}
