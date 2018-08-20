using System;

namespace CursoOnline.Dominio
{
    public class Aluno
    {
        public Aluno(string nome, string cpf, string email, PublicoAlvo publicoAlvo)
        {
            Valida(nome, cpf, email);

            Nome = nome;
            Cpf = cpf;
            Email = email;
            PublicoAlvo = publicoAlvo;
        }

        private void Valida(string nome, string cpf, string email)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido");

            if (string.IsNullOrWhiteSpace(cpf))
                throw new ArgumentException("cpf inválido");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email inválido");
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }

        public void AlterarNome(string novoNome)
        {
            Nome = novoNome;
        }
    }
}