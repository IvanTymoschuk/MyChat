//using LoggerLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF.Classes;
using WCF.Interfaces;
using DAL;
using AutoMapper;
using DAL.Models;

namespace WCF
{
    public class Service : IMessage, IRoom, IUser
    {
        static public List<ConfirmCodeDTO> confirmCodes = null;
        List<UserDTO> users;

        DBase db;
        public Service()
        {
            db = new DBase();
            confirmCodes = new List<ConfirmCodeDTO>();
            //Logger.Log("User Added");
        }









        //=====================================================
        //========================IROOM========================
        //=====================================================



        public void CreateRoom(RoomDTO room)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RoomDTO, Room>());

            Room r = Mapper.Map<RoomDTO, Room>(room);
            db.Rooms.Add(r);
        }

        public void SendMessageAllUsersInRoom(RoomDTO room)
        {
            foreach (var el in room.users)
            {
                el.callback.GetMessage(room.Messages[room.Messages.Count - 1]);
            }
        }















        //=====================================================
        //======================IUSER==========================
        //=====================================================




        public void Add_Friend(int your_id, int friend_id)
        {
            db.Users.FirstOrDefault(x => x.Id == your_id).Friends.Add(db.Users.FirstOrDefault(x => x.Id == friend_id));
            db.SaveChanges();
        }


        public void Add_Room(int your_id, int room_id)
        {
            db.Rooms.FirstOrDefault(x => x.Id == room_id).users.Add(db.Users.FirstOrDefault(x => x.Id == your_id));
            db.SaveChanges();
        }

        public bool Confirming(int user_id, int Code)
        {
            ConfirmCodeDTO confirmCode = new ConfirmCodeDTO();
            foreach (var el in confirmCodes)
            {
                using (StreamWriter sw = new StreamWriter("log.txt"))
                {
                    sw.WriteLine("USER_ID: " + el.user.Id);
                }
                if (el.user.Id == user_id && el.code == Code)
                {

                    foreach (var _el in db.Users)
                    {
                        if (_el.Id == user_id)
                        {
                            _el.IsConfirmed = true;
                            confirmCode = el;
                            db.SaveChanges();
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
            foreach (var el in db.Users)
                if (Email.ToLower() == el.Email.ToLower() || Login.ToLower() == el.Login.ToLower())
                    isExist = true;
            if (isExist == false)
            {
                Random random = new Random();
                int code = random.Next(1111, 9999);
                UserDTO u = new UserDTO() { Id = code, Email = Email, Login = Login, Friends = null, IsConfirmed = false, Password = Password, Rooms = null, callback= OperationContext.Current.GetCallbackChannel<IUserCallback>() };
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());

                User user = Mapper.Map<UserDTO, User>(u);

                //users.Add(u);

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

              
                db.Users.Add(user);
                db.SaveChanges();

                return u;

            }
            else
                return null;
        }

        public void RemoveFriend(int your_id, int friend_id)
        {

            db.Users.FirstOrDefault(x => x.Id == your_id).Friends.Remove(db.Users.FirstOrDefault(x => x.Id == friend_id));
            db.SaveChanges();
        }

        public void RemoveRoom(int your_id, int room_id)
        {
             db.Users.FirstOrDefault(x => x.Id == your_id).Rooms.Remove(db.Rooms.FirstOrDefault(x => x.Id == room_id));
        }

        public bool ResendCode(int user_id)
        {
            foreach (var el in confirmCodes)
            {
                if (el.user.Id == user_id)
                {
                    MailService mail = new MailService();
                    mail.SendCode(el.user, el.code);
                    return true;
                }
            }
            return false;
        }

        public UserDTO SignIn(string EmailOrLogin, string password)
        {
            Mapper.Reset();
            //users1.Add(new UserDTO() { Email = "istep.andriy@gmail.com", Friends = null, Id = 1, IsConfirmed = true, Login = "Admin", Password = "Admin", Rooms = null });
            //users1.Add(new UserDTO() { Email = "istep.andriy12@gmail.com", Friends = null, Id = 12, IsConfirmed = true, Login = "Admin1", Password = "Ad1min1", Rooms = null });
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());

          
            foreach (var el in db.Users)
            {
                if (el.Login == EmailOrLogin || el.Login== EmailOrLogin && el.Password == password)
                {
                    UserDTO user = Mapper.Map<User, UserDTO> (el);
                    return user;
                }
            }
            return null;
        }

        IEnumerable<UserDTO> IUser.getSeachPeople(string Name)
        {

            List<UserDTO> SearchUsers = new List<UserDTO>();
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            foreach (var el in db.Users)
            {
                if (el.Login.Contains(Name) == true)
                {
                    UserDTO user = Mapper.Map<User, UserDTO>(el);
                    SearchUsers.Add(user);
                }
            }
            return SearchUsers;
        }













        //=====================================================
        //========================IMESSAGE=====================
        //=====================================================








        public void SendMessage(string body, RoomDTO room, UserDTO sender, AttachDTO attach = null)
        {

            List<AttachDTO> attaches = null;
            if (attach != null)
            {
                attaches = new List<AttachDTO>();
                attaches.Add(attach);
            }
            MessageDTO message = new MessageDTO() { Body = body, DateTimeSended = DateTime.Now, Room = room, Sender = sender, Attaches = attaches };
            SendMessageAllUsersInRoom(room);
            Mapper.Initialize(cfg => cfg.CreateMap<MessageDTO, Message>());
            Message msg = Mapper.Map<MessageDTO, Message>(message);
            db.Messages.Add(msg);
            db.SaveChanges();
        }

    }
}
