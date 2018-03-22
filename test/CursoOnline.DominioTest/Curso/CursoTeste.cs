using CursoOnline.DominioTest._util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest.Curso
{
    public class CursoTeste
    {
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

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }
        [Theory]
        [InlineDataAttribute("")]
        [InlineDataAttribute(null)]
        public void NomeCursoNaoDeveTerNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = nomeInvalido,
                CargaHoraria = 20,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = 10.0M
            };

            Assert.Throws<ArgumentException>(() =>
            new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).WithMessage("Nome curso invalido");
        }

        [Theory]
        [InlineDataAttribute(0)]
        [InlineDataAttribute(-1)]
        [InlineDataAttribute(-100)]
        public void CargaHorariaCursoNaoDeveSerInvalida(int cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "Curso 1",
                CargaHoraria = cargaHorariaInvalida,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = 10.0M
            };

            Assert.Throws<ArgumentException>(() =>
            new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).WithMessage("Carga horaria curso invalida");
        }

        [Theory]
        [InlineDataAttribute(-1)]
        [InlineDataAttribute(-10)]
        [InlineDataAttribute(-100)]
        public void ValorCursoNaoDeveSerMenorQueZero(decimal valorCursoInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Curso 1",
                CargaHoraria = 20,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = valorCursoInvalido
            };

            Assert.Throws<ArgumentException>(() =>
           new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).WithMessage("valor curso não pode ser menor que zero");

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
