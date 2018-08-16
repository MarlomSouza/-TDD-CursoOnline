using Bogus;
using CursoOnline.Dominio;

namespace CursoOnline.DominioTest._Builders
{
    public class AlunoBuilder
    {
        private string nome;
        private string cpf;
        private string email;
        private PublicoAlvo publicoAlvo;
        public static AlunoBuilder Novo()
        {
            var faker = new Faker();
            return new AlunoBuilder()
            {
                nome = faker.Name.FullName(),
                cpf = "02368766554",
                email = faker.Person.Email,
                publicoAlvo = faker.PickRandom(PublicoAlvo.Empreendedor,
                PublicoAlvo.Emprego, PublicoAlvo.Estudante, PublicoAlvo.Universitario)
            };
            var a = Aluno();

        }

        public Aluno Build() => new Aluno(nome, cpf, email, publicoAlvo);
    }
}