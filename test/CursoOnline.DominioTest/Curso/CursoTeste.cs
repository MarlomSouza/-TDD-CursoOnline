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
                PublicoAlvo = "Estudantes",
                Valor = 10.0M
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }



    }

  
    public class Curso
    {
        public Curso(string nome, int cargaHoraria, string publicoAlvo, decimal valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; internal set; }
        public int CargaHoraria { get; internal set; }
        public string PublicoAlvo { get; internal set; }
        public decimal Valor { get; internal set; }
    }
}
