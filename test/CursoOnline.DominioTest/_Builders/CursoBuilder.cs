using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest.Cursos;


namespace CursoOnline.DominioTest._Builders
{
    public class CursoBuilder
    {
        
        private string nome;
        private int cargaHoraria;
        private PublicoAlvo publicoAlvo;
        private decimal valor;
        private string descricao;

   

        public static CursoBuilder New()
        {
            var faker = new Faker();

            var cursoBuilder = new CursoBuilder
            {
                nome = faker.Name.FullName(),
                cargaHoraria = faker.Random.Int(1, 100),
                publicoAlvo = faker.PickRandom(PublicoAlvo.Empreendedor, PublicoAlvo.Emprego, PublicoAlvo.Estudante, PublicoAlvo.Universitario),
                valor = faker.Random.Decimal(0.99M, 1000.00M),
                descricao = faker.Lorem.Paragraph()
            };

            return cursoBuilder;
        }

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
