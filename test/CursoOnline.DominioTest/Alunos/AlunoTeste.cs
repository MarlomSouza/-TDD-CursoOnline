using System;
using Bogus;
using CursoOnline.Dominio;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._util;
using ExpectedObjects;
using Xunit;

namespace CursoOnline.DominioTest.Alunos
{
    public class AlunoTeste
    {
        private readonly Faker faker;
        public string nome { get; }
        private string cpf { get; }
        private string email { get; }
        private PublicoAlvo publicoAlvo { get; }


        public AlunoTeste()
        {
            faker = new Faker();

        }

        [Fact]
        public void DeveCriarUmAluno()
        {
            //Given
            var alunoEsperado = AlunoBuilder.Novo().Build();
            //When
            var aluno = new Aluno(alunoEsperado.Nome, alunoEsperado.Cpf, alunoEsperado.Email, alunoEsperado.PublicoAlvo);

            //Then
            alunoEsperado.ToExpectedObject().ShouldMatch(aluno);
        }

        [Fact]
        public void DeveAlterarNomeAluno()
        {
            //Given
            var novoNomeEsperado = faker.Name.FirstName();
            var aluno = AlunoBuilder.Novo().Build();
            //When
            aluno.AlterarNome(novoNomeEsperado);
            //Then
            Assert.Equal(novoNomeEsperado, aluno.Nome);
        }

        [Theory]
        [InlineData("asds@com")]
        public void NaoDeveCriarAlunoComNomeInvalido(string emailInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
            (AlunoBuilder.Novo().ComEmail(emailInvalido).Build())).WithMessage("Email inválido");
        }

    }
}