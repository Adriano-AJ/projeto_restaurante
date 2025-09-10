using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_restaurante
{
    internal class Restaurante
    {
        private static int _proxPedido = 0;
        private Pedido[] pedidos;

        public int ProxPedido { get => _proxPedido; set => _proxPedido = value; }
        public Pedido[] Pedidos { get => pedidos; set => pedidos = value; }
        
        public Restaurante() 
        {
            this.pedidos = new Pedido[50];
        }

        public bool novoPedido(Pedido pedido)
        {
            if (_proxPedido < 50)
            {
                this.pedidos[_proxPedido] = pedido;
                _proxPedido++;
            }
            else
            {
                return false;
            } 

            return true;
        }

        public Pedido buscarPedido(Pedido pedido)
        {
            Pedido pedidoProcurado = new Pedido();
            for(int i = 0; i < _proxPedido; i++)
            {
                if (pedido.Id == pedidos[i].Id)
                {
                    pedidoProcurado = pedidos[i];
                    break;
                }
            }

            return pedidoProcurado;
        }

        public bool cancelarPedido(Pedido pedido)
        {

            int j;
            bool podeCancelar = (buscarPedido(pedido).Id != -1);

            if (podeCancelar)
            {
                int i = 0;
                while (i < _proxPedido && this.pedidos[i].Id != pedido.Id)
                {
                    ++i;
                }
                for (j = i; j < _proxPedido - 1; ++j)
                {
                    this.pedidos[j] = this.pedidos[j + 1];
                }
                this.pedidos[j] = new Pedido();
                _proxPedido--;
            }
            return podeCancelar;

        }

        public override string ToString()
        {
            string txt;
            double somaTotal = 0;

            if (_proxPedido == 0) return "Não há pedidos feitos no sistema";

            txt = "------------ PEDIDOS ------------\n";

            for (int i = 0; i < _proxPedido; i++)
            {
                txt += pedidos[i].dadosDoPedido();
                somaTotal += pedidos[i].calcularTotal();
            }
            txt += "\n------------ PEDIDOS ------------\n";
            txt += $"SOMA TOTAL DOS VALORES: {somaTotal}";

            return txt;
        }
    }
}
