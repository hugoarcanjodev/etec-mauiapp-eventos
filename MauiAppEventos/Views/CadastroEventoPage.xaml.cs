using MauiAppEventos.Models;

namespace MauiAppEventos.Views;

public partial class CadastroEventoPage : ContentPage
{
    public CadastroEventoPage()
    {
        InitializeComponent();

        // Inicializa o BindingContext com um novo objeto Evento
        BindingContext = new Evento();

        // Define limites mínimos iniciais para os DatePickers
        dtpck_inicio.MinimumDate = DateTime.Today;
        dtpck_termino.MinimumDate = DateTime.Today;
    }

    private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        // Impede que a data de término seja anterior à data de início selecionada
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
            // Recupera o objeto Evento atualizado automaticamente pelo TwoWay Binding
            var eventoCadastrado = (Evento)BindingContext;

            if (string.IsNullOrWhiteSpace(eventoCadastrado.Nome) ||
                string.IsNullOrWhiteSpace(eventoCadastrado.Local))
            {
                // Atualizado para DisplayAlertAsync (padrão .NET 9/10)
                await DisplayAlertAsync("Atenção", "Preencha o nome e o local do evento.", "OK");
                return;
            }

            if (eventoCadastrado.NumeroParticipantes <= 0)
            {
                await DisplayAlertAsync("Atenção", "Informe um número válido de participantes.", "OK");
                return;
            }

            // Navega para a tela de resumo passando o objeto via BindingContext
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