using System;

namespace NewTask.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserPhone { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

    }
}
