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

        DBase db;
        public Service()
        {
            db = new DBase();
        }


        //=====================================================
        //========================IROOM========================
        //=====================================================



        public void CreateRoom(RoomDTO room)
        {
            try
            {
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<RoomDTO, Room>());

                Room r = Mapper.Map<RoomDTO, Room>(room);
                db.Rooms.Add(r);
                db.SaveChanges();
            }
            catch (Exception) { }
        }

        public void SendMessageAllUsersInRoom(RoomDTO room)
        {
            try
            {
                foreach (var el in room.Users)
                {
                    el.callback.GetMessage(room.Messages[room.Messages.Count - 1]);
                }
            }
            catch (Exception) { }
        }

        public void ExitFromRoom(int your_id, int room_id)
        {
            try
            {
                db.Users.FirstOrDefault(x => x.Id == your_id).Rooms.Remove(db.Rooms.FirstOrDefault(x => x.Id == room_id));
                db.SaveChanges();
            }
            catch (Exception) { }
        }

        public void JoinInRoom(int your_id, int room_id)
        {
            try
            {
                db.Rooms.FirstOrDefault(x => x.Id == room_id).Users.Add(db.Users.FirstOrDefault(x => x.Id == your_id));
                db.SaveChanges();
            }
            catch (Exception) { }
        }













        //=====================================================
        //======================IUSER==========================
        //=====================================================




        public void Add_Friend(int your_id, int friend_id)
        {
            try
            {
                db.Users.FirstOrDefault(x => x.Id == your_id).Friends.Add(db.Users.FirstOrDefault(x => x.Id == friend_id));
                db.SaveChanges();
            }
            catch (Exception) {  }
        }


        //public void Add_Room(int your_id, int room_id)
        //{
        //    db.Rooms.FirstOrDefault(x => x.Id == room_id).users.Add(db.Users.FirstOrDefault(x => x.Id == your_id));
        //    db.SaveChanges();
        //}

        public bool Confirming(int user_id, int Code)
        {
            try
            {
                foreach (var el in db.ConfirmCodes)
                {
                    if (el.user.Id == user_id && el.code == Code)
                    {
                        db.Users.FirstOrDefault(x => x.Id == user_id).IsConfirmed = true;
                        db.SaveChanges();
                        return true;

                    }
                }
                return false;
            }
            catch (Exception) { return false; }
        }



        public UserDTO Registration(string Email,string Name, string Password, string Login)
        {
            try
            {
                bool isExist = false;
                foreach (var el in db.Users)
                    if (Email.ToLower() == el.Email.ToLower() || Login.ToLower() == el.Login.ToLower())
                        isExist = true;
                if (isExist == false)
                {
                    Random random = new Random();
                    int code = random.Next(1111, 9999);
                    UserDTO u = new UserDTO() { Name = Name, Email = Email, Login = Login, Friends = null, IsConfirmed = false, Password = Password, Rooms = null, callback = OperationContext.Current.GetCallbackChannel<IUserCallback>() };
                    Mapper.Reset();
                    Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());

                    User user = Mapper.Map<UserDTO, User>(u);

                    //users.Add(u);

                    MailService mail = new MailService();
                    mail.SendCode(u, code);
              
                  
                    db.Users.Add(user);
                    db.ConfirmCodes.Add(new ConfirmCode() { code = code, user = user });
                    db.SaveChanges();

                    return u;

                }
                else
                    return null;
            }
            catch (Exception) { return null; }
        }

        public void RemoveFriend(int your_id, int friend_id)
        {
            try
            {
                db.Users.FirstOrDefault(x => x.Id == your_id).Friends.Remove(db.Users.FirstOrDefault(x => x.Id == friend_id));
                db.SaveChanges();
            }
            catch (Exception) { }
        }


        public bool ResendCode(int user_id)
        {
            try
            {
                foreach (var el in db.ConfirmCodes)
                {
                    if (el.user.Id == user_id)
                    {
                        MailService mail = new MailService();
                        mail.SendCode(new UserDTO() {  Email = el.user.Email}, el.code);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception) { return false; }
        }

        public UserDTO SignIn(string EmailOrLogin, string password)
        {
            try
            {
                Mapper.Reset();
                //users1.Add(new UserDTO() { Email = "istep.andriy@gmail.com", Friends = null, Id = 1, IsConfirmed = true, Login = "Admin", Password = "Admin", Rooms = null });
                //users1.Add(new UserDTO() { Email = "istep.andriy12@gmail.com", Friends = null, Id = 12, IsConfirmed = true, Login = "Admin1", Password = "Ad1min1", Rooms = null });
                Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());


                foreach (var el in db.Users)
                {
                    if (el.Login == EmailOrLogin || el.Login == EmailOrLogin && el.Password == password)
                    {
                        UserDTO user = Mapper.Map<User, UserDTO>(el);
                        return user;
                    }
                }
                return null;
            }
            catch (Exception) { return null; }
        }

        IEnumerable<UserDTO> IUser.getSearchPeople(string Name)
        {
            try
            {
                List<UserDTO> SearchUsers = new List<UserDTO>();
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
                foreach (var el in db.Users)
                {
                    if (el.Name.Contains(Name) == true)
                    {
                        UserDTO user = Mapper.Map<User, UserDTO>(el);
                        SearchUsers.Add(user);
                    }
                }
                return SearchUsers;
            }
            catch (Exception) { return null; }
}













        //=====================================================
        //========================IMESSAGE=====================
        //=====================================================








        public void SendMessage(string body, RoomDTO room, UserDTO sender, AttachDTO attach = null)
        {
            try
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
            catch(Exception){ }
        }

        public IEnumerable<RoomDTO> GetRooms(int your_id)
        {
            try
            {
                List<RoomDTO> rooms = new List<RoomDTO>();
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<Room, RoomDTO>());
                foreach (var el in db.Users.FirstOrDefault(x => x.Id == your_id).Rooms)
                {


                    RoomDTO room = Mapper.Map<Room, RoomDTO>(el);
                    rooms.Add(room);
                }
                return rooms;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public UserDTO GetUserId(int id)
        {
            try
            {
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
                UserDTO user = Mapper.Map<User, UserDTO>(db.Users.FirstOrDefault(x=>x.Id ==id));
                return user;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public IEnumerable<UserDTO> GetFriends(int id)
        {
            try
            {
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
                List<UserDTO> users = new List<UserDTO>();

                foreach (var el in db.Users.FirstOrDefault(x => x.Id == id).Friends)
                {
                 
                    UserDTO user = Mapper.Map<User, UserDTO>(el);
                    users.Add(user);
                }
                return users;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
