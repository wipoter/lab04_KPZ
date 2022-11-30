using labb04_KPZ.Models;
using System.Collections.ObjectModel;

namespace labb04_KPZ.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        private string? name;
        private string? suranme;
        private int? age;
        private string? institute;
        private string? group;
        private int? num;
        private ObservableCollection<AchievementViewModel> achievements;

        public string? Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string? Surname
        {
            get => suranme;
            set
            {
                suranme = value;
                OnPropertyChanged("Surname");
            }
        }


        public int? Age 
        { 
            get => age;
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }

        }

        public string? Institute
        {
            get => institute;
            set
            {
                institute = value;
                OnPropertyChanged("Institute");
            }
        }

        public string? Group
        {
            get => group;
            set
            {
                group = value;
                OnPropertyChanged("Group");
            }
        }

        public int? Num
        {
            get => num;
            set
            {
                num = value;
                OnPropertyChanged("Num");
            }
        }

        public ObservableCollection<AchievementViewModel> Achievements
        {
            get => achievements;
            set
            {
                achievements = value;
                OnPropertyChanged("Achievements");
            }
        }
    }
}
