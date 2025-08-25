using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQliteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQliteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        // Inserir novo produto
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        // Atualizar produto existente
        public Task<int> Update(Produto p)
        {
            return _conn.UpdateAsync(p);
        }

        // Excluir produto pelo Id
        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        // Buscar todos os produtos
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        // Buscar produtos pelo nome/descrição
        public Task<List<Produto>> Search(string q)
        {
            string sql = $"SELECT * FROM Produto WHERE Descricao LIKE '%{q}%'";
            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
