using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
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
            Assert.Throws<ArgumentException>(() => armazenadorCurso.Armazenar(cursoDTO)).WithMessage("Publico alvo inválido");
        }

        [Fact]
        public void NaoDeveAdicionarCursoComNomeJaExistente()
        {
            var cursoJaSalvo = CursoBuilder.New().ComNome(cursoDTO.Nome).Build();
            cursoRepositoryMock.Setup(r => r.Buscar(cursoDTO.Nome)).Returns(cursoJaSalvo);
            Assert.Throws<ArgumentException>(() => armazenadorCurso.Armazenar(cursoDTO)).WithMessage("Nome do curso já existente!");
        }


    }

    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        Curso Buscar(string nome);
        Curso Buscar(int id);
        void Remover(int id);
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
            var curso = _cursoRepository.Buscar(cursoDTO.Nome);

            if (curso != null)
                throw new ArgumentException("Nome do curso já existente!");


            if (!Enum.TryParse(typeof(PublicoAlvo), cursoDTO.PublicoAlvo, out var publicoAlvo))
                throw new ArgumentException("Publico alvo inválido");

            curso = new Curso(cursoDTO.Id, cursoDTO.Nome, cursoDTO.Descricao, cursoDTO.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDTO.Valor);
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
        public int Id { get; set; }
    }
}
