using System;
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


        }
        public AlunoBuilder ComEmail(string email)
        {
            this.email = email;
            return this;
        }

        public AlunoBuilder ComNome(string nome)
        {
            this.nome = nome;
            return this;
        }
        public Aluno Build() => new Aluno(nome, cpf, email, publicoAlvo);

        public AlunoBuilder ComCpf(string cpf)
        {
            this.cpf = cpf;
            return this;
        }
    }
}