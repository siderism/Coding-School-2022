using Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Shared.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }

    public class ItemListViewModel
    {
        public List<ItemViewModel> ItemList { get; set; } = new List<ItemViewModel>();
    }
}
