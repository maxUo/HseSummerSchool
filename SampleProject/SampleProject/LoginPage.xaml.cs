using System;
using SampleProject.Models;
using SampleProject.Services;
using Xamarin.Forms;

namespace SampleProject
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public async void Handle_Clicked(object sender, EventArgs e)
        {
            buttonLogin.IsEnabled = false;
            UserItem item = new UserItem();

            item.Name = loginEntry.Text;
            item.Password = passwordEntry.Text;

            bool result = await WebApiService.CheckRegister(item);
            await DisplayAlert("User register", result.ToString(), "Ok");
            buttonLogin.IsEnabled = true;
        }
    }
}
