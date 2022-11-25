using DbTestHW.BusinessLogic;
using DbTestHW.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Avito Database тестовое приложение");

var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

var connectionString = config.GetConnectionString("HomeWorkDb");

Console.WriteLine("Создаём приложение Avito");

var avitoApp = new AvitoApp(connectionString);

StartApp();

Console.WriteLine("  Нажмите любую клавишу для завершения работы приложения...");
Console.ReadKey();

void StartApp()
{
    bool IsExit = false;
    while (IsExit == false)
    {
        PrintMenu();
        var key = Console.ReadKey().Key;

        switch (key)
        {
            case ConsoleKey.Escape:
                IsExit = true;
                break;

            case ConsoleKey.U:
                GetUserList();
                break;

            case ConsoleKey.C:
                GetCategoriesList();
                break;

            case ConsoleKey.A:
                GetAnnouncementsList();
                break;

            case ConsoleKey.N:
                AddNewUser();
                break;
        }
    }      
} 

void PrintMenu()
{
    Console.Clear();
    Console.WriteLine("Меню приложения:");
    Console.WriteLine("----- Для выхода, нажмите Escape -----");
    Console.WriteLine("--Работа с пользователями");
    Console.WriteLine("----Нажмите 'U' для вывода списка всех пользователей");
    Console.WriteLine("----Нажмите 'C' для вывода списка всех категорий");
    Console.WriteLine("----Нажмите 'A' для вывода списка всех объявлений");
    Console.WriteLine("----Нажмите 'N' для добавления нового пользователя");
}

void AddNewUser()
{
    Console.Write("");
    Console.WriteLine("Создаём нового пользователя");

    var user = new User();

    Console.WriteLine("Введите имя и фамилию пользователя:");
    user.Name = Console.ReadLine();

    Console.WriteLine("Введите пароль пользователя:");
    user.Password = Console.ReadLine();

    Console.WriteLine("Введите email пользователя:");
    user.Email = Console.ReadLine();

    Console.WriteLine("Введите телефон пользователя:");
    user.Phone = Console.ReadLine();

    var addedUser = avitoApp.AddNewUser(user);

    if (addedUser is not null)
    {
        Console.WriteLine($"      UserId | UserName | Email | Phone | Password");
        Console.WriteLine($"User: {addedUser.UserId} | {addedUser.Name} | {addedUser.Email} | {addedUser.Phone} | {addedUser.Password}");
    }
    else
        Console.WriteLine("Ошибка при создание пользователя");

    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
    Console.ReadKey();
}

void GetUserList()
{
    Console.Write("");
    Console.WriteLine("Запрашиваем список пользователей Avito");
    var userList = avitoApp.GetAllUsers();

    if (userList.Any())
    {
        Console.WriteLine($"В Avito {userList.Count} пользователей");
        Console.WriteLine($"Выводим список...");

        Console.WriteLine($"      UserId | UserName | Email | Phone | Password");

        foreach (var user in userList)
            Console.WriteLine($"User: {user.UserId} | {user.Name} | {user.Email} | {user.Phone} | {user.Password}");
    }
    else
    {
        Console.WriteLine("В Avito нет ни одного пользователя");
    }

    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
    Console.ReadKey();
}

void GetCategoriesList()
{
    Console.Write("");
    Console.WriteLine("Запрашиваем список категорий Avito");
    var categoriesList = avitoApp!.GetAllCategories();

    if (categoriesList.Any())
    {
        Console.WriteLine($"В Avito {categoriesList.Count} категорий");
        Console.WriteLine($"Выводим список...");

        Console.WriteLine($"      CategoryId | CategoryName ");

        foreach (var category in categoriesList)
            Console.WriteLine($"Category: {category!.CategoryId} | {category.CategoryName} ");
    }
    else
    {
        Console.WriteLine("В Avito нет ни одной категории");
    }

    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
    Console.ReadKey();
}

void GetAnnouncementsList()
{
    Console.Write("");
    Console.WriteLine("Запрашиваем список объявлений Avito");
    var announcmentList = avitoApp.GetAllAnnouncements();

    if (announcmentList.Any())
    {
        Console.WriteLine($"В Avito {announcmentList.Count} объявлений");
        Console.WriteLine($"Выводим список...");

        //Console.WriteLine($"      UserId | UserName | Email | Phone | Password");

        foreach (var announcment in announcmentList)
            Console.WriteLine($"User: {announcment.AnnouncementId} \r\n " + 
                              $"{announcment.UserName} \r\n {announcment.Email} \r\n {announcment.Phone} \r\n {announcment.Title } \r\n " + 
                              $"{announcment.Description} \r\n {announcment.CategoryName} \r\n {announcment.Created} | {announcment.Price} \r\n " +
                              $"{announcment.IsPayed} \r\n {announcment.IsVip}");
    }
    else
    {
        Console.WriteLine("В Avito нет ни одного объявления");
    }

    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить");
    Console.ReadKey();
}