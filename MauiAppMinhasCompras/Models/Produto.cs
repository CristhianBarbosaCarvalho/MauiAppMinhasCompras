using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        private string _descricao = string.Empty; // 🔹 evita erro CS8618

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao
        {
            get => _descricao;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Por Favor, Preencha a Descrição");
                }
                _descricao = value;
            }
        }

        public double Quantidade { get; set; }

        public double Preco { get; set; }

        public double Total => Quantidade * Preco;
    }
}
