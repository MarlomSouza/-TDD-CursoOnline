using Bogus;
using CursoOnline.Dominio;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._util;
using ExpectedObjects;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTeste
    {
        private readonly int id;
        private readonly string nome;
        private readonly int cargaHoraria;
        private readonly PublicoAlvo publicoAlvo;
        private readonly decimal valor;
        private readonly string descricao;

        public CursoTeste()
        {
            id = 2;
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
                Id = id,
                Nome = nome,
                CargaHoraria = cargaHoraria,
                PublicoAlvo = publicoAlvo,
                Valor = valor,
                Descricao = descricao
            };

            var curso = new Curso(id, nome, descricao, cargaHoraria, publicoAlvo, valor);

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




}
