using Microsoft.EntityFrameworkCore;
using Sistema_Marcacao_Clinica_Veterinaria.Data;
using Sistema_Marcacao_Clinica_Veterinaria.Models;
using Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories
{
    public class ProprietarioRepository : IProprietarioRepository
    {
        private readonly MarcacaoClinicaVeterinariaDBContext _dbContext;

        public ProprietarioRepository(MarcacaoClinicaVeterinariaDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Proprietario>> ListarProprietarios()
        {
            return await _dbContext.Proprietarios.Include(p => p.animais).ToListAsync();
        }

        public async Task<Proprietario> BuscarPorId(int id)
        {
            return await _dbContext.Proprietarios.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Proprietario> Adicionar(Proprietario proprietario)
        {
            await _dbContext.Proprietarios.AddAsync(proprietario);
            _dbContext.SaveChanges();
            return proprietario;
        }

        public async Task<Proprietario> Actualizar(Proprietario proprietario, int id)
        {
            Proprietario proprietarioPorId = await BuscarPorId(id);
            if (proprietarioPorId == null)
            {
                throw new Exception($"Proprietario com o id {id} não foi encontrado na BD");
            }

            proprietarioPorId.nome = proprietarioPorId.nome;
            proprietarioPorId.telefone = proprietarioPorId.telefone;
            proprietarioPorId.dataNascimento = proprietarioPorId.dataNascimento;
            proprietarioPorId.endereco = proprietarioPorId.endereco;
            proprietarioPorId.animais = proprietarioPorId.animais;

            _dbContext.Proprietarios.Update(proprietarioPorId);
            _dbContext.SaveChanges();
            return proprietarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Proprietario proprietarioPorId = await BuscarPorId(id);
            if (proprietarioPorId == null)
            {
                throw new Exception($"Proprietario com o id {id} não foi encontrado na BD");
            }

            _dbContext.Proprietarios.Remove(proprietarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
