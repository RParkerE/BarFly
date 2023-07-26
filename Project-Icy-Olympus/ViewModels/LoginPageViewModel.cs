using CommunityToolkit.Mvvm.ComponentModel;
using Project_Icy_Olympus.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Icy_Olympus.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        string userEmail;
        [ObservableProperty]
        string userPassword;

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        AuthService authService;

        public LoginPageViewModel(AuthService authService)
        {
            Title = "Login";
            this.authService = authService;
            LoginCommand = new Command(async () => await LoginAsync());
            RegisterCommand = new Command(async () => await RegisterAsync());
        }

        async Task LoginAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var auth = new AuthService();
                string Token = await auth.LoginWithEmailPassword(UserEmail, UserPassword);
                if (Token != null)
                {
                    await Shell.Current.GoToAsync("//MapPage", false);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Registration Failed", "Email already in use", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get deals: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task RegisterAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                await Shell.Current.GoToAsync("//SignUpPage", false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get deals: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
