using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace school
{
    class DBManageStaff : IManageStaff
    {
        private readonly string connectionString;

        public DBManageStaff() 
        {
            //get and build configuration file
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //fetch connection string
            this.connectionString = config["connectionString"];
        }

        public void AddStaff(StaffType type, string name, string email, int empCode, string extra)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Proc_AddStaff", conn))
                {
                    cmd.Connection = conn;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@EmpCode", SqlDbType.Int, 0));
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 0));
                    cmd.Parameters.Add(new SqlParameter("@Extra", SqlDbType.VarChar, 50));

                    cmd.Parameters[0].Value = empCode;
                    cmd.Parameters[1].Value = name;
                    cmd.Parameters[2].Value = email;
                    cmd.Parameters[3].Value = (int)type;
                    cmd.Parameters[4].Value = extra;

                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Close();
                }
            }
        }

        public bool Delete(int empCode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Proc_Delete", conn))
                {
                    cmd.Connection = conn;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@EmpCode", SqlDbType.Int, 0));

                    cmd.Parameters[0].Value = empCode;

                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Close();
                }
            }

            return true;
        }

        public List<dynamic> GetAll()
        {

            List<dynamic> Staffs = new List<dynamic>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Proc_GetAll", conn))
                {
                    cmd.Connection = conn;

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Staffs.Add(CreateStaffObject(dr));
                    }

                    dr.Close();
                }
            }

            return Staffs;
        }

        public dynamic GetOne(int empCode)
        {
            dynamic staff = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Proc_GetOne", conn))
                {
                    cmd.Connection = conn;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@EmpCode", SqlDbType.Int, 0));

                    cmd.Parameters[0].Value = empCode;

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        staff = CreateStaffObject(dr);
                    }

                    dr.Close();
                }
            }

            return staff;
        }

        public bool Update(int empCode, string name, string email, string extra)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();

                using (SqlCommand cmd = new SqlCommand("Proc_Update", conn))
                {
                    cmd.Connection = conn;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@EmpCode", SqlDbType.Int, 0));
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@Extra", SqlDbType.VarChar, 50));

                    cmd.Parameters[0].Value = empCode;
                    cmd.Parameters[1].Value = name;
                    cmd.Parameters[2].Value = email;
                    cmd.Parameters[3].Value = extra;

                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Close();
                }
            }

            return true;
        }

        public dynamic CreateStaffObject(SqlDataReader dr)
        {
            dynamic staff = null;

            if (int.Parse(dr["Type"].ToString()) == 1)
            {
                staff = new Teacher(dr["Name"].ToString(), dr["Email"].ToString(), int.Parse(dr["EmpCode"].ToString()), dr["Subject"].ToString());
            }
            else if (int.Parse(dr["Type"].ToString()) == 2)
            {
                staff = new Support(dr["Name"].ToString(), dr["Email"].ToString(), int.Parse(dr["EmpCode"].ToString()), dr["Department"].ToString());
            }
            else if (int.Parse(dr["Type"].ToString()) == 3)
            {
                staff = new Administartor(dr["Name"].ToString(), dr["Email"].ToString(), int.Parse(dr["EmpCode"].ToString()), dr["Role"].ToString());
            }

            return staff;
        }
    }
}
