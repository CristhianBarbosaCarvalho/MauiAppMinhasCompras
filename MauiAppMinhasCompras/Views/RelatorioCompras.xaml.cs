namespace MauiAppMinhasCompras.Views
{
    public partial class RelatorioCompras : ContentPage
    {
        public RelatorioCompras()
        {
            InitializeComponent();
        }

        private async void OnFiltrarClicked(object sender, EventArgs e)
        {
            DateTime inicio = datePickerInicio.Date;
            DateTime fim = datePickerFim.Date;

            var produtos = await App.Db.GetAll(); // pega todos os produtos
            var filtrados = produtos
                .Where(p => p.DataCadastro.Date >= inicio && p.DataCadastro.Date <= fim)
                .ToList();

            collectionViewProdutos.ItemsSource = filtrados;
        }
    }
}
