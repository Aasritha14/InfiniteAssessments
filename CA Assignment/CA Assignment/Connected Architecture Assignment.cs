using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Assignment
{
    internal class Connected_Architecture_Assignment
    {
        public void GetTransactions()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=db_ADODOTNET_db;server=(localdb)\\MSSQLLocalDB");
            con.Open();

            Console.WriteLine("Enter start date :");
            DateTime doj1 = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Last date :");
            DateTime doj2 = Convert.ToDateTime(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("sp_GetEMployeeJoinDate", con);
            SqlParameter p1 = new SqlParameter("@d1", doj1);
            SqlParameter p2 = new SqlParameter("@d2", doj2);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]}");
            }
            con.Close();

        }

        public void GetCommonRecords()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=db_ADODOTNET_db;server=(localdb)\\MSSQLLocalDB");
            con.Open();



            Console.WriteLine("Enter Department Id : ");
            int deptId = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("sp_GetCommonEmployeeDepartment");
            SqlParameter p1 = new SqlParameter("@deptId", deptId);
            cmd.Parameters.Add(p1);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}, {dr[1]}, {dr[2]}, {dr[3]}, {dr[4]}, {dr[5]}");
            }
            con.Close();

        }

        public void InsertRecordusingtrans()
        {
            


            SqlTransaction tr = null;
            try
            {
                SqlConnection con = new SqlConnection("Integrated security=true;database=db_ADODOTNET_db;server=(localdb)\\MSSQLLocalDB");
                con.Open();

                tr = con.BeginTransaction();

                Console.WriteLine("Enter Dept id :");
                int Did = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Deptname :");
                string dname = Console.ReadLine();
                SqlCommand cmd1 = new SqlCommand("insert into Department (DeptID,DeptName) values (@deptid,@depname)", con, tr);
                cmd1.Parameters.AddWithValue("@deptid", Did);
                cmd1.Parameters.AddWithValue("@depname", dname);
                int rowaffected = cmd1.ExecuteNonQuery();
                cmd1.Transaction = tr;


                Console.WriteLine("Enter Employee Name :");
                string empname = Console.ReadLine();
                Console.WriteLine("Enter Salary ");
                int sal = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the dateofjoin");
                string doj = Console.ReadLine();
                SqlCommand cmd2 = new SqlCommand("insert into Employee  (EmpName,Salary,DateOfJoin ,DeptID) values (@name,@salary,@date,@deptid)", con, tr);
                cmd2.Parameters.AddWithValue("@name", empname);
                cmd2.Parameters.AddWithValue("@salary", sal);
                cmd2.Parameters.AddWithValue("@date", doj);
                cmd2.Parameters.AddWithValue("@deptid", Did);


                cmd2.Transaction = tr;

                int rowaffected2 = cmd2.ExecuteNonQuery();

                Console.WriteLine("Total record inserted " + rowaffected);
                Console.WriteLine("Total record inserted " + rowaffected2);

                tr.Commit();
                con.Close();

            }
            catch (Exception ex)
            {
                tr.Rollback();
                Console.WriteLine("Values not right , insert again .............");
            }
        }
        public void InsertEmployeeandValidate()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=db_ADODOTNET_db;server=(localdb)\\MSSQLLocalDB");
            con.Open();

            Console.WriteLine("Enter Employee Name :");
            string empname = Console.ReadLine();
            Console.WriteLine("Enter Salary ");
            int sal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the dateofjoin");
            string doj = Console.ReadLine();
            Console.WriteLine("Enter dpetid:");
            int deptId = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("pr_insertemployee", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Empname", empname);
            cmd.Parameters.AddWithValue("@Sal", sal);
            cmd.Parameters.AddWithValue("@doj", doj);
            cmd.Parameters.AddWithValue("@did", deptId);


            int newempid = Convert.ToInt32(cmd.ExecuteScalar());
            Console.WriteLine($"new employee id : {newempid}");


            SqlCommand cmd1 = new SqlCommand($"select * from employee where EmpID={newempid}", con);
            SqlDataReader dr = cmd1.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}  {dr[3]}");
            }

            con.Close();
        }

        public void MultiResultDemo()
        {

            SqlConnection con = new SqlConnection("Integrated Security=true;Database=db_ADODOTNET_db;Server=(localdb)\\MSSQLLocalDB");
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GetEmployeeandDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("Employee :");
            while (dr.Read())
            {

                Console.WriteLine($"{dr["EmpID"]}, {dr["EmpName"]}, {dr["Salary"]}, {((DateTime)dr["DateOfJoin"]).ToString("2025-04-11")}, {dr["DeptID"]}");
            }

            Console.WriteLine("Departments:");
            while (dr.Read())
            {
                Console.WriteLine($"{dr["DeptID"]}, {dr["DeptName"]}");
            }

            dr.Close();
            con.Close();



        }

        public void GetEmployeeDet()
        {
            SqlConnection con = new SqlConnection("Integrated Security=true;Database=db_ADODOTNET_db;Server=(localdb)\\MSSQLLocalDB");
            con.Open();

            Console.Write("Enter Employee Id: ");
            int empId = int.Parse(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("sp_GetEmployeeDet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = empId;

            var pDate = new SqlParameter("@DateOfJoin", SqlDbType.Date) { Direction = ParameterDirection.Output };
            var pDept = new SqlParameter("@Department", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(pDate);
            cmd.Parameters.Add(pDept);

            cmd.ExecuteNonQuery();

            if (pDate.Value == DBNull.Value)
                Console.WriteLine("Employee not found.");
            else
                Console.WriteLine($"EmpID: {empId}, DateOfJoin: {((DateTime)pDate.Value):yyyy-MM-dd}, Department: {pDept.Value}");

            con.Close();
        }
    }
       
}


               



