﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_10_B
{
    public class book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string genre{ get; set; }
        public int quantity { get; set; }

        
        public book(int id, string title, string author, string genre, int quantity)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.quantity = quantity;
        }
    }
}
