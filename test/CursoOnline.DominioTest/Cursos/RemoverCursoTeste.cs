using System;
using Bogus;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._util;
using Moq;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class RemoverCursoTeste
    {
        private CursoDto cursoDTO;
        private readonly Mock<ICursoRepository> cursoRepitoryMock;
        private readonly RemovedorCurso removedorCurso;

        public RemoverCursoTeste()
        {

            var faker = new Faker();
            cursoDTO = new CursoDto
            {
                Id = faker.Random.Int(1, 1000),
                Nome = faker.Person.FullName,
                Descricao = faker.Lorem.Paragraph(),
                CargaHoraria = faker.Random.Int(1),
                PublicoAlvo = faker.PickRandom<string>("Estudante", "Universitario", "Emprego", "Empreendedor"),
                Valor = faker.Random.Decimal(10, 1000)
            };

            cursoRepitoryMock = new Mock<ICursoRepository>();
            removedorCurso = new RemovedorCurso(cursoRepitoryMock.Object);
        }


        [Fact]
        public void RemoverCursoExistente()
        {
            var cursoJaSalvo = CursoBuilder.New().ComId(cursoDTO.Id).Build();
            cursoRepitoryMock.Setup(r => r.Buscar(cursoDTO.Id)).Returns(cursoJaSalvo);

            removedorCurso.remover(cursoDTO.Id);

            //Then
            cursoRepitoryMock.Verify(r => r.Remover(cursoDTO.Id), Times.AtLeast(1));
        }

        [Fact]
        public void NaoDeveRemoverCursoInexistente()
        {
            Assert.Throws<ArgumentException>(() => removedorCurso.remover(cursoDTO.Id)).WithMessage("Não é possivel remover um curso inexistente!");
        }

    }

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

            if(curso == null)
                throw new ArgumentException("Não é possivel remover um curso inexistente!");

            _cursoRepository.Remover(id);
        }
    }
}
