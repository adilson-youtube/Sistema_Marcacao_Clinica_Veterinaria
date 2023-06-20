namespace Sistema_Marcacao_Clinica_Veterinaria.Models
{
    public class Especie
    {
        public int id { get; set; }
        public string? raca { get; set; }
        public ICollection<Animal>? animais { get; set; }

        public Especie() { }   
    }
}
