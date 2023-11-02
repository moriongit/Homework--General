using System;
using System.Text.RegularExpressions;
using MyProject.Exceptions;

namespace MyProject.Models
{
    public class User
    {
        private string name;
        
        
        

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 2 || value.Length > 30)
                    throw new InvalidNameException("Name must be between 2 and 30 characters.");
                name = value;
            }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0 )
                    throw new InvalidAgeException("Age must be a not negative or zero");
                age = value;
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                //duzunu desem burda regex hissesinin mentiqini anladim ancaq, tekrar yazasi olsam internetden baxmali olacam
                string strRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]
                {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";
                Regex re = new Regex(strRegex);
                if (!re.IsMatch(value))
                    throw new InvalidPhoneFormatException("Invalid phone number format, you should use 10 numbers only");
                phoneNumber = value;
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                //regexin mentiqini yene basa dusmusem, sadece olaraq tekrar yazasi olsam internetden tekrar baxmali olacam
                //?= isaresi string boyunca yoxlamagi sorusur, A-Z uppercase A-Zi , \d 0-9la eyni seydi reqemleri yoxlayir
                if (value.Length < 8 || !Regex.IsMatch(value, @"^(?=.*[A-Z])(?=.*\d)"))
                    throw new PasswordException("Password must be at least 8 characters long, contain at least one uppercase letter and one digit.");
                password = value;
            }
        }
    }
}