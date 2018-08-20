using System;
using Bogus;
using CursoOnline.Dominio;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._util;
using ExpectedObjects;
using Xunit;

namespace CursoOnline.DominioTest.Alunos.Armazenador
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
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void NaoDeveCriarAlunoComNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
            (AlunoBuilder.Novo().ComNome(nomeInvalido).Build())).WithMessage("Nome inválido");
        }

        [Theory]
        [InlineData("")]
        public void NaoDeveCriarAlunoComEmailInvalido(string emailInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
            (AlunoBuilder.Novo().ComEmail(emailInvalido).Build())).WithMessage("Email inválido");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCriarAlunoComCpfInvalido(string cpfInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
            (AlunoBuilder.Novo().ComCpf(cpfInvalido).Build())).WithMessage("cpf inválido");
        }

    }
}