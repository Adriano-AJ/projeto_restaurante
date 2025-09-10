using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace projeto_restaurante
{
    internal class Pedido
    {
        private int _id;
        private string _cliente;
        private Item[] _items;
        private int _qtdItems;

        public int Id { get => _id; set => _id = value; }
        public string Cliente { get => _cliente; set => _cliente = value; }
        public Item[] Items { get => _items; set => _items = value; }
        public int QtdItems { get => _qtdItems; set => _qtdItems = value; }

        public Pedido(int id, string cliente)
        {
            this._id = id;
            this._cliente = cliente;
            this._items = new Item[10];
            this._qtdItems = 0;
        }

        public Pedido(int id) : this(id, "")
        {

        }
        public Pedido() : this(-1, "") { }

        public bool adicionarItem(Item item) 
        {   
            if(this._qtdItems < 10)
            {
                this._items[_qtdItems++] = item;
            }
            else
            {
                return false;
            }
            
            return true;
        }

        public bool removerItem(Item item)
        {
            int indice = -1;

            for(int i = 0; i < _qtdItems; i++)
            {
                if (item.Id == _items[i].Id)
                {
                    indice = i;
                    break;
                }
            }

            if(indice != -1) { 

                for(int j = indice; j < _qtdItems - 1; j++)
                {
                    _items[j] = _items[j + 1];
                   
                }

                _items[_qtdItems - 1] = null;
                _qtdItems--;

                return true;
            }

            return false;
        }

        public string dadosDoPedido()
        {
            string txt;

            txt = $"Id: {this._id}\n" +
                $"Cliente: {this._cliente}\n" +
                $"- Itens do pedido -\n";

            for(int i = 0 ; i < _qtdItems; i++)
            {
               txt += _items[i].ToString();
            }

            return txt;
        }
        
        public double calcularTotal()
        {
            double total = 0;

            for(int i = 0; i < _qtdItems; i++)
            {
                total += _items[i].Preco;
            }

            return total;
        }

        public override bool Equals(object obj)
        {
            return (this._id == ((Pedido)obj).Id);
        }
    }
}
