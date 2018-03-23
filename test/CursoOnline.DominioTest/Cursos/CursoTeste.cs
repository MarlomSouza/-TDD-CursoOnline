using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._util;
using ExpectedObjects;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTeste
    {
        private readonly string nome;
        private readonly int cargaHoraria;
        private readonly PublicoAlvo publicoAlvo;
        private readonly decimal valor;
        private readonly string descricao;

        public CursoTeste()
        {
            nome = "Curso 1";
            cargaHoraria = 20;
            publicoAlvo = PublicoAlvo.Estudante;
            valor = 10.0M;
            descricao = "uma descricao";
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = nome,
                CargaHoraria = cargaHoraria,
                PublicoAlvo = publicoAlvo,
                Valor = valor,
                Descricao = descricao
            };

            var curso = CursoBuilder.New().Build();

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }
        [Theory]
        [InlineDataAttribute("")]
        [InlineDataAttribute(null)]
        public void NomeCursoNaoDeveTerNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
            CursoBuilder.New().ComNome(nomeInvalido).Build()).WithMessage("Nome curso invalido");
        }

        [Theory]
        [InlineDataAttribute(0)]
        [InlineDataAttribute(-1)]
        [InlineDataAttribute(-100)]
        public void CargaHorariaCursoNaoDeveSerInvalida(int cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
            CursoBuilder.New().ComCargaHoraria(cargaHorariaInvalida).Build()).WithMessage("Carga horaria curso invalida");
        }

        [Theory]
        [InlineDataAttribute(-1)]
        [InlineDataAttribute(-10)]
        [InlineDataAttribute(-100)]
        public void ValorCursoNaoDeveSerMenorQueZero(decimal valorCursoInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
           CursoBuilder.New().ComValor(valorCursoInvalido).Build()).WithMessage("valor curso não pode ser menor que zero");

        }

    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Emprego,
        Empreendedor
    }

    public class Curso
    {
        public Curso(string nome, string descricao, int cargaHoraria, PublicoAlvo publicoAlvo, decimal valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome curso invalido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horaria curso invalida");

            if (valor < 0)
                throw new ArgumentException("valor curso não pode ser menor que zero");


            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }
}
