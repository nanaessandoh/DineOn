using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using DineOn.Models;
using Microsoft.AspNetCore.Hosting;

namespace DineOn.Services
{
    public class MenuItemService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName { get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "menuItems.json"); } }

        public MenuItemService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }


        public IEnumerable<MenuItem> GetMenuItems()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<MenuItem[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }


        public IEnumerable<MenuItem> GetBurger()
        {
            return GetMenuItems().Where(asset => asset.CategoryId == 2);
        }

        public IEnumerable<MenuItem> GetDessert()
        {
            return GetMenuItems().Where(asset => asset.CategoryId == 6);
        }


        public IEnumerable<MenuItem> GetMexican()
        {
            return GetMenuItems().Where(asset => asset.CategoryId == 3);
        }

        public IEnumerable<MenuItem> GetPizza()
        {
            return GetMenuItems().Where(asset => asset.CategoryId == 4);
        }

        public IEnumerable<MenuItem> GetStarter()
        {
            return GetMenuItems().Where(asset => asset.CategoryId == 1);
        }

        public IEnumerable<MenuItem> GetVegetarian()
        {
            return GetMenuItems().Where(asset => asset.CategoryId == 5);
        }

        public void AddRating(int menuItemId, int rating)
        {
            var menuitems = GetMenuItems();

            var query = menuitems.FirstOrDefault(asset => asset.MenuItemId == menuItemId);

            if (query.Ratings == null)
            {
                query.Ratings = new int[] { rating };
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<MenuItem>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    menuitems
                );
            }
        }

    }
}
