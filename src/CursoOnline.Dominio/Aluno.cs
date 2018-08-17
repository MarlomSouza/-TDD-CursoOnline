using System;
using System.Text.RegularExpressions;
using CursoOnline.Dominio;

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
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentException("cpf inválido");

            if (Regex.IsMatch(email, @"/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i"))
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