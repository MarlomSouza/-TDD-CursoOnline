using CursoOnline.DominioTest.Cursos;


namespace CursoOnline.DominioTest._Builders
{
    public class CursoBuilder
    {
        private string nome = "Curso 1";
        private int cargaHoraria = 20;
        private PublicoAlvo publicoAlvo = PublicoAlvo.Estudante;
        private decimal valor = 10.0M;
        private string descricao = "uma descricao";

        public static CursoBuilder New() => new CursoBuilder();

        public CursoBuilder ComNome(string nome)
        {
            this.nome = nome;
            return this;
        }

        public CursoBuilder ComCargaHoraria(int cargaHoraria)
        {
            this.cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            this.descricao = descricao;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            this.publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComValor(decimal valor)
        {
            this.valor = valor;
            return this;
        }

        public Curso Build() => new Curso(nome,descricao, cargaHoraria, publicoAlvo, valor);
    }
}
