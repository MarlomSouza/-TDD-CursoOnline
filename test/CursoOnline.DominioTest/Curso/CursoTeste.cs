using CursoOnline.DominioTest._util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Curso
{
    public class CursoTeste
    {
        private readonly string Nome;
        private readonly int cargaHoraria;
        private readonly PublicoAlvo publicoAlvo;
        private readonly decimal valor;

        public CursoTeste()
        {
            Nome = "Curso 1";
            cargaHoraria = 20;
            publicoAlvo = PublicoAlvo.Estudante;
            valor = 10.0M;
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Curso 1",
                CargaHoraria = 20,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = 10.0M
            };

            var curso = new Curso(Nome, cargaHoraria, publicoAlvo, valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }
        [Theory]
        [InlineDataAttribute("")]
        [InlineDataAttribute(null)]
        public void NomeCursoNaoDeveTerNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
            new Curso(nomeInvalido, cargaHoraria, publicoAlvo, valor)).WithMessage("Nome curso invalido");
        }

        [Theory]
        [InlineDataAttribute(0)]
        [InlineDataAttribute(-1)]
        [InlineDataAttribute(-100)]
        public void CargaHorariaCursoNaoDeveSerInvalida(int cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
            new Curso(Nome, cargaHorariaInvalida, publicoAlvo, valor)).WithMessage("Carga horaria curso invalida");
        }

        [Theory]
        [InlineDataAttribute(-1)]
        [InlineDataAttribute(-10)]
        [InlineDataAttribute(-100)]
        public void ValorCursoNaoDeveSerMenorQueZero(decimal valorCursoInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
           new Curso(Nome, cargaHoraria, publicoAlvo, valorCursoInvalido)).WithMessage("valor curso não pode ser menor que zero");

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
        public Curso(string nome, int cargaHoraria, PublicoAlvo publicoAlvo, decimal valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome curso invalido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horaria curso invalida");

            if (valor < 0)
                throw new ArgumentException("valor curso não pode ser menor que zero");


            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; internal set; }
        public int CargaHoraria { get; internal set; }
        public PublicoAlvo PublicoAlvo { get; internal set; }
        public decimal Valor { get; internal set; }
    }
}
