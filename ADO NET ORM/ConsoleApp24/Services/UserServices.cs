using ADO.NET.Helpers;
using ADO.NET.Services;
using ConsoleApp24.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ConsoleApp24.Services
{
    public class UserServices : IBaseService<Users>
    {


        const int workFactor = 12; 

        public int Create(Users data)
        {
            
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(data.Password, workFactor);

            
            string query = $"INSERT INTO Users (Name, Surname, Password, Username) " +
                           $"VALUES (N'{data.Name}', N'{data.Surname}',N'{data.Username}', '{hashedPassword}')";
            return SqlHelper.Exec(query);
        }
        public List<Users> GetAll()
        {
            DataTable dt = SqlHelper.GetDatas("SELECT * FROM Users");
            List<Users> list = new List<Users>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Users
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Surname = (string)row["Surname"],
                    Username = (string)row["Username"],
                    Password = (string)row["Password"],
                });
            }
            return list;
        }
        
        
        public Users GetById(int id)
        {
            DataTable dt = SqlHelper.GetDatas($"SELECT * FROM Users WHERE ID={id}");
            foreach (DataRow row in dt.Rows)
            {
                Users user = new Users
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Surname = (string)row["Surname"],
                    Username = (string)row["Username"],
                    Password = (string)row["Password"],
                };
                return user;
            }
            return null;
        }

        public Users GetUserByName(string username)
        {
            DataTable dt = SqlHelper.GetDatas($"SELECT * FROM Users WHERE Username = N'{username}'");
            foreach (DataRow row in dt.Rows)
            {
                Users user = new Users
                {
                    Id = (int)row["Id"],
                    Name = (string)row["Name"],
                    Surname = (string)row["Surname"],
                    Password = (string)row["Password"]
                };
                return user;
            }
            return null;
        }

        public bool Authenticate(string username, string password)
        {
           
            Users user = GetUserByName(username);

            
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
        
    }
}
