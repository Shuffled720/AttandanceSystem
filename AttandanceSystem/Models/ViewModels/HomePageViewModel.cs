﻿using AttandanceSystem.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


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
                await Shell.Current.GoToAsync("//login", true);
            }
        }
        [RelayCommand]
        private async Task MarkCheckIn()
        {
            try
            {

                GeolocationRequest request = new(GeolocationAccuracy.Best);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {

                    Latitude = location.Latitude.ToString();
                    Longitude = location.Longitude.ToString();
                    if (CheckLocation())
                    {
                        try
                        {
                            await MarkAttendance("PunchIn");

                        }
                        catch
                        {
                            await Application.Current.MainPage.DisplayAlert("Insternal Server Error", "You are not Punched in", "OK");
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
                            await MarkAttendance("PunchOut");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            await Application.Current.MainPage.DisplayAlert("Error", "You are not Punched OUT", "OK");
                            Console.WriteLine();
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

        private async Task MarkAttendance(string status)
        {
            string id = SecureStorage.GetAsync("attendanceUserId").Result;
            var res = await _attendanceApiService.PostAttendanceInfo(id, status);
            //Console.WriteLine(res?.Message);
            if (res.Message == "User not found")
            {

                await Application.Current.MainPage.DisplayAlert("Error", "User not found", "OK");
            }
            else if (res.Message == "Shed not found")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Shed not found", "OK");

            }
            else if (res.Message == "PunchOut not done")
            {

                await Application.Current.MainPage.DisplayAlert("Error", "PunchOut not done", "OK");
            }
            else if (res.Message == "PunchIn not found")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "PunchIn not found", "OK");
            }
            else if (res.Message == "PunchOut already done")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "PunchOut already done", "OK");
            }
            else if (res.Message == "Invalid Status")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid Status", "OK");
            }
            else
            {
                if(status== "PunchIn")
                     await Application.Current.MainPage.DisplayAlert("Success", $"You are Punched In", "OK");
                else if(status== "PunchOut")
                    await Application.Current.MainPage.DisplayAlert("Success", $"You are Punched Out", "OK");
            }
            //if (res?.Message == "duplicate record")
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", $"You have already Punched {status}", "OK");
            //}
            //else
            //{
            //    await Application.Current.MainPage.DisplayAlert("Success", $"You are Punched {status}", "OK");
            //}
        }
        private bool CheckLocation()
        {
            return true; // comment this section before running in production or testing the gps location ability 
            double shedLocation_Lat = Convert.ToDouble(SecureStorage.GetAsync("shedLatitude").Result);
            double shedLocation_Long = Convert.ToDouble(SecureStorage.GetAsync("shedLongitude").Result);
            double userLocation_Lat = Convert.ToDouble(Latitude);
            double userLocation_Long = Convert.ToDouble(Longitude);
            double distance = Distance(shedLocation_Lat, shedLocation_Long, userLocation_Lat, userLocation_Long);
            Console.WriteLine(distance);
            //here distance is in kilometers
            if (distance < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371.0; // Earth radius in kilometers

            // Convert latitude and longitude from degrees to radians
            double lat1_rad = Math.PI * lat1 / 180.0;
            double lon1_rad = Math.PI * lon1 / 180.0;
            double lat2_rad = Math.PI * lat2 / 180.0;
            double lon2_rad = Math.PI * lon2 / 180.0;

            // Calculate the differences
            double d_lat = lat2_rad - lat1_rad;
            double d_lon = lon2_rad - lon1_rad;

            // Apply Haversine formula
            double a = Math.Pow(Math.Sin(d_lat / 2), 2) + Math.Cos(lat1_rad) * Math.Cos(lat2_rad) * Math.Pow(Math.Sin(d_lon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;

            return distance;

        }


    }
}
