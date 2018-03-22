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
            string nome = "Curso 1";
            int cargaHoraria = 20;
            string publicoAlvo = "Estudantes";
            decimal valor = 10.0M;

            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            Assert.Equal(nome, curso.Nome);
            Assert.Equal(cargaHoraria, curso.CargaHoraria);
            Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(valor, curso.Valor);

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
