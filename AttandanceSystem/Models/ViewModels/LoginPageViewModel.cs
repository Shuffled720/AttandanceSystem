using AttandanceSystem.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttandanceSystem.Models.ViewModels
{
    internal partial class LoginPageViewModel : ObservableObject
    {

        private readonly LoginApiService _loginApiService;
        public LoginPageViewModel()
        {
            _loginApiService = new LoginApiService();
        }

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;


        [RelayCommand]
        private async Task GetUserInfo()
        {
            var res = await _loginApiService.LoginUserInfo(username, password);

            if (res != null)
            {
                await SecureStorage.SetAsync("employeeId", res.EmployeeId.ToString());
                await SecureStorage.SetAsync("name", res.Name);
                await SecureStorage.SetAsync("lastName", res.LastName);
                await SecureStorage.SetAsync("password", res.Password);
                await SecureStorage.SetAsync("shedName", res.ShedName);
                await SecureStorage.SetAsync("shedLocation_Lat", res.ShedLocation_Lat.ToString());
                await SecureStorage.SetAsync("shedLocation_Long", res.ShedLocation_Long.ToString());

                await Shell.Current.GoToAsync("home");
            }
            else
            {
                //nofity user that login failed
            }


        }




    }
}
