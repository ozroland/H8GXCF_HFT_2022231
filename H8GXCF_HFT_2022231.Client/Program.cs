using ConsoleTools;
using H8GXCF_HFT_2022231.Models;
using System;
using System.Collections.Generic;

namespace H8GXCF_HFT_2022231.Client
{
    class Program
    {
        static RestService rest;
        static RestService rest2;
        static RestService rest3;

        static void Create(string entity)
        {
            if (entity == "Member")
            {
                Console.Write("Enter member Name: ");
                string name = Console.ReadLine();
                rest.Post(new Member() { Name = name }, "member");
            }
            else if (entity == "Membership")
            {
                Console.Write("Enter Membership Name: ");
                string name = Console.ReadLine();
                rest2.Post(new Membership() { Name = name }, "membership");
            }
            else
            {
                Console.Write("Enter Instructor Name: ");
                string name = Console.ReadLine();
                rest3.Post(new Instructor() { Name = name }, "instructor");
            }
        }
        static void List(string entity)
        {
            if (entity == "Member")
            {
                List<Member> members = rest.Get<Member>("Member");
                foreach (var item in members)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
            }
            else if (entity == "Membership")
            {
                List<Membership> memberships = rest2.Get<Membership>("membership");
                foreach (var item in memberships)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
            }
            else if (entity == "Instructor")
            {
                List<Instructor> instructors = rest3.Get<Instructor>("instructor");
                foreach (var item in instructors)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            if (entity == "Member")
            {
                List<Member> Members = rest.Get<Member>("member");
                foreach (var item in Members)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
                Console.Write("Enter Member's ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "member");
            }
            else if (entity == "Membership")
            {
                List<Membership> Memberships = rest2.Get<Membership>("membership");
                foreach (var item in Memberships)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
                Console.Write("Enter Membership's ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest2.Delete(id, "Membership");
            }
            else if(entity == "Instructor")
            {
                List<Instructor> Instructors = rest3.Get<Instructor>("instructor");
                foreach (var item in Instructors)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
                Console.Write("Enter Instructor's ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest3.Delete(id, "instructor");
            }
            else if (entity == "MaleFemaleCount")
            {
                List<object> count = rest.Get<object>("stat/MaleFemaleCount");
                foreach (var item in count)
                {
                    Console.WriteLine(item);
                }
            }
            else if (entity == "InstructorClientCount")
            {
                List<object> count = rest.Get<object>("stat/InstructorClientCount");
                foreach (var item in count)
                {
                    Console.WriteLine(item);
                }
            }
            else if (entity == "MemberTypeCount")
            {
                List<object> count = rest.Get<object>("stat/MemberTypeCount");
                foreach (var item in count)
                {
                    Console.WriteLine(item);
                }
            }
            else if (entity == "AverageFeeByGender")
            {
                List<object> average = rest.Get<object>("stat/AverageFeeByGender");
                foreach (var item in average)
                {
                    Console.WriteLine(item);
                }
            }
            else if (entity == "ActiveMembersAverageAgeAndCount")
            {
                List<object> average = rest.Get<object>("stat/ActiveMembersAverageAgeAndCount");
                foreach (var item in average)
                {
                    Console.WriteLine(item);
                }
            }
        }
        static void Update(string entity)
        {
            if (entity == "Member")
            {
                List<Member> Members = rest.Get<Member>("member");
                foreach (var item in Members)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
                Console.Write("Enter Member's ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Member one = rest.Get<Member>(id, "member");
                Console.Write($"New name [old: {one.Name}]: ");
                string title = Console.ReadLine();
                one.Name = title;
                rest.Put(one, "member");
            }
            else if (entity == "Membership")
            {
                List<Membership> Memberships = rest2.Get<Membership>("membership");
                foreach (var item in Memberships)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
                Console.Write("Enter Membership's ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Membership one = rest2.Get<Membership>(id, "membership");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest2.Put(one, "membership");
            }
            else
            {
                List<Instructor> Instructors = rest3.Get<Instructor>("instructor");
                foreach (var item in Instructors)
                {
                    Console.WriteLine(item.Id + " - " + item.Name);
                }
                Console.Write("Enter Instructor's ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Instructor one = rest3.Get<Instructor>(id, "instructor");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest3.Put(one, "instructor");
            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:63312/", "member");
            rest2 = new RestService("http://localhost:63312/", "membership");
            rest3 = new RestService("http://localhost:63312/", "instructor");

            var membershipSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Membership"))
                .Add("Create", () => Create("Membership"))
                .Add("Delete", () => Delete("Membership"))
                .Add("Update", () => Update("Membership"))
                .Add("Exit", ConsoleMenu.Close);


            var instructorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Instructor"))
                .Add("Create", () => Create("Instructor"))
                .Add("Delete", () => Delete("Instructor"))
                .Add("Update", () => Update("Instructor"))
                .Add("Exit", ConsoleMenu.Close);


            var memberSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Member"))
                .Add("Create", () => Create("Member"))
                .Add("Delete", () => Delete("Member"))
                .Add("Update", () => Update("Member"))
                .Add("Exit", ConsoleMenu.Close);

            var nonCrudMenu = new ConsoleMenu(args, level: 1)
                .Add("MaleFemaleCount", () => List("MaleFemaleCount"))
                .Add("InstructorClientCount", () => List("InstructorClientCount"))
                .Add("MemberTypeCount", () => List("MemberTypeCount"))
                .Add("AverageFeeByGender", () => List("AverageFeeByGender"))
                .Add("ActiveMembersAverageAgeAndCount", () => List("ActiveMembersAverageAgeAndCount"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Members", () => memberSubMenu.Show())
                .Add("Membership", () => membershipSubMenu.Show())
                .Add("Instructor", () => instructorSubMenu.Show())
                .Add("NonCrudMenu", () => nonCrudMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}