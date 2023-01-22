using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewTask.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace NewTask.Pages
{
    public class TestingModel : PageModel
    {

        private MessageContext db;
        public List<Message> messages = new List<Message>();
        public string checkUser = " ";

        public TestingModel(MessageContext context)
        {
            db = context;
        }
        public void OnGet()
        {
            if (!db.Users.Any())
            {
                AddUsers();
            }

            messages = db.Messages.ToList();
            //db.Messages.Remove(messages[0]);
            //db.Messages.Remove(messages[2]);
            //db.SaveChanges();

        }
        public void OnPost(string number, int id, string message, string status)
        {

            if (db.Users.Any(i => i.Phone == number))
            {
                db.Messages.Add(new Message { Date = DateTime.Now, UserPhone = number, Text = message, Status = status });
                db.SaveChanges();
            }
            else
            {
                checkUser = "����� ������������������� ������� �� ����� �� ����������";
            }
            messages = db.Messages.ToList();
        }

        protected void AddUsers()
        {
            db.Users.AddRange(new User { Name = "����", Phone = "1234" }, new User { Name = "�����", Phone = "5678" },
            new User { Name = "�����", Phone = "123456" }, new User { Name = "�����", Phone = "56789" }, new User { Name = "����", Phone = "11111" });
            db.SaveChanges();
        }
    }
}

