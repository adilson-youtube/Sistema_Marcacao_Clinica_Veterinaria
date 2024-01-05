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
            return await _dbContext.Proprietarios.Include(p => p.Animais).ToListAsync();
        }

        public async Task<Proprietario> BuscarPorId(int Id)
        {
            return await _dbContext.Proprietarios.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Proprietario> Adicionar(Proprietario Proprietario)
        {
            await _dbContext.Proprietarios.AddAsync(Proprietario);
            _dbContext.SaveChanges();
            return Proprietario;
        }

        public async Task<Proprietario> Actualizar(Proprietario Proprietario, int Id)
        {
            Proprietario ProprietarioPorId = await BuscarPorId(Id);
            if (ProprietarioPorId == null)
            {
                throw new Exception($"Proprietario com o id {Id} não foi encontrado na BD");
            }

            ProprietarioPorId.Nome = Proprietario.Nome;
            ProprietarioPorId.Telefone = Proprietario.Telefone;
            ProprietarioPorId.DataNascimento = Proprietario.DataNascimento;
            ProprietarioPorId.Endereco = Proprietario.Endereco;
            ProprietarioPorId.Animais = Proprietario.Animais;

            _dbContext.Proprietarios.Update(ProprietarioPorId);
            _dbContext.SaveChanges();
            return ProprietarioPorId;
        }

        public async Task<bool> Apagar(int Id)
        {
            Proprietario ProprietarioPorId = await BuscarPorId(Id);
            if (ProprietarioPorId == null)
            {
                throw new Exception($"Proprietario com o id {Id} não foi encontrado na BD");
            }

            _dbContext.Proprietarios.Remove(ProprietarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
