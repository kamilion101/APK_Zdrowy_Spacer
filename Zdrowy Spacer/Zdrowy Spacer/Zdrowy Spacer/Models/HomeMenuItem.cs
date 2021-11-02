﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zdrowy_Spacer.Models
{
    public enum MenuItemType
    {
        Browse,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
