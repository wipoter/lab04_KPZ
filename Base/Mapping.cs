using AutoMapper;
using labb04_KPZ.Models;
using labb04_KPZ.ViewModels;

namespace labb04_KPZ.Controllers;

public class Mapping
{
    [System.Obsolete]
    public void Create()
    {
        Mapper.CreateMap<AccountViewModel, Account>();
        Mapper.CreateMap<Account, AccountViewModel>();

        Mapper.CreateMap<StudentViewModel, Student>();
        Mapper.CreateMap<Student, StudentViewModel>();

        Mapper.CreateMap<AchievementViewModel, Achievement>();
        Mapper.CreateMap<Achievement, AchievementViewModel>();
    }

}