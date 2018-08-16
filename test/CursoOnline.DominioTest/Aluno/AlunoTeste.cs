using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
using Xunit;

namespace CursoOnline.DominioTest.Aluno
{
    public class AlunoTeste
    {
        private readonly Faker faker;
        private string nome;
        private string cpf;
        private string email;
        private PublicoAlvo publicoAlvo;


        public AlunoTeste()
        {
            faker = new Faker();

        }

        [Fact]
        public void DeveCriarUmAluno()
        {
            //Given
            var alunoEsperado = AlunoBuilder.Novo().
            //When
            alunoEsperado = new Aluno(nome, cpf, email, publicoAlvo);

            //Then
            alunoEsperado.ToExpectedObject()
        }

    }
}