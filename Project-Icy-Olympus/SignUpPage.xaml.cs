using Project_Icy_Olympus.Services;
using Project_Icy_Olympus.ViewModels;
using Project_Icy_Olympus.Views;
using System.ComponentModel;

namespace Project_Icy_Olympus;

[DesignTimeVisible(true)]
public partial class SignUpPage : ContentPage
{
    public SignUpPage(SignUpPageViewModel signUpPageViewModel)
    {
        InitializeComponent();
        BindingContext = signUpPageViewModel;
    }

    /*private async void SignUpClicked(object sender, EventArgs e)
    {
        var register = new RegisterService();
        string Token = await register.RegisterWithEmailPassword(EmailInput.Text, PasswordInput.Text);
        if (Token != null)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
        else
        {
            await DisplayAlert("Registration Failed", "Email already in use", "OK");
        }
    }

    private async void LoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }*/
}