using Project_Icy_Olympus.Services;
using Project_Icy_Olympus.ViewModels;
using Project_Icy_Olympus.Views;
using System.ComponentModel;

namespace Project_Icy_Olympus;

[DesignTimeVisible(true)]
public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel loginPageViewModel)
    {
        InitializeComponent();
        BindingContext = loginPageViewModel;
    }
}