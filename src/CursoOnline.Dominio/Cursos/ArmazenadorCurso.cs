using System;

namespace CursoOnline.Dominio.Cursos
{
    public class ArmazenadorCurso
    {
        private readonly ICursoRepository _cursoRepository;

        public ArmazenadorCurso(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public void Armazenar(CursoDto cursoDTO)
        {
            var curso = _cursoRepository.Buscar(cursoDTO.Nome);

            if (curso != null)
                throw new ArgumentException("Nome do curso já existente!");

            if (!Enum.TryParse(cursoDTO.PublicoAlvo, out PublicoAlvo publicoAlvo))
            {
                throw new ArgumentException("Publico alvo inválido");
            }

            curso = new Curso(cursoDTO.Id, cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDTO.Valor);
            _cursoRepository.Adicionar(curso);
        }
    }
}
