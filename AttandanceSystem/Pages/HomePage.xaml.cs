using AttandanceSystem.Models.ViewModels;

namespace AttandanceSystem.Pages;

public partial class HomePage : ContentPage
{
    public bool _isCheckingLocation;

    public HomePage()
    {
        InitializeComponent();
        BindingContext = new HomePageViewModel();

    }
    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (SecureStorage.GetAsync("userId").Result == null)
        {
            Shell.Current.GoToAsync("login");
        }
        UserName.Text = "Welcome " + await SecureStorage.GetAsync("userId");
        shedName.Text ="Shed:" + await SecureStorage.GetAsync("shedName");
    }
    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Are you sure?", "You will be logged out.", "Yes", "No"))
        {
            SecureStorage.RemoveAll();
            await Shell.Current.GoToAsync("//login");
        }
    }

}

