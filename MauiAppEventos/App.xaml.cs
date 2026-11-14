using System.Globalization;

namespace MauiAppEventos
{
    public partial class App : Application
    {
        public App()
        {
            var culture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            InitializeComponent();

            MainPage = new NavigationPage(new Views.CadastroEventoPage());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 480;
            window.Height = 850;

            return window;
        }
    }
}