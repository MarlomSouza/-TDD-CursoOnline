using CursoOnline.Dominio;

namespace CursoOnline.Dominio.Cursos
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        Curso Buscar(string nome);
        Curso Buscar(int id);
        void Remover(int id);
    }
}
