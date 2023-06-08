﻿using Sistema_Marcacao_Clinica_Veterinaria.Models;

namespace Sistema_Marcacao_Clinica_Veterinaria.Repositories.Interfaces
{
    public interface IServicoRepository
    {
        Task<List<Servico>> ListarServicos();
        Task<Servico> Adicionar(Servico servico);
        Task<Servico> BuscarPorId(int id);
        Task<Servico> Actualizar(Servico servico, int id);
        Task<bool> Apagar(int id);

    }
}
