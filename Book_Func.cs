using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library.Models.Book
{
    public class Book_Func
    {

        string conn = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;

        public string Insert_Color(Book_Prop prop)
        {
            try
            {
                int count = 0;
                SqlConnection con = new SqlConnection(conn);
                string scmd1 = "Select count(*) from Mas_Book where BookName ='" + prop.BookName + "'  ";
                SqlCommand cmd1 = new SqlCommand(scmd1, con);
                con.Open();
                count = Convert.ToInt32(cmd1.ExecuteScalar());
                con.Close();
                if (count == 0)
                {

                    string scmd = @"Insert into Mas_Book (BookName,AuthorName,Year) Values('" + prop.BookName + "','" + prop.AuthorName + "','"+prop.Year+"')";

                    SqlCommand cmd = new SqlCommand(scmd, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "Inserted Successfully!";
                }
                else
                {
                    return "Already Exists!";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Tuple<List<Book_Prop>, int> GetFin(string search, int pageindex, int pagesize)
        {
            try
            {
                var skip = pagesize * (pageindex - 1);
                SqlConnection con = new SqlConnection(conn);
                List<Book_Prop> list = new List<Book_Prop>();
                string scmd = @"select * from Mas_Book
where (BookName = @Search or @Search = '') or (AuthorName = @Search or @Search = '')";

                SqlCommand cmd = new SqlCommand(scmd, con);
                cmd.Parameters.AddWithValue("@Search", search);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var Rowdata = dt.Rows[i];
                        Book_Prop prop = new Book_Prop();
                        prop.ID = Convert.ToInt32(Rowdata["ID"]);
                        prop.BookName = Convert.ToString(Rowdata["BookName"]);
                        prop.AuthorName = Convert.ToString(Rowdata["AuthorName"]);
                        prop.Year = Convert.ToString(Rowdata["Year"]);

                        list.Add(prop);
                    }
                }
                //  return list;
                int totalcount = list.Count;
                return Tuple.Create(list.OrderBy(a => a.ID).Skip(skip).Take(pagesize).ToList(), totalcount);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public List<Color_Prop> GetColor(string Search)
        //{
        //    try
        //    {


        //        if (dt.Rows.Count != 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                var Rowdata = dt.Rows[i];
        //                Color_Prop prop = new Color_Prop();
        //                prop.Colorid = Convert.ToInt32(Rowdata["Colorid"]);
        //                prop.Colorname = Convert.ToString(Rowdata["Colorname"]);
        //                prop.ColorType = Convert.ToString(Rowdata["ColorType"]);
        //                prop.Isactive = Convert.ToBoolean(Rowdata["Isactive"]);

        //                prop.Createdby = Convert.ToInt32(Rowdata["Createdby"]);
        //                prop.Createddate = Convert.ToDateTime(Rowdata["Createddate"]);
        //                list.Add(prop);

        //            }
        //        }
        //        return list;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

        public string Delete_Color(Book_Prop prop)
        {
            try
            {
                SqlConnection con = new SqlConnection(conn);
                string scmd = @"Delete from Mas_Book where ID='" + prop.ID + "'";
                SqlCommand cmd = new SqlCommand(scmd, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Deleted Successfully!";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Updated_Color(Book_Prop prop)
        {
            try
            {
                int count = 0;
                SqlConnection con = new SqlConnection(conn);

                {
                    if (prop.BookName != prop.BookName)
                    {
                        string scmd1 = "Select count(*) from Mas_Book where BookName ='" + prop.BookName + "'  ";
                        SqlCommand cmd1 = new SqlCommand(scmd1, con);
                        con.Open();
                        count = Convert.ToInt32(cmd1.ExecuteScalar());
                        con.Close();
                    }
                }

                if (count == 0)
                {
                    string scmd = @"Update Mas_Book Set BookName = '" + prop.BookName + "' ,AuthorName='" + prop.AuthorName + "', Year ='" + prop.Year + "'  where ID= '" + prop.ID + "'";
                    SqlCommand cmd = new SqlCommand(scmd, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "Updated Successfully!";
                }
                else
                {
                    return "Already Exists";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

      
        public Book_Prop Retrieve_Color(Book_Prop prop)
        {
            try
            {
                SqlConnection con = new SqlConnection(conn);
                Book_Prop data = new Book_Prop();
                string scmd = "Select * from Mas_Book where ID = '" + prop.ID + "'";
                SqlCommand cmd = new SqlCommand(scmd, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    data.ID = Convert.ToInt32(reader.GetInt32(0));
                    data.BookName = reader.GetValue(1).ToString();
                    data.AuthorName = reader.GetValue(2).ToString();
                    data.Year = reader.GetValue(3).ToString();
                   

                }
                return data;

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
