using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public VeterinarioRepository(MarcacaoClinicaVeterinariaDBContext _dbContext) 
        {
            _dbContext = _dbContext;
        }

        public async Task<List<Veterinario>> ListarAnimais()
        {
            return await _dbContext.Veterinarios.ToListAsync();
        }

        public async Task<Veterinario> BuscarPorId(int id)
        {
            return await _dbContext.Veterinarios.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Veterinario> Adicionar(Veterinario veterinario)
        {
            await _dbContext.Veterinarios.AddAsync(veterinario);
            _dbContext.SaveChangesAsync();
            return veterinario;
        }

        public async Task<Veterinario> Actualizar(Veterinario veterinario, int id)
        {
            Veterinario veterinarioPorId = await BuscarPorId(id);
            if (veterinarioPorId == null)
            {
                throw new Exception($"Veterinario com o id {id} não foi encontrado na BD");
            }

            veterinarioPorId.nome = veterinarioPorId.nome;
            veterinarioPorId.especialidade = veterinarioPorId.especialidade;
            veterinarioPorId.marcacoes = veterinarioPorId.marcacoes;

            _dbContext.Veterinarios.Update(veterinarioPorId);
            _dbContext.SaveChangesAsync();
            return veterinarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Veterinario veterinarioPorId = await BuscarPorId(id);
            if (veterinarioPorId == null)
            {
                throw new Exception($"Veterinario com o id {id} não foi encontrado na BD");
            }

            _dbContext.Veterinarios.Remove(veterinarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
