using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    // Este método é chamado quando você clica no botão "Salvar"
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Cria objeto Produto com os valores digitados
            var produto = new Produto
            {
                Descricao = txt_descricao.Text ?? string.Empty,
                Quantidade = double.TryParse(txt_quantidade.Text, out var qtd) ? qtd : 0,
                Preco = double.TryParse(txt_preco.Text, out var preco) ? preco : 0
            };

            // Salva no banco
            await App.Db.Insert(produto);

            await DisplayAlert("Sucesso", "Produto salvo com sucesso!", "OK");

            // Volta para a tela anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível salvar: {ex.Message}", "OK");
        }
    }
}
