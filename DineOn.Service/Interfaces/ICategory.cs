﻿using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll();
    }
}