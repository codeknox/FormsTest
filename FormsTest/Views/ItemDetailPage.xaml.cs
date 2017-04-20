using System;
using System.Collections.Generic;
using FormsTest.Views;
using Xamarin.Forms;

namespace FormsTest
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void OnTapGestureRecognizerTappedAsync(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new ShowImage(new ShowImageViewModel(viewModel.Item)));
        }
    }
}
