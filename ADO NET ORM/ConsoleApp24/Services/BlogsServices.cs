using ADO.NET.Helpers;
using ADO.NET.Services;
using ConsoleApp24.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Services
{
    public class BlogsService : IBaseService<Blogs>
    {
        public int Create(Blogs data)
        {
            string query = $"INSERT INTO Blogs VALUES (N'{data.Title}', N'{data.Description}', {data.UserID})";
            return SqlHelper.Exec(query);
        }

        

        public List<Blogs> GetAll()
        {
            DataTable dt = SqlHelper.GetDatas("SELECT * FROM Blogs");
            List<Blogs> list = new List<Blogs>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Blogs
                {
                    Id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Description = (string)row["Description"],
                    UserID = (int)row["UserId"],
                });
            }
            return list;
        }

        public Blogs GetById(int id)
        {
            DataTable dt = SqlHelper.GetDatas($"SELECT * FROM Blogs WHERE ID={id}");
            foreach (DataRow row in dt.Rows)
            {
               Blogs blog = new Blogs
                {
                    Id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Description = (string)row["Description"],
                    UserID = (int)row["UserId"],
                };
                return blog;
            }
            return null;
        }

    }

      
    
}
