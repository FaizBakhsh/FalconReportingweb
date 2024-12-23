using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FalconReporting.DbClass
{
    public class db
    {
        string cs =ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static SqlConnection con;
        SqlCommand cmd;
        public db()
        {
            con = new SqlConnection(cs);
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }
        public static void InsertUpdateData(SqlCommand cmd)
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                //return true;
            }
            catch (Exception ex)
            {
                // Response.Write(ex.Message);
                // return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        public static void insert(string query)
        {
            try
            {
                SqlConnection con;
                SqlCommand cmd;
                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                con = new SqlConnection(cs);
                cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return;
            }
            catch (Exception ex)
            {


            }
        }
        public static DataSet funGetDataSet(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con;

                string cs = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                con = new SqlConnection(cs);
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return ds;
        }


        //public static dstrace2 GetData(string query)
        //{
        //    dstrace2 ds = new dstrace2();
        //    try
        //    {
        //        SqlConnection con;

        //        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //        con = new SqlConnection(cs);
        //        SqlCommand com = new SqlCommand(query, con);
        //        SqlDataAdapter da = new SqlDataAdapter(com);
        //        da.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {

        //    }
        //    return ds;
        //}
    }
}