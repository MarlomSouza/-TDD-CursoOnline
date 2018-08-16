using CursoOnline.Dominio;

namespace CursoOnline.Dominio
{
    public class Aluno
    {
        public Aluno(string nome, string cpf, string email, PublicoAlvo publicoAlvo)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            PublicoAlvo = publicoAlvo;
        }

        public string Nome { get; }
        public string Cpf { get; }
        public string Email { get; }
        public PublicoAlvo PublicoAlvo { get; }
    }
}