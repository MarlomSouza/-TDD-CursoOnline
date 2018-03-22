using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "VariaveisDevemPossuirOMesmoValor")]
        public void VariaveisDevemPossuirOMesmoValor()
        {
            var variavel1 = 1;
            var variavel2 = 1;

            Assert.Equal(variavel1, variavel2);

        }
    }
}
