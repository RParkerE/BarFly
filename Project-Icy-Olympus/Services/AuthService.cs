using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Icy_Olympus.Services
{
    public class AuthService : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyD_L13G10-F0aYR6IK2BqTWV3Zv3ryBpAQ"));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                var content = await auth.GetFreshAuthAsync();
                return content.FirebaseToken;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }
    }
}
