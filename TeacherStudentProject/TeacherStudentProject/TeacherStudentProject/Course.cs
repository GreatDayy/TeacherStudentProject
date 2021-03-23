using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TeacherStudentProject
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        public int SchoolsId { get; set; }
        public School Schools { get; set; }
        public List<TeacherCourses> TeacherCourses { get; set; }
        //Flera studenter kan vara med i en kurs
        public List<StudentCourses> studentCourses { get; set; } //skapa en mellan tabell student och courses
                                                                 //M -M samband mellan Teacher and Course


        #region createCourse 
        public static void CreateCourse(string TeacherName, string CourseName)
        {
            //1:Show A list of existing Teacher //Get this metod from teacher class 
            //2:let userInput the id of the Teacher 
            //3:if the Id exists assign the found object to the Course
            //4:Show A list of Teacher and their courses

            using(SchoolContext db = new SchoolContext())
            {
                Teacher teacher = db.Teachers.Where(t => t.Name == TeacherName).FirstOrDefault();
                if(teacher != null)
                {
                    //Add New Course and Assign it to a School
                    Course newCourse = new Course();
                    newCourse.Name = CourseName;
                    newCourse.SchoolsId = School.ReturnSchool();
                    db.Courses.Add(newCourse);
                    db.SaveChanges();

                    //Next Step to add the teacher in the course using the middle table

                    TeacherCourses teacherCourses = new TeacherCourses();
                    teacherCourses.CourseId = newCourse.Id;
                    teacherCourses.TeacherId = teacher.Id;
                    db.TeacherCourses.Add(teacherCourses);
                    db.SaveChanges();
                    //

                }
                else
                {
                    Console.WriteLine("There is no Teacher corresponding to that Name");
                }
            }

          




        }
        #endregion
        #region readAllCourses
        public static void printCourses()
        {
            using(SchoolContext db = new SchoolContext())
            {
                List<Course> courseList = db.Courses.ToList();

                foreach (var course in courseList)
                {
                    Console.WriteLine("Course ID: " + course.Id +  " Course Name " + course.Name);
                }
            }
           
        }
        #region getAllStudentInCourse
        public static void getAllStudentInTheCourse()
        {
        }
        #endregion
        #endregion
        #region UpdateCourses
        public static void UpdateCourse(string Name, int CourseID)
        {
            //First get the specfic course and change the name
            using(SchoolContext db = new SchoolContext())
            {
                try
                {
                
                Course course = db.Courses.Where(c => c.Id == CourseID).FirstOrDefault();
                if(course != null)
                {
                    course.Name = Name;
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("There is no Course corresponding to that given ID!");
                }
                  }
                catch (Exception ex)
                {

                    Console.WriteLine("Something Went Wrong with the DB! COURSE", ex); ;
                }
            }
        }


        #endregion

        #region DeleteCourse 
        public static void Delete(int CourseID)
        {
            using(SchoolContext db = new SchoolContext())
            {
                //Om jag radera en kurs då raderar jag läraren från kursen och raderar studenten från system
                //3 Ställen vill jag radera denna på Kurs tabellen, StudentKursTabellen(Måste även hitta 
                //studenten som är kopplat till denna tabell, TeacherKurstabellen
                StudentCourses studentCourses = db.StudentCourses.Where(c => c.CourseID == CourseID).FirstOrDefault();
                TeacherCourses teacherCourses = db.TeacherCourses.Where(c => c.CourseId == CourseID).FirstOrDefault();
                Course course = db.Courses.Where(c => c.Id == CourseID).FirstOrDefault();
                
                if(course != null)
                {
                    //Radera alla mellan tabeller från kursen
                    if(teacherCourses != null)
                    {
                        db.TeacherCourses.Remove(teacherCourses);
                        db.SaveChanges();
                    }

                    if(studentCourses != null)
                    {
                        db.StudentCourses.Remove(studentCourses);
                        db.SaveChanges();
                        //also i want to delete all students that are in that course
                    }

                    db.Courses.Remove(course);
                    db.SaveChanges();

                } 
                else
                {
                    Console.WriteLine("There is no Course that corresponse to that ID");
                }





            }
        }
        #endregion



        //This is third on the ECO chain
    }
}
