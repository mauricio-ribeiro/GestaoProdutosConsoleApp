﻿namespace GestaoProdutosConsoleApp.Models
{
    public class Produto
    {
        public string Descricao { get; set; }
        public double ValorVenda { get; set; }
        public double ValorCompra { get; set; }
        public TipoProduto Tipo { get; set; }
        public DateTime DataCriacao { get; set; }

        public double MargemLucro => ValorVenda - ValorCompra;
    }
}