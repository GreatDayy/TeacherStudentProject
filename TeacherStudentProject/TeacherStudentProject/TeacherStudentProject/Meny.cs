using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeacherStudentProject
{
    public class Meny
    {
        public static void MenyList()
        {
            Console.WriteLine("Hello And Welcome to SchoolSoft!");
            while (true)
            {
                ShowMenyList();
                int userInput = int.Parse(Console.ReadLine());
                ControllInput(userInput);

                School.ReadSchool();
            }
        }

        public static void ShowMenyList()
        {
            Console.WriteLine("********************Meny********************");
            Console.WriteLine("Press 1 to Create New School");
            Console.WriteLine("Press 2 to Update School Name"); //This will only be able to happen if School Exists
            Console.WriteLine("Press 3 to Create New Teacher");
            Console.WriteLine("Press 4 to Create New Course/also assign a teacher to the course");
            Console.WriteLine("Press 5 to Read All Teacher and their Corresponding Courses");
            Console.WriteLine("Press 6 to Update Teacher ");
            Console.WriteLine("Press 7 to Create a Student");
            Console.WriteLine("Press 8 to Update a Student");
            Console.WriteLine("Press 9 to Delete a Student");
            Console.WriteLine("Press 10 to Delete a Teacher");
            Console.WriteLine("Press 11 to Update a Course");
            Console.WriteLine("Press 12 to Delete a Course");
            Console.WriteLine("Press 13 get all students and their corresponding Courses");
            Console.WriteLine("Press 14 Delete School");






            //This will only be able to happen if School Exists
            //This will only be able to happen if School Exists



            //This will only be able to happen if School Exists

            //Console.WriteLine("Press 3 to Create New Course"); //This will only be able to happen if School Exits
            //Console.WriteLine("Press 4 to Create New Student");
            //Console.WriteLine("Press 5 to Assign Teacher to a Course");
            //Console.WriteLine("Press 6 to Assign Student to a Course");
            //Console.WriteLine("Press 7 to Show All Teachers and their Courses");
            //Console.WriteLine("Press 8 to Show All Students and their Courses");
        }
        public static void ControllInput(int userInput)
        {
            try
            {

                if (userInput == 1)
                {
                    //Activate this method to create company, but before that check if school already exists
                    
                    var alreadyExists = School.SchoolExist();
                    if (alreadyExists != true)
                    {
                        Console.WriteLine("Please Write The School Name: Notice if you delete the School, all data will be lost");
                        string Name = Console.ReadLine();
                        School.CreateSchool(Name);
                    }
                    else
                    {
                        Console.WriteLine("En Skola Existerar redan");
                    }

                } 

                else if(userInput == 2)
                {
                    var alreadyExists = School.SchoolExist();
                    if (alreadyExists == true)
                    {
                         
                        Console.Write("Please Write the New Name for: ");
                        School.ReadSchool();
                        string Name = Console.ReadLine();
                        School.UpdateSchool(Name);
                        Console.Write("The new Name of the school is: ");
                        School.ReadSchool();


                    }
                    else
                    {
                        Console.WriteLine("There isnt a school to change");
                    }

                } 
                else if(userInput == 3)
                {
                    Console.WriteLine("Write The Name of the New Teacher");
                    string newName = Console.ReadLine();
                    Teacher.CreateTeacher(newName);
                }
                else if(userInput == 4)
                {
                    //Innan jag frågar om att skriva lärarens namn så måste jag visa först en lista på lärare
                    Console.WriteLine("This is a list of all Teachers");
                    Teacher.PrintTeachers();
                    //Then I would like to ask for the Name of the Teacher
                    Console.WriteLine("Please Write the Name of the Teacher");
                    string TeachersName = Console.ReadLine();
                    Console.WriteLine("Please Write The Name of the New course, you would like to Create");
                    string CourseName = Console.ReadLine();
                    Course.CreateCourse(TeachersName, CourseName);

                    //Print out the Course and the Teacher assign to it
                    TeacherCourses.PrintTeacherAndTheirCourses();
                }
                else if (userInput == 5)
                {
                    Console.WriteLine("This is a list of all Teachers and their corresponding Courses");
                    TeacherCourses.PrintTeacherAndTheirCourses();

                }
                else if(userInput == 6)
                {
                    Console.WriteLine("This is a list of all teachers existing in the System:");
                    Teacher.PrintTeachers();
                    Console.WriteLine("Please Choose the correct ID inorder to update that specific Teacher! :)");
                    int TeacherID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the New Name for the Teacher");
                    string NewName = Console.ReadLine();
                    Teacher.UpdateTeacher(TeacherID, NewName);

                    Console.WriteLine("**************Updated LIST *******************");
                    Teacher.PrintTeachers();







                }
                else if(userInput == 7)
                {
                    //There must be a course in order for a student to Exit
                    Course.printCourses();
                    Console.WriteLine("Please Enter the Course You Want to Assign the Student to:");
                    int CourseId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter the new Students Name! :)");
                    string StudentName = Console.ReadLine();
                    Student.CreateStudent(StudentName, CourseId);

                }
                else if(userInput == 8)
                {
                    //Show A list of all students first
                    Student.PrintOutStudents();
                    Console.WriteLine("Please Enter the Id of the Student You want to Change:");
                    int studentID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter the New Name you would like to assign to the new Student");
                    string newName = Console.ReadLine();
                    Student.updateStudent(newName, studentID);
                    Console.WriteLine("**************Updated Student List*****************");
                    Student.PrintOutStudents();


                }
                else if(userInput == 9)
                {
                    //First show a list of all students and their corresponding Courses
                    Student.PrintOutStudents();
                    Console.WriteLine("Please Write The Correct ID: to Delete a student from the System");
                    int studentID = int.Parse(Console.ReadLine());
                    Student.DeleteStudent(studentID);
                    Console.WriteLine("Students list is updated after the delete");
                    Student.PrintOutStudents();

                }
                else if(userInput == 10)
                {
                    //Get a list of all Teacher
                    TeacherCourses.PrintTeacherAndTheirCourses();
                    Console.WriteLine("Please Choose the Correct Teacher ID in order to Delete a teacher");
                    int TeacherID = int.Parse(Console.ReadLine());
                    Teacher.DeleteTeacher(TeacherID);
                    Console.WriteLine("************ Updated Teacher List****************");
                    TeacherCourses.PrintTeacherAndTheirCourses();



                }
                else if(userInput == 11)
                {
                    //Give a list of all courses before input
                    Course.printCourses();
                    Console.WriteLine("Please write the ID of the course you want to update :)!");
                    int courseID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write the name of the new Course!");
                    string newCourseName = Console.ReadLine();
                    Course.UpdateCourse(newCourseName,courseID);
                    Console.WriteLine("*********Updated Course List********");
                    Course.printCourses();

                }
                else if (userInput == 12)
                {
                    //Visa en lista på alla kurser med ID
                    Student.getAllStudentAndCourses();
                    Console.WriteLine("Please Choose the Correct ID of the Course you would like to Delete");
                    int courseID = int.Parse(Console.ReadLine());
                    Course.Delete(courseID);
                    Console.WriteLine("**************After the Delete****************");
                    Course.printCourses();



                }
                else if (userInput == 13)
                {
                    Student.getAllStudentAndCourses();
                }
                else if(userInput == 14)
                {
                    School.ReadSchool();
                    Console.WriteLine("Skriv in skolans ID");
                    int id = int.Parse(Console.ReadLine());
                    School.DeleteSchool(id);

                }

            }

            catch (Exception ex)
            {

                Console.WriteLine("Error Message" + ex);
            }

        }
        
    }
}
