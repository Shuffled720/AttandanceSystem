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
    internal partial class HomePageViewModel : ObservableObject
    {
        private readonly AttendanceApiService _attendanceApiService;
        public HomePageViewModel()
        {
            _attendanceApiService = new AttendanceApiService();
        }
        [ObservableProperty]
        private string latitude;
        [ObservableProperty]
        private string longitude;

        [RelayCommand]
        private async Task Logout()
        {

            if (await Application.Current.MainPage.DisplayAlert("Are you sure?", "You will be logged out.", "Yes", "No"))
            {
                SecureStorage.RemoveAll();
                await Shell.Current.GoToAsync("login");
            }
        }
        [RelayCommand]
        private async Task MarkCheckIn()
        {
            try
            {

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {

                    Latitude = location.Latitude.ToString();
                    Longitude = location.Longitude.ToString();
                    try
                    {
                        MarkAttendance("IN");
                        await Application.Current.MainPage.DisplayAlert("Success", "You are checked in", "OK");
                    }
                    catch
                    {
                        await Application.Current.MainPage.DisplayAlert("Insternal Server Error", "You are not checked in", "OK");
                    }

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Feature not supported", "OK");
            }
        }
        [RelayCommand]
        private async Task MarkCheckOut()
        {
            try
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {

                    Latitude = location.Latitude.ToString();
                    Longitude = location.Longitude.ToString();
                    if (CheckLocation())
                    {
                        try
                        {
                            MarkAttendance("OUT");
                            await Application.Current.MainPage.DisplayAlert("Success", "You are checked out", "OK");
                        }
                        catch
                        {
                            await Application.Current.MainPage.DisplayAlert("Insternal Server Error", "You are not checked OUT", "OK");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "You are not in the shed location", "OK");
                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Feature not supported", "OK");
            }

        }

        private bool MarkAttendance(string status)
        {
            int id = Convert.ToInt32(SecureStorage.GetAsync("employeeId").Result);
            var res = _attendanceApiService.PostAttendanceInfo(id, status);
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private bool CheckLocation()
        {
            double shedLocation_Lat = Convert.ToDouble(SecureStorage.GetAsync("shedLocation_Lat").Result);
            double shedLocation_Long = Convert.ToDouble(SecureStorage.GetAsync("shedLocation_Long").Result);
            double userLocation_Lat = Convert.ToDouble(Latitude);
            double userLocation_Long = Convert.ToDouble(Longitude);
            double distance = Distance(shedLocation_Lat, shedLocation_Long, userLocation_Lat, userLocation_Long);
            return true;
            //if (distance < 100)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        private double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            double distance_lat = lat1 - lat2;
            double distance_long = lon1 - lon2;
            return Math.Sqrt(distance_lat * distance_lat + distance_long * distance_long);

        }


    }
}
