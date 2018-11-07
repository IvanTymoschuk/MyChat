﻿using Newtonsoft.Json;
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
    public class Services : IUser
    {
        public List<UserDTO> users;
        
        public Services()
        {
            users = new List<UserDTO>();
        }

        public bool Add_Friend(string FriendLogin)
        {
            throw new NotImplementedException();
        }

        public void Add_Room(RoomDTO room)
        {
            throw new NotImplementedException();
        }

        public bool Confirming(int user_id, int Code)
        {

          //  users = new List<UserDTO>();
            users.Add(Registration("qwwer@qwqe", "123", "123"));
            
            string path = @"C:\Users\Root\Source\Repos\IvanTymoschuk\MyChat\WCF\WCF\bin\Debug\ConfirmCode.json";
            List<ConfirmJSON> ConfirmsCodes = null;
            string json = File.ReadAllText(path);
            ConfirmsCodes = JsonConvert.DeserializeObject<List<ConfirmJSON>>(json);


            foreach(var el in ConfirmsCodes)
            {
                if (el.code==Code)
                {
                    foreach(var _el in users)
                    {
                        if(_el.Id==user_id)
                        {
                            _el.IsConfirmed = true;
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
                int code = random.Next(11111, 99999);
                UserDTO u = new UserDTO() { Id=code, Email = Email, Login = Login, Friends = null, IsConfirmed = false, Password = Password, Rooms = null };

                users.Add(u);

                MailService mail = new MailService();
                mail.SendCode(u, code);

                List<ConfirmJSON> confirms = new List<ConfirmJSON>();
                ConfirmJSON confirm = new ConfirmJSON() { user_id=u.Id, code = code };



                string path = @"C:\Users\Root\Source\Repos\IvanTymoschuk\MyChat\WCF\WCF\bin\Debug\ConfirmCode.json";
                if (File.Exists(path) == false)
                    File.Create(path);

                string json = File.ReadAllText(path);
                List<ConfirmJSON> ConfirmsCodes = null;
                ConfirmsCodes = JsonConvert.DeserializeObject<List<ConfirmJSON>>(json);
                if(ConfirmsCodes==null)
                {
                    confirms.Add(confirm);
                    json = JsonConvert.SerializeObject(confirms);
                    File.WriteAllText(path, json);
                    return u;
                }
                foreach (ConfirmJSON el in ConfirmsCodes)
                {
                  confirms.Add(el);
                }
                confirms.Add(confirm);
                json = JsonConvert.SerializeObject(confirms);
                File.WriteAllText(path, json);

                return u;

            }
            else
                return null;
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
    }
}
