using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Icy_Olympus.Services
{
    public class RegisterService : IRegister
    {
        public async Task<string> RegisterWithEmailPassword(string email, string password)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyD_L13G10-F0aYR6IK2BqTWV3Zv3ryBpAQ"));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                return auth.FirebaseToken;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }
    }
}
