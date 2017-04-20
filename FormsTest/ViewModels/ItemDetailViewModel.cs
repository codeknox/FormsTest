using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsTest
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public Command ImageTapCommand { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            ImageTapCommand = new Command(async () => await ExecuteImageTapCommand());

            Title = item.Text;
            Item = item;
        }

        private async Task ExecuteImageTapCommand()
        {
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }

    public class ShowImageViewModel : BaseViewModel
    {
        public Item Item { get; set; }

        public ShowImageViewModel(Item item = null)
        {
            Title = item.Text;
            Item = item;
        }
    }
}
