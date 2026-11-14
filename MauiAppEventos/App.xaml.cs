namespace MauiAppEventos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Define a página inicial encapsulada em uma NavigationPage para permitir a navegação por pilha
            MainPage = new NavigationPage(new Views.CadastroEventoPage());
        }
    }
}