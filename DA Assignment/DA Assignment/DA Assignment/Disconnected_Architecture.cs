using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DA_Assignment
{
    internal class Disconnected_Architecture
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();// can hold the output (many output)
        SqlDataAdapter da;
        public void PrintAllTheRecords()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=db_ADODOTNET_db;server=(localdb)\\MSSQLLocalDB");

             da = new SqlDataAdapter("select * from Employee", con);

            da.Fill(ds, "emp");

           
            dt = ds.Tables["emp"];

            Console.WriteLine("Employee Records : ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i][0]);
                Console.WriteLine(dt.Rows[i][1]);
                Console.WriteLine(dt.Rows[i][2]);
                Console.WriteLine(dt.Rows[i][3]);
                Console.WriteLine(dt.Rows[i][4]);
              

            }

            
        }

        public void PrintAllDepartment()
        {
            
            SqlConnection con = new SqlConnection("Integrated security=true;database=db_ADODOTNET_db;server=(localdb)\\MSSQLLocalDB");
            ds = new DataSet();
            da = new SqlDataAdapter("Select * from Department", con);

            da.Fill(ds, "Dept");
            dt = ds.Tables["Dept"];

            Console.WriteLine("Department Records : ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i][0]);
                Console.WriteLine(dt.Rows[i][1]);
                Console.WriteLine(dt.Rows[i][2]);
                Console.WriteLine(dt.Rows[i][3]);
                Console.WriteLine(dt.Rows[i][4]);
            }
        }

        public void EmployeeTable()
        {
           DataView dv=new DataView(dt);


            dv.RowFilter = "salary > 47000 and Deptid = 10 and EmpName like 'M%'";

           dv.Sort = "salary asc";

            Console.WriteLine("filtered and sorted Employee Records :");
            foreach (DataRowView item in dv)
            {
                Console.WriteLine(item[0]);
                Console.WriteLine(item[1]);
                Console.WriteLine(item[2]);
                Console.WriteLine(item[3]);
                Console.WriteLine(item[4]);
            }
        }
        //Task-3 
        //Write a code to print to show total no of tables present in dataset

        public void ShowTotal()
        {
            DataTable dt1 = new DataTable("Employees");
            DataTable dt2 = new DataTable("Department");
            

            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
           

            Console.WriteLine("Total Number of Tabes in Dataset : " + ds.Tables.Count);
        }

        //Task-4 
       // Develop a code to copy data of SqlDataReader object To DataTable object and
//print all data using DataTable Object(use Department Table) Hint : use
//dt.Load()

        public void copydata()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=db_ADODOTNET_db;server=(localdb)\\MSSQLLocalDB");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Department",con);

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable("DepartmentData");
            dt.Load(dr);

            con.Close();

            Console.WriteLine("Department Table Data : ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i][0]);
                Console.WriteLine(dt.Rows[i][1]);

            }




        }


        //**Develop a code to display records from customers and orders .   
        //a.Create ds1 object which stores customers details
        //b.Create ds2 object which stores orders details
        //c. Merge ds1 with ds2 using merge method and display records from both the
        //table using ds1**/
        DataTable dt2 = new DataTable();
        DataSet ds2 = new DataSet();
        SqlDataAdapter da2;

        DataTable dt3 = new DataTable();
        DataSet ds3 = new DataSet();
        SqlDataAdapter da3;
        public void customer_Orders_details()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=Custdb;server=(localdb)\\MSSQLLocalDB");

            da2 = new SqlDataAdapter("select * from customers", con);
            ds2 = new DataSet();
            da2.Fill(ds2, "cust");
            dt2 = ds2.Tables["cust"];


            da3 = new SqlDataAdapter("select * from Orders", con);
            ds3 = new DataSet();
            da3.Fill(ds3, "orderTb");
            dt3 = ds3.Tables["orderTb"];


            ds2.Merge(ds3);

            Console.WriteLine("\nCustomers table record...........\n");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Console.WriteLine(dt2.Rows[i][0]);
                Console.WriteLine(dt2.Rows[i][1]);
                Console.WriteLine(dt2.Rows[i][2]);
                Console.WriteLine(dt2.Rows[i][3]);
                Console.WriteLine(dt2.Rows[i][4]);
            }

            Console.WriteLine("\nOrders table record...........\n");

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                Console.WriteLine(dt3.Rows[i][0]);
                Console.WriteLine(dt3.Rows[i][1]);
                Console.WriteLine(dt3.Rows[i][2]);
                Console.WriteLine(dt3.Rows[i][3]);
                Console.WriteLine(dt3.Rows[i][4]);
                Console.WriteLine(dt3.Rows[i][5]);

            }
        }


        //Task-6 
        //Develop a code to Read Data of Xml File(use ds.Read() Method) and print the
        //same in console application

        public void storeinXML()
        {
            ds = new DataSet();
            da.Fill(ds);
            ds.WriteXml("C:\\Users\\deeptisa\\OneDrive - Infinite Computer Solutions (India) Limited\\Desktop\\employee1.xml");
            Console.WriteLine("XML file created successfully\n");
            Console.WriteLine(ds.GetXml());


            Disconnected_Architecture disconnected_Architecture = new Disconnected_Architecture();
            Console.WriteLine("Below Record of Employee table\n");
            disconnected_Architecture.PrintAllTheRecords();

            Console.WriteLine("\nBelow all record of Department table\n");
            disconnected_Architecture.PrintAllDepartmentRecords();

            Console.WriteLine("\nFilter records of employee............\n");
            disconnected_Architecture.EmployeeTable();

            Console.WriteLine("\nOuput of 3rd question...........\n");
            disconnected_Architecture.ShowTotal();

            Console.WriteLine("\nOutput of 4th Question...............\n");
            disconnected_Architecture.copydata();

            Console.WriteLine("\nOutput of 5th Question................\n");
            Console.WriteLine("customer  table record\n");
            disconnected_Architecture.customer_Orders_details();

            Console.WriteLine("\nsame it printing in console also\n");
            disconnected_Architecture.storeinXML();
        }


    }
}
