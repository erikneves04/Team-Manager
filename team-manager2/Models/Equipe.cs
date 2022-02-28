namespace team_manager2.Models
{
    public class Equipe
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }

        public Equipe(string nome, string setor)
        {
            this.Nome = nome;
            this.Setor = setor;
        }
    }
}