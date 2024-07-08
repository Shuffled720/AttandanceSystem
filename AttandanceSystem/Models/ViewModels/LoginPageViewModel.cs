using AttandanceSystem.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


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
            try
            {
                var res = await _loginApiService.LoginUserInfo(username, password);
                if (res.Message != "User not found")
                {
                    await SecureStorage.SetAsync("shedIncharge_StaffNo", res.SedIncharge_StaffNo);
                    await SecureStorage.SetAsync("contactNo", res.ContactNo);
                    await SecureStorage.SetAsync("name", res.Name);
                    await SecureStorage.SetAsync("attendanceUserId", res.AttendanceUserId);
                    await SecureStorage.SetAsync("adminTag", res.AdminTag.ToString());
                    await SecureStorage.SetAsync("zonalRLY", res.ZonalRLY);
                    await SecureStorage.SetAsync("shed_Name", res.Shed_Name);
                    await SecureStorage.SetAsync("shed_Latitude", res.Shed_Latitude);
                    await SecureStorage.SetAsync("shed_Longitude", res.Shed_Longitude);

                    //await SecureStorage.SetAsync("userId", res.ATTENDANCE_USER_ID);
                    //await SecureStorage.SetAsync("password", res.Attendance_PASSWORD);
                    //await SecureStorage.SetAsync("shedId", res.SHED_ID.ToString());
                    //await SecureStorage.SetAsync("shedName", res.SHED_NAME);
                    //await SecureStorage.SetAsync("shedInchargeName", res.Shed_Incharge_Name);
                    //await SecureStorage.SetAsync("shedInchargeAddressOffice", res.Shed_Incharge_Address_Office);
                    //await SecureStorage.SetAsync("addressHome", res.Address_Home);
                    //await SecureStorage.SetAsync("adminTag", res.Admin_tag.ToString());
                    //await SecureStorage.SetAsync("shedLatitude", res.SHED_LATITUDE.ToString());
                    //await SecureStorage.SetAsync("shedLongitude", res.SHED_LONGITUDE.ToString());
                    await Shell.Current.GoToAsync("///home", true);
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
