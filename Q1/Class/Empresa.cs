namespace Q1.Class
{
    public class Empresa: Base
    {
        public Empresa() {}
        public Empresa(int id,string nome) : base (id){
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}