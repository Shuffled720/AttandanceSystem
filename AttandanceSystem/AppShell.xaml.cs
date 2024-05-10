using AttandanceSystem.Pages;

namespace AttandanceSystem
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("loading", typeof(LoadingPage));
            Routing.RegisterRoute("home", typeof(HomePage));
            Routing.RegisterRoute("login",typeof(LoginFormPage));
        }
        
    }
}
