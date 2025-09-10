using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_restaurante
{
    internal class Item
    {
        private int _id;
        private string _descricao;
        private double _preco;

        public int Id { get => _id;}
        public string Descricao { get => _descricao; set => _descricao = value; }
        public double Preco { get => _preco; set => _preco = value; }
        public Item(int id, string descricao, double preco) 
        {
            this._id= id;
            this._descricao = descricao; 
            this._preco = preco;
        }
        public Item(int id): this(id, "", 0.0)
        {

        }

        public override string ToString()
        {
            return $"Id - Item: {this._id} | Descricao - Item: {this._descricao} | Preco - Item: {this._preco}\n";
        }
    }
}
