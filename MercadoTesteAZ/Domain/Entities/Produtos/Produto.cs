﻿using MercadoTesteAZ.Domain.Entities.Categorias;
using MercadoTesteAZ.Domain.Entities.Interfaces;

namespace MercadoTesteAZ.Domain.Entities.Produtos
{
    public class Produto : IEntity
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Fabricante { get; private set; }
        public decimal Preco { get; private set; }
        public string ImagemURL { get; private set; }
        public string CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }
        public IEnumerable<HistoricoPreco>? HistoricoDePrecos { get; private set; }

    }
}
