﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DineOn.Web.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        [JsonPropertyName("img")]
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int[] Ratings { get; set; }
        public override string ToString() => JsonSerializer.Serialize<MenuItem>(this);
    }
}