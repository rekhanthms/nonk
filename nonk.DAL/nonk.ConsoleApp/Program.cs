using Azure;
using Microsoft.Extensions.DependencyInjection;
using nonk.DAL;
using nonk.DAL.Models;
using nonkDBFirst.DAL;
using System;
using System.Reflection;


namespace nonkConsoleApp
{
    public class Program
    {
        static NonkDbContext context;
        static nonkRepository repository;
        static Program()
        {
            context = new NonkDbContext();
            repository = new nonkRepository(context);
        }
        static void Main(string[] args)
        {
            // READ
            //users get check 

            var users = repository.GetAllUsers();
            foreach (var use in users)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t {3}", use.UserName, use.Age, use.Gender, use.DateOfBirth);
            }


            //CREATE
            // Add user

            //User user = new User()
            //{
            //    UserName = "AgentQ",
            //    Password = "Qamar@555",
            //    Age = 23,
            //    Gender = "M",
            //    EmailId = "qamarulislam@gmail.com",
            //    PhoneNumber = 8328275715,
            //    DateOfBirth = DateOnly.Parse("2001-11-28")
            //};

            //bool result = repository.AddUsers(user);
            //if (result)
            //{
            //    Console.WriteLine("New user added successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong. Try again!");
            //}


            // UPDATE
            // Update the users

            //bool result = repository.UpdateUsers(2, "Qamar@55");
            //if (result)
            //{
            //    Console.WriteLine("user details updated successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Something went wrong. Try again!");
            //}

            //DELETE
            //delete the users

            //bool status = repository.DeleteUsers(2);
            //    if (status)
            //    {
            //        Console.WriteLine("User details deleted successfully!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Some error occurred. Try again!!");
            //    }

        }


    }
}
