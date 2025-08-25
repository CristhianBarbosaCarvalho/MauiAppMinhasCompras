using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Inicializado com string.Empty para não gerar warning
        public string Descricao { get; set; } = string.Empty;

        public double Quantidade { get; set; }
        public double Preco { get; set; }
    }
}
