using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

	private async void ToolbarItem_Clicked(object sender, EventArgs e) 
	{
        try
        {
            Produto produto_anexado = BindingContext as Produto;
            // Cria objeto Produto com os valores digitados
            var produto = new Produto
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            // Salva no banco
            await App.Db.Update(produto);

            await DisplayAlert("Sucesso", "Registro Atualizado", "OK");

            // Volta para a tela anterior
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível salvar: {ex.Message}", "OK");
        }
    }
}