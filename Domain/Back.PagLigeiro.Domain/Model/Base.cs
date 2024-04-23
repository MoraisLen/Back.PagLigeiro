using System;

namespace Back.PagLigeiro.Domain.Model
{
    public abstract class Base
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }

        public Base()
        {
            DataCadastro = DateTime.Now;
        }
    }
}
