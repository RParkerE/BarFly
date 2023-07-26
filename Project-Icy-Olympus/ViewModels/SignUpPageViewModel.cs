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
    public partial class SignUpPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        string userEmail;
        [ObservableProperty]
        string userPassword;

        public Command RegisterCommand { get; }
        public Command LoginCommand { get; }
        RegisterService registerService;

        public SignUpPageViewModel(RegisterService registerService)
        {
            Title = "Login";
            this.registerService = registerService;
            RegisterCommand = new Command(async () => await RegisterAsync());
            LoginCommand = new Command(async () => await LoginAsync());
        }

        async Task RegisterAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var register = new RegisterService();
                string Token = await register.RegisterWithEmailPassword(userEmail, userPassword);
                if (Token != null)
                {
                    await Shell.Current.GoToAsync("//MainPage");
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

        async Task LoginAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                await Shell.Current.GoToAsync("//MainPage");
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
