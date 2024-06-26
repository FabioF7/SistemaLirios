﻿using SistemaLirios.Models;

namespace SistemaLirios.Repository.Interfaces
{
    public interface IGastosRepository
    {
        Task<List<GastosModel>> BuscarTodosGastos();
        Task<GastosModel> BuscarPorId(int id);
        Task<List<GastosModel>> BuscarPorTipoServicoId(int TipoServicoId);
        Task<List<GastosModel>> BuscarRecorrente();
        Task<List<GastosModel>> BuscarPorData(DateTime dataInicio, DateTime dataFim);

        Task<GastosModel> Insert(GastosModel Gastos);
        Task<GastosModel> Update(GastosModel Gastos, int id);

        Task<bool> Delete(int id);
    }
}
