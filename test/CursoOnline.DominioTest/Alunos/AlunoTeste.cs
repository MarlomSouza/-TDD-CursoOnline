using Bogus;
using CursoOnline.Dominio;
using CursoOnline.DominioTest._Builders;
using ExpectedObjects;
using Xunit;

namespace CursoOnline.DominioTest.Alunos
{
    public class AlunoTeste
    {
        private readonly Faker faker;
        public string nome {get;}
        private string cpf {get;}
        private string email {get;}
        private PublicoAlvo publicoAlvo {get;}


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
            var aluno = new Aluno(alunoEsperado.Nome,alunoEsperado.Cpf , alunoEsperado.Email, alunoEsperado.PublicoAlvo);

            //Then
            alunoEsperado.ToExpectedObject().ShouldMatch(aluno);
        }

    }
}