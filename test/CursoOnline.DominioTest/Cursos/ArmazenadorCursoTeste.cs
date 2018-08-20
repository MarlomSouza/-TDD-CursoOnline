using Bogus;
using CursoOnline.Dominio;
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
}
