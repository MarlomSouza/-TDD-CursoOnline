using System;

namespace CursoOnline.Dominio
{
    public class Curso
    {
        public Curso(int id, string nome, string descricao, int cargaHoraria, PublicoAlvo publicoAlvo, decimal valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome curso invalido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horaria curso invalida");

            if (valor < 0)
                throw new ArgumentException("valor curso não pode ser menor que zero");

            Id = id;
            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }
}
