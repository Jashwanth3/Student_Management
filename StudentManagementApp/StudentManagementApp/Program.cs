using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using StudentLibrary;

namespace StudentManagementApp
{
    public class Program
    {
        static StudentRepository repo = new StudentRepository();
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("\n !!!!Student Management System!!!! ");
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");   
                Console.WriteLine("->1. Add Student\n->2. Update Student\n->3. Delete Student\n->4. View Students\n->5. Exit");
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
                Console.WriteLine("Enter your choice: ");
                int i = Convert.ToInt32(Console.ReadLine());
                switch(i)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        UpdateStudent();
                        break;
                    case 3:
                        DeleteStudent();                     
                        break;
                    case 4:
                        ViewStudents();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("!!!!Enter Correct Value!!!!");
                        break;
                }
            }
        }
        public static void AddStudent()
        {
            Console.WriteLine("Enter the following details of student: ");
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();
            repo.AddStudent(new Student { Name = name , Age = age , Email = email});
            Console.WriteLine("+-+-+ Student Added Successfully +-+-+");
        }
        public static void ViewStudents()
        {           
            List<Student> students = repo.GetAllStudents();            
            Console.WriteLine();
            Console.WriteLine("Total Students: " + students.Count);
            Console.WriteLine("Student Details: ");
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            foreach (Student s in students)
            {
                Console.WriteLine("Id: "+ s.Id +"\t Name: " + s.Name + "\t Age: " + s.Age + "\t Email: " + s.Email);
            }
            Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            Console.WriteLine();
        }
        public static void UpdateStudent()
        {
            Console.WriteLine("Enter Student ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the new name: ");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter the new age: ");
            int newAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the new email: ");
            string newEmail = Console.ReadLine();
            repo.UpdateStudents(new Student { Id = id, Name = newName , Age = newAge , Email = newEmail});
            Console.WriteLine("+-+-+ Student Updated Successfully +-+-+");
        }
        public static void DeleteStudent()
        {
            Console.WriteLine("Enter the ID of student to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            repo.DeleteStudent(id);
            Console.WriteLine("+-+-+ Student Deleted Succesfully +-+-+");
        }
    }
}
