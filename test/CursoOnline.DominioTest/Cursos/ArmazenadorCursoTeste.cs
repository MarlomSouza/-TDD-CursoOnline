using Bogus;
using CursoOnline.Dominio.Cursos;
using Moq;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorCursoTeste
    {
        [Fact]
        public void DeveAdicionarCurso()
        {
            var faker = new Faker();
            var cursoDTO = new CursoDto
            {
                Nome = faker.Person.FullName,
                Descricao = faker.Lorem.Paragraph(),
                CargaHoraria = faker.Random.Int(1),
                PublicoAlvo = faker.PickRandom(PublicoAlvo.Empreendedor, PublicoAlvo.Emprego, PublicoAlvo.Estudante, PublicoAlvo.Universitario),
                Valor = faker.Random.Decimal(10, 1000)
            };

            var cursoRepositoryMock = new Mock<ICursoRepository>();

            var armazenadorCurso = new ArmazenadorCurso(cursoRepositoryMock.Object);
            armazenadorCurso.Armazenar(cursoDTO);

            cursoRepositoryMock.Verify(r => r.Adicionar(It.Is<Curso>(c => c.Nome == cursoDTO.Nome)));


        }
    }

    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
    }

    public class ArmazenadorCurso
    {
        private readonly ICursoRepository _cursoRepository;

        public ArmazenadorCurso(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public void Armazenar(CursoDto cursoDTO)
        {
            var curso = new Curso(cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria, cursoDTO.PublicoAlvo, cursoDTO.Valor);
            _cursoRepository.Adicionar(curso);
        }
    }

    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
        public decimal Valor { get; set; }
    }
}
