using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WCF.Classes;
using WCF.Interfaces;

namespace WCF
{
    public class UserService : IUser
    {
        public List<UserDTO> users = null;
        public List<ConfirmCodeDTO> confirmCodes = null;
        public UserService()
        {
            users = new List<UserDTO>();
            confirmCodes = new List<ConfirmCodeDTO>();
        }

      

        public void Add_Friend(int your_id, int friend_id)
        {
            users.FirstOrDefault(x => x.Id == your_id).Friends.Add(users.FirstOrDefault(x => x.Id == friend_id));
        }

     
        public void Add_Room(int your_id, int room_id)
        {
           //users.FirstOrDefault(x=> x.Id == your_id).Rooms.Add()
        }

        public bool Confirming(int user_id, int Code)
        {
            ConfirmCodeDTO confirmCode = new ConfirmCodeDTO();
            foreach(var el in confirmCodes)
            {
                using (StreamWriter sw = new StreamWriter("log.txt"))
                {
                    sw.WriteLine("USER_ID: " + el.user.Id);
                }
                if (el.user.Id==user_id && el.code==Code)
                {
                   
                    foreach(var _el in users)
                    {
                        if(_el.Id==user_id)
                        {
                            _el.IsConfirmed = true;
                            confirmCode = el;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

     

        public UserDTO Registration(string Email, string Password, string Login)
        {
        
            bool isExist = false;
            foreach (var el in users)
                if (Email.ToLower() == el.Email.ToLower() || Login.ToLower() == el.Login.ToLower())
                    isExist = true;
            if (isExist == false)
            {
                Random random = new Random();
                int code = random.Next(1111, 9999);
                UserDTO u = new UserDTO() { Id=code, Email = Email, Login = Login, Friends = null, IsConfirmed = false, Password = Password, Rooms = null };

                users.Add(u);
         
                MailService mail = new MailService();
                mail.SendCode(u, code);

                #region GavnoCode
                //List<ConfirmJSON> confirms = new List<ConfirmJSON>();
                //ConfirmJSON confirm = new ConfirmJSON() { user_id=u.Id, code = code };



                //string path = @"C:\Users\Root\Source\Repos\IvanTymoschuk\MyChat\WCF\WCF\bin\Debug\ConfirmCode.json";
                //if (File.Exists(path) == false)
                //    File.Create(path);

                //string json = File.ReadAllText(path);
                //List<ConfirmJSON> ConfirmsCodes = null;
                //ConfirmsCodes = JsonConvert.DeserializeObject<List<ConfirmJSON>>(json);
                //if(ConfirmsCodes==null)
                //{
                //    confirms.Add(confirm);
                //    json = JsonConvert.SerializeObject(confirms);
                //    File.WriteAllText(path, json);
                //    return u;
                //}
                //foreach (ConfirmJSON el in ConfirmsCodes)
                //{
                //  confirms.Add(el);
                //}
                //confirms.Add(confirm);
                //json = JsonConvert.SerializeObject(confirms);
                //File.WriteAllText(path, json);
                #endregion

                confirmCodes.Add(new ConfirmCodeDTO() { Id = code, code = code, user = u });

                return u;

            }
            else
                return null;
        }

        public void RemoveFriend(int your_id, int friend_id)
        {
            users.FirstOrDefault(x => x.Id == your_id).Friends.Remove(users.FirstOrDefault(x => x.Id == friend_id));
        }

        public void RemoveRoom(int your_id, int room_id)
        {
          // users.FirstOrDefault(x => x.Id == your_id).Rooms.Remove(users.FirstOrDefault(x => x.Id == friend_id));
        }

        public bool ResendCode(int user_id)
        {
           foreach(var el in confirmCodes)
            {
                if (el.user.Id==user_id)
                {
                    MailService mail = new MailService();
                    mail.SendCode(el.user, el.code);
                    return true;
                }
            }
            return false;
        }

        public UserDTO SignIn(string Email, string password)
        {
          
           // users.Add(new UserDTO() { Email = "istep.andriy@gmail.com", Friends = null, Id = 1, IsConfirmed = true, Login = "Admin", Password = "Admin", Rooms = null });
            foreach(var el in users)
            {
                if (el.Login.ToLower() == Email.ToLower() && el.Password == password)
                {
                    return el;
                }
            }
            return null;
        }

        IEnumerable<UserDTO> IUser.getSeachPeople(string Name)
        {
            List<UserDTO> SearchUsers = new List<UserDTO>();

            foreach (var el in users)
            {
                if(el.Login.Contains(Name)==true)
                {
                    SearchUsers.Add(el);
                }
            }
            return SearchUsers;
        }
    }
}
