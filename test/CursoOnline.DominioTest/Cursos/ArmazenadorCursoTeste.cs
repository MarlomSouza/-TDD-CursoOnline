using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._util;
using Moq;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorCursoTeste
    {
        private CursoDto cursoDTO;
        private readonly Mock<ICursoRepository> cursoRepositoryMock;
        private readonly ArmazenadorCurso armazenadorCurso;

        public ArmazenadorCursoTeste()
        {
            var faker = new Faker();
            cursoDTO = new CursoDto
            {
                Nome = faker.Person.FullName,
                Descricao = faker.Lorem.Paragraph(),
                CargaHoraria = faker.Random.Int(1),
                PublicoAlvo = faker.PickRandom<string>("Estudante", "Universitario", "Emprego", "Empreendedor"),
                Valor = faker.Random.Decimal(10, 1000)
            };

            cursoRepositoryMock = new Mock<ICursoRepository>();

            armazenadorCurso = new ArmazenadorCurso(cursoRepositoryMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            armazenadorCurso.Armazenar(cursoDTO);
            cursoRepositoryMock.Verify(r => r.Adicionar(It.Is<Curso>(c => c.Nome == cursoDTO.Nome)));
        }

        [Fact]
        public void NaoDeveSetarPublicoAlvoInvalido()
        {
            cursoDTO.PublicoAlvo = "Outros";
            Assert.Throws<ArgumentException>(()=> armazenadorCurso.Armazenar(cursoDTO)).WithMessage("Publico alvo inválido");
        }
    }

    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        Curso BuscarPorNome(string nome);
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
            if (!Enum.TryParse(typeof(PublicoAlvo), cursoDTO.PublicoAlvo, out var publicoAlvo))
                throw new ArgumentException("Publico alvo inválido");

            var curso = new Curso(cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDTO.Valor);
            _cursoRepository.Adicionar(curso);
        }
    }

    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public decimal Valor { get; set; }
    }
}
