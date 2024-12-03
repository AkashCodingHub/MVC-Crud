using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace firstProjectmvc.Models
{

    public class BALUser
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RRP3MVI\\SQLEXPRESS;Initial Catalog=MVCCRUD2;Integrated Security=True;Encrypt=False;");

    
        public void save(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("FirstMvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SaveUser");
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            cmd.Parameters.AddWithValue("@CountryId", obj.CountryId);
            cmd.Parameters.AddWithValue("@StateId", obj.StateId);
            cmd.Parameters.AddWithValue("@CityId", obj.CityId);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateUser(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("FirstMvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UpdateUser");
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            cmd.Parameters.AddWithValue("@CountryId", obj.CountryId);
            cmd.Parameters.AddWithValue("@StateId", obj.StateId);
            cmd.Parameters.AddWithValue("@CityId", obj.CityId);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable Fetch()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("FirstMvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Fetch");
            SqlDataAdapter adpt= new SqlDataAdapter();
            adpt.SelectCommand=cmd;
            DataTable dt=new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        
        public DataTable FetchUserDetails(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("FirstMvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "FetchUserDetails");
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }



        public DataTable DeleteUser(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("FirstMvc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DeleteUser");
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
    }
}