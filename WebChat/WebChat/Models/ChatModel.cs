using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class ChatModel
    {
        public List<User> Users; 
        public List<Message> Messages; 
        public ChatModel()
        {
            Users = new List<User>();
            Messages = new List<Message>();
        }
    }
    public class User
    {
        public string Name;
        public User(string name)
        {
            Name = name;
        }
    }
    public class Message
    {
        public User User;
        public string Text = "";
    }
}