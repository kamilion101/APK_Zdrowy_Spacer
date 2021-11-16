using System;
using System.Collections.Generic;
using System.Text;

namespace Zdrowy_Spacer_forms.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Zdjęcia,
        Wybierz_normę
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
