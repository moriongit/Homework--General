using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_USER_Console_App_Class_task.Models
{
    public class Employee
    {
        private string _name, _surname, _username;
        byte _age;

        public string Username
        {
            get => _username;
            set
            {
                if (String.IsNullOrWhiteSpace(this.Name) || String.IsNullOrEmpty(this.Surname)) 
                {
                    this._username = "none";
                }
                else
                {
                    this._username = this.Name + "_" + this.Surname;
                }
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (!(String.IsNullOrWhiteSpace(value)))
                {
                    value = value.Trim();
                    this._name = Char.ToUpper(value[0]) + value.Substring(1);
                    
                }
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                if (!(String.IsNullOrWhiteSpace(value)))
                {
                    value = value.Trim();
                    this._surname = Char.ToUpper(value[0]) + value.Substring(1);
                    
                }
            }
        }
        public byte Age
        {
            get => this._age;
            set
            {
                if (value > 0) this._age = value;
                else this._age = 1;
            }
        }

        public Employee(string Name, string Surname, byte Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Username = "update";
        }

        public override string ToString()
        {
            return this.Username + " at age " + this.Age;
        }
    }
    public class Company
    {
        string _companyName;
        Employee[] _employees;


        public Company(string CompanyName)
        {
            this._companyName = CompanyName;
            this._employees = new Employee[0];
        }

        public override string ToString()
        {
            return this._companyName;
        }

        public void AddUser(Employee user)
        {
            Array.Resize(ref this._employees, this._employees.Length + 1);
            this._employees[this._employees.Length - 1] = user;
        }
        
        public Employee GetUser(string user)
        {
            for (int i = 0; i < this._employees.Length; i++)
            {
                if (_employees[i].Username == user)
                {
                    return this._employees[i];
                }

            }

            Console.WriteLine(user + "is not in the list");
            return null;
        }
        public Employee[] GetAllUsers()
        {

            return _employees;
        }

        public void RemoveUser(string user)
        {
            int RemoveIndex = -1;
            for (int i = 0; i < this._employees.Length; i++)
            {
                if (_employees[i].Username == user)
                {
                    RemoveIndex = i;
                    break;
                }

            }

            if (RemoveIndex >= 0)
            {
                int index = 0;
                Employee[] newArray = new Employee[_employees.Length - 1];

                for (int i = 0; i < newArray.Length; i++)
                {
                    if (RemoveIndex == i)
                    {
                        continue;
                    }
                    newArray[index] = this._employees[i];
                    index++;
                }

                _employees = newArray;
            }
            else
            {
                Console.WriteLine(user + " is not in the list");
            }
        }

        public void UpdateUser(string user)
        {
            int index = -1;
            for (int i = 0; i < this._employees.Length; i++)
            {
                if (_employees[i].Username == user)
                {
                    index = i; break;
                }

            }
            
            if (index >= 0)
            {
                 Console.WriteLine("New Name");
                 Console.WriteLine("New Surame");
                 Console.WriteLine("New Age");
                 Console.Write("Pick an option ");
                 int input = Convert.ToInt32(Console.ReadLine());


                    switch (input)
                    {
                        case 1:
                            Console.Write("Enter Name: ");
                            _employees[index].Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Enter Surname: ");
                            _employees[index].Surname = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Enter Age: ");
                            input = Convert.ToInt32(Console.ReadLine());
                            _employees[index].Age = Convert.ToByte(input);
                            break;
                    }
                
                }
            }
        }
    }

