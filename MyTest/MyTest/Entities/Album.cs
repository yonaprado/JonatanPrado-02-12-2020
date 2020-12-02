using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTest.Entities
{
    public class Album
    {
        private int _userId;
        private int _id;
        private string _title;

        public int UserId { get => _userId; set => _userId = value; }
        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
    }
}