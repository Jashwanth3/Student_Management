using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    public class StudentRepository//Data Accesss Class
    {
        private readonly string connString = "Server=WKSPUN05GTR1013;Database=STUDENTDB;Trusted_Connection=True";
        public void AddStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = $"INSERT INTO STUDENTS VALUES(@NAME,@AGE,@EMAIL)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NAME", student.Name);
                cmd.Parameters.AddWithValue("@AGE", student.Age);
                cmd.Parameters.AddWithValue("@EMAIL", student.Email);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(connString)) 
            {
                string query = "SELECT * FROM STUDENTS";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = Convert.ToInt32(reader["SID"]),
                        Name = Convert.ToString(reader["SNAME"]),
                        Age = Convert.ToInt32(reader["AGE"]),
                        Email = Convert.ToString(reader["EMAIL"])
                    });
                }
            }
            return students;
        }
        public void UpdateStudents(Student student)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE STUDENTS SET SNAME = @NAME, AGE = @AGE , EMAIL = @EMAIL WHERE SID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", student.Id);
                cmd.Parameters.AddWithValue("@NAME",student.Name);
                cmd.Parameters.AddWithValue("@AGE", student.Age);
                cmd.Parameters.AddWithValue("@EMAIL", student.Email);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteStudent(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM STUDENTS WHERE SID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", Id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
