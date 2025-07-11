﻿using MercadoTesteAZ.Application.Repositories;
using MercadoTesteAZ.Domain.Entities.Produtos;

namespace MercadoTesteAZ.Application.Repositories.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        public Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(string categoriaId);
    }
}
