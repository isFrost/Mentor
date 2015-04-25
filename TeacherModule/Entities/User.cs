using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherModule
{
    [Serializable]
    class User
    {
        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string userPass;
        public string UserPass
        {
            get { return userPass; }
            set { userPass = value; }
        }
        private string salt;
        public string Salt
        {
            get { return salt; }
            set { salt = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string tel;
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string mail;
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        private string department;
        public string Department
        {
            get { return department; }
            set { department = value; }
        }


        //конструктор по умолчанию
        public User()
        {

        }

        //конструктор для входа
        public User(string UserPass, string Salt)
        {
            this.UserPass = UserPass;
            this.Salt = Salt;
        }

        //конструктор для регистрации
        public User(int UserID, string UserName, string UserPass, string Salt, string Name, string Tel, string Mail, string Department)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.UserPass = UserPass;
            this.Salt = Salt;
            this.Name = Name;
            this.Tel = Tel;
            this.Mail = Mail;
            this.Department = Department;
        }
    }
}
