using System;

using Zdrowy_Spacer_forms.Models;

namespace Zdrowy_Spacer_forms.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
