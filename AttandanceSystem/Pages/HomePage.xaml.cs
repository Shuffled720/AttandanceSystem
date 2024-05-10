namespace AttandanceSystem.Pages;

public partial class HomePage : ContentPage
{
    public bool _isCheckingLocation;
    public HomePage()
    {
        InitializeComponent();
    }
    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }
    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Are you sure?", "You will be logged out.", "Yes", "No"))
        {
            SecureStorage.RemoveAll();
            await Shell.Current.GoToAsync("login");
        }
    }
    private async void OnCheckInClicked(object sender, EventArgs e)
    {
        try
        {
            _isCheckingLocation = true;
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);
            if (location != null)
            {
                Location.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
            }

        }
        catch (FeatureNotSupportedException fnsEx)
        {
            await DisplayAlert("Error", "Feature not supported", "OK");
        }
        catch (FeatureNotEnabledException fneEx)
        {
            await DisplayAlert("Error", "Feature not enabled", "OK");
        }
        catch (PermissionException pEx)
        {
            await DisplayAlert("Error", "Permission denied", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "An error occurred", "OK");
        }
        finally
        {
            _isCheckingLocation = false;
        }

    }
    private async void OnCheckOutClicked(object sender, EventArgs e)
    {
        try
        {
            _isCheckingLocation = true;
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);
            if (location != null)
            {
                Location.Text = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
            }

        }
        catch (FeatureNotSupportedException fnsEx)
        {
            await DisplayAlert("Error", "Feature not supported", "OK");
        }
        catch (FeatureNotEnabledException fneEx)
        {
            await DisplayAlert("Error", "Feature not enabled", "OK");
        }
        catch (PermissionException pEx)
        {
            await DisplayAlert("Error", "Permission denied", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "An error occurred", "OK");
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }
}

