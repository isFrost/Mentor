using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Windows;


namespace TeacherModule
{
    class UserManager
    {
        // метод создает нового пользователя
        public static User CreateUser(User user)
        {


            List<User> list = new List<User>();

            string fileName = String.Format(@"E:\w3schools_demo\VirtualClassroom\lg.bin");

            try
            {
                if (File.Exists(fileName))
                {
                    using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        list = (List<User>)formatter.Deserialize(stream);
                        int lastUserID = 0;
                        foreach (User u in list)
                        {
                            if (u.UserName.Equals(user.UserName))
                            {
                                MessageBox.Show("Этот логин уже занят"); break;
                            }

                            if (u.UserID > lastUserID)
                                lastUserID = u.UserID;
                        }
                        user.UserID = lastUserID + 1;
                        list.Add(user);
                        formatter.Serialize(stream, list);
                        return user;
                    }
                }
                else
                {
                    using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        //File.Create(fileName);
                        user.UserID = 1;
                        list.Add(user);
                        formatter.Serialize(stream, list);
                        return user;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString());
                return new User("", "");
            }

        }
        //ищет пльзователя по UserName
        public static User FindUser(User userToFind)
        {
            string fileName = String.Format(@"E:\w3schools_demo\VirtualClassroom\lg.bin");

            try
            {
                using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    List<User> list = (List<User>)formatter.Deserialize(stream);

                    foreach (User u in list)
                    {
                        if (userToFind.UserName.Equals(u.UserName))
                        {
                            return u;
                        }
                    }

                    MessageBox.Show("Пользователь не найден");
                    return new User("", "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString());
                return new User("", "");
            }
        }
        //удаляетт пользователя по UserName
        public static void deleteUser(User userToDelete)
        {
            string fileName = String.Format(@"E:\w3schools_demo\VirtualClassroom\lg.bin");

            try
            {

                using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Delete))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<User> list = (List<User>)formatter.Deserialize(stream);

                    foreach (User u in list)
                    {
                        if (userToDelete.UserName.Equals(u.UserName))
                        {
                            list.Remove(u);
                            formatter.Serialize(stream, list); break;
                        }
                    }

                    MessageBox.Show("Пользователь не найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString());
            }
        }
    }
}
