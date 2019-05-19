using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using KariHotel.Models;

namespace KariHotel.Data
{
    public class DbInitalizer
    {
        public static void Initialize(HotelContext context)
        {
            context.Database.EnsureCreated();


            if (context.Clients.Any())
           {
              return;   // DB has been seeded
            }

            var clients = new Client[]
            {
            new Client{Name = "Макушенко",FirstMidName="Сергійович",LastName="Олександр",ContactPhone = "911", Email = "Len@ukr.net"},
            new Client{Name = "Сольшенко",FirstMidName="Вадимович",LastName="Євген",ContactPhone = "911", Email = "Len@ukr.net"},
            new Client{Name = "Коробов",FirstMidName="Ігорович",LastName="Олексій",ContactPhone = "911", Email = "Len@ukr.net"},
            new Client{Name = "Некрасова",FirstMidName="Максимівна",LastName="Дарія",ContactPhone = "911", Email = "Len@ukr.net"},
            new Client{Name = "Лобанов",FirstMidName="Маркович",LastName="Дем'ян",ContactPhone = "911", Email = "Len@ukr.net"},
            new Client{Name = "Козаченко",FirstMidName="Єрополкович",LastName="Сергій",ContactPhone = "911", Email = "Len@ukr.net"},
            new Client{Name = "Рогозіна",FirstMidName="Артемівна",LastName="Соломія",ContactPhone = "911", Email = "Len@ukr.net"},
            new Client{Name = "Серрано",FirstMidName="Семьюельович",LastName="Марчелло",ContactPhone = "911", Email = "Len@ukr.net"}
            };
            foreach (Client s in clients)
            {
                context.Clients.Add(s);
            }
            context.SaveChanges();

            

            var rooms = new Room[]
            {
            new Room{Number = 1 ,Title="Двомісний люкс"},
            new Room{Number = 2 ,Title="Стандарт на двох"},
            new Room{Number = 3 ,Title="Одномісна кімната"},
            new Room{Number = 4 ,Title="Трьохмісна кімната"},
            new Room{Number = 5 ,Title="Люкс на трьох"},
            new Room{Number = 6 ,Title="Чотирьохмісний номер"},
            new Room{Number = 7 ,Title="Просто ліжко голі стіни"}
            };
            foreach (Room c in rooms)
            {
                context.Rooms.Add(c);
            }
            context.SaveChanges();

            var orders = new Orders[]
            {
            new Orders{ClientID=1,RoomID=1,Check_inDate=DateTime.Parse("2005-09-01"), Check_outDate=DateTime.Parse("2003-09-01"), OrderDate = DateTime.Parse("2002-09-01")},
            new Orders{ClientID=2,RoomID=2,Check_inDate=DateTime.Parse("2002-09-01"), Check_outDate=DateTime.Parse("2003-09-01"), OrderDate = DateTime.Parse("2002-09-01")},
            new Orders{ClientID=3,RoomID=3,Check_inDate=DateTime.Parse("2003-09-01"), Check_outDate=DateTime.Parse("2003-09-01"), OrderDate = DateTime.Parse("2002-09-01")},
            new Orders{ClientID=4,RoomID=4,Check_inDate=DateTime.Parse("2002-09-01"), Check_outDate=DateTime.Parse("2003-09-01"), OrderDate = DateTime.Parse("2002-09-01")},
            new Orders{ClientID=5,RoomID=5,Check_inDate=DateTime.Parse("2002-09-01"), Check_outDate=DateTime.Parse("2003-09-01"), OrderDate = DateTime.Parse("2002-09-01")},
            new Orders{ClientID=6,RoomID=6,Check_inDate=DateTime.Parse("2001-09-01"), Check_outDate=DateTime.Parse("2003-09-01"), OrderDate = DateTime.Parse("2002-09-01")},
            new Orders{ClientID=8,RoomID=7,Check_inDate=DateTime.Parse("2003-09-01"), Check_outDate=DateTime.Parse("2003-09-01"), OrderDate = DateTime.Parse("2002-09-01")},
            };
            foreach (Orders e in orders)
            {
                context.Orders.Add(e);
            }
            context.SaveChanges();

            var fines = new Fines[]
{
            new Fines{Price = 1456 ,  Name="Упс"},
            new Fines{Price = 234 , Name="Ой йой"},
            new Fines{Price = 3645 , Name="Побитий персонал"},
            new Fines{Price = 46534 , Name="Зламане вікно"},
            new Fines{Price = 5645 , Name="П'яні драки"},
            new Fines{Price = 6765 , Name="Пісні Монатіка"},
            new Fines{Price = 7345 , Name="Просто так"}
};
            foreach (Fines c in fines)
            {
                context.Fines.Add(c);
            }
            context.SaveChanges();

            var oddserv = new OddServ[]
{
            new OddServ{Price = 1456 ,  Name="Щось"},
            new OddServ{Price = 234 , Name="Ще щось"},
            new OddServ{Price = 3645 ,  Name="І ще щось"},
            new OddServ{Price = 46534 , Name="А потім ще щось"},
            new OddServ{Price = 5645 , Name="Оце"},
            new OddServ{Price = 6765 , Name="Ну те"},
            new OddServ{Price = 7345 , Name="Невідомо"}
};
            foreach (OddServ c in oddserv)
            {
                context.OddServ.Add(c);
            }
            context.SaveChanges();

        }

    }
}
