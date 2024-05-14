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
            //Platforms.KeyboardHelper.HideKeyboard();
            try
            {


                var res = await _loginApiService.LoginUserInfo(username, password);

                if (res.Message != "User not found")
                {
                    await SecureStorage.SetAsync("employeeId", res.EmployeeId.ToString());
                    await SecureStorage.SetAsync("name", res.Name);
                    await SecureStorage.SetAsync("lastName", res.LastName);
                    await SecureStorage.SetAsync("password", res.Password);
                    await SecureStorage.SetAsync("shedName", res.ShedName);
                    await SecureStorage.SetAsync("shedLocation_Lat", res.ShedLocation_Lat.ToString());
                    await SecureStorage.SetAsync("shedLocation_Long", res.ShedLocation_Long.ToString());

                    //go to home page if user is found
                    await Shell.Current.GoToAsync("///home",true);
                }
                else if (res.Message == "User not found")
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "UserNot Found", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "", "OK");
                }
            }
            catch (Exception)
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Internal Server Error", "Try afte some time!");
            }


        }




    }
}
