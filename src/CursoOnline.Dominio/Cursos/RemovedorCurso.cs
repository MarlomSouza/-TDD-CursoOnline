using System;
using CursoOnline.Dominio.Cursos;

namespace CursoOnline.Dominio.Cursos
{
    public class RemovedorCurso
    {
        private readonly ICursoRepository _cursoRepository;

        public RemovedorCurso(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public void remover(int id)
        {
            var curso = _cursoRepository.Buscar(id);

            if (curso == null)
                throw new ArgumentException("Não é possivel remover um curso inexistente!");

            _cursoRepository.Remover(id);
        }
    }
}
