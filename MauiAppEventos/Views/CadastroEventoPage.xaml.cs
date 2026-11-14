using MauiAppEventos.Models;

namespace MauiAppEventos.Views;

public partial class CadastroEventoPage : ContentPage
{
    public CadastroEventoPage()
    {
        InitializeComponent();

        BindingContext = new Evento();

        dtpck_inicio.MinimumDate = DateTime.Today;
        dtpck_termino.MinimumDate = DateTime.Today;
    }

    private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        dtpck_termino.MinimumDate = e.NewDate;

        if (dtpck_termino.Date < e.NewDate)
        {
            dtpck_termino.Date = e.NewDate;
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var eventoCadastrado = (Evento)BindingContext;

            if (string.IsNullOrWhiteSpace(eventoCadastrado.Nome) ||
                string.IsNullOrWhiteSpace(eventoCadastrado.Local))
            {
                await DisplayAlertAsync("Atenção", "Preencha o nome e o local do evento.", "OK");
                return;
            }

            if (eventoCadastrado.NumeroParticipantes <= 0)
            {
                await DisplayAlertAsync("Atenção", "Informe um número válido de participantes.", "OK");
                return;
            }

            await Navigation.PushAsync(new ResumoEventoPage
            {
                BindingContext = eventoCadastrado
            });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", $"Ocorreu um erro ao processar o cadastro: {ex.Message}", "OK");
        }
    }
}