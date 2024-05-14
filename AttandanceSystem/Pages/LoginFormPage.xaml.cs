using AttandanceSystem.Models.ViewModels;

namespace AttandanceSystem.Pages;

public partial class LoginFormPage : ContentPage
{
    public LoginFormPage()
    {
        InitializeComponent();
        BindingContext = new LoginPageViewModel();
    }
    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

   
}