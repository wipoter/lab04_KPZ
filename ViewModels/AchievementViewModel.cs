namespace labb04_KPZ.ViewModels
{
    public class AchievementViewModel: ViewModelBase
    {
        private string? name;
        private string describtion;

        public string? Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string? Describtion
        {
            get => describtion;
            set
            {
                describtion = value;
                OnPropertyChanged("Describtion");
            }
        }
    }
}
