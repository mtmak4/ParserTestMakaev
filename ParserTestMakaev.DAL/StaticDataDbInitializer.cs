using ParserTestMakaev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ParserTestMakaev.BL
{
    public static class StaticDataDbInitializer
    {
        public static void Initialize(ref ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>()
         {
            new User { /*Id = 1,*/ Name = "John", Surname = "Johnson",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
            new User { /*Id = 2,*/ Name = "Smith", Surname = "Smithson",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
            new User { /*Id = 3,*/ Name = "Евгений", Surname = "Петров",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
            new User { /*Id = 4,*/ Name = "Дарьева", Surname = "Дарья",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
            new User { /*Id = 5,*/ Name = "Петр", Surname = "Ефимов",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },

         };


                context.Users.AddRange(users);

                context.SaveChanges();
            }

            if (!context.Tasks.Any())
            {
                var tasks = new List<Task>()
          {
             new Task { Title="парсинг авито",Description="парсинг авито машины",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг книг",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг недвижимости",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг товаров для дома",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг одежды",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг обуви",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг электроники",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг смартфонов",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг планшетов",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг ноутбуков",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг дач",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг стройматериалов",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг продуктов питания",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг журналов",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг товаров для хобби",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг наушников",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг монет",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг купюр",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг мебели",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг штор",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг авито машины",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="товаров для хобби",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг услуг репетиторов",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
             new Task { Title="парсинг авито",Description="парсинг ноутбуков",DateCreation=DateTime.Now,DateLastChange=DateTime.Now },
          };
                context.Tasks.AddRange(tasks);
                context.SaveChanges();
            }


        }
    }
}
