using System.ComponentModel;

namespace Sistema_Marcacao_Clinica_Veterinaria.Enums
{
    public enum Role
    {
        [Description("Usuario do Sistema")]
        Usuario = 1,
        [Description("Veterinario da Clínica")]
        Veterinario = 2,
        [Description("Secretário da Clínica")]
        Secretario = 3,
        [Description("Gestor do Sistema")]
        Gestor = 4,
        [Description("Administrador do Sistema")]
        Administrador = 4
    }
}
