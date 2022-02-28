namespace team_manager2.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public Equipe Equipe { get; set; }
        public int Equipe_id { get; set; }

        public Funcionario() { }

        public Funcionario(string nome, string cargo, int equipe_id, Equipe equipe, string email = null)
        {
            this.Nome = nome;
            this.Cargo = cargo;
            this.Email = email;
            this.Equipe = equipe;
            this.Equipe_id = equipe_id;
        }
    }
}