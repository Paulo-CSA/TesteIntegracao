using Chapter.Models;

namespace Chapter.Interfaces
{
    public interface ILivroRepository
    {
        List<Livro> Ler();

        Livro BuscarPorId(int id);

        void Cadastrar(Livro livro);

        void Atualizar(int id, Livro livro);   

        void Deletar(int id);
    }
}
