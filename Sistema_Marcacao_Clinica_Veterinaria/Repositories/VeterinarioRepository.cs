using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public VeterinarioRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Veterinario>> ListarVeterinarios()
        {
            return await _dbContext.Veterinarios.ToListAsync();
        }

        public async Task<Veterinario> BuscarPorId(int Id)
        {
            return await _dbContext.Veterinarios.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Veterinario> Adicionar(Veterinario Veterinario)
        {
            await _dbContext.Veterinarios.AddAsync(Veterinario);
            _dbContext.SaveChanges();
            return Veterinario;
        }

        public async Task<Veterinario> Actualizar(Veterinario Veterinario, int Id)
        {
            Veterinario VeterinarioPorId = await BuscarPorId(Id);
            if (VeterinarioPorId == null)
            {
                throw new Exception($"Veterinario com o id {Id} não foi encontrado na BD");
            }

            VeterinarioPorId.Nome = Veterinario.Nome;
            VeterinarioPorId.Genero = Veterinario.Genero;
            VeterinarioPorId.Especialidade = Veterinario.Especialidade;
            VeterinarioPorId.Marcacoes = Veterinario.Marcacoes;

            _dbContext.Veterinarios.Update(VeterinarioPorId);
            _dbContext.SaveChanges();
            return VeterinarioPorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Veterinario VeterinarioPorId = await BuscarPorId(Id);
            if (VeterinarioPorId == null)
            {
                throw new Exception($"Veterinario com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Veterinarios.Remove(VeterinarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
