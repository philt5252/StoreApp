﻿using StoreApp.Foundation.Models;

namespace StoreApp.Core.Models
{
    public class Game : IGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}