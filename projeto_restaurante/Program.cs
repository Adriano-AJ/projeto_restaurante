using projeto_restaurante;

internal class Program
{
     static Restaurante restaurante = new Restaurante();

    static void Main(string[] args)
    {
        bool exibir = true;

        do
        {
            
            ExibirMenu();
            string ?opt = Console.ReadLine();

            switch(opt)
            {
                case "0":
                        Console.WriteLine("Programa finalizado...");
                        exibir = false;
                        break;
                case "1":
                    CreateNewOrder();
                    Console.ReadKey();
                    break;
                case "2":
                    AddNewItem();
                    Console.ReadKey();
                    break;
                case "3":
                    RemoveItem();
                    Console.ReadKey();
                    break;
                case "4":
                    SearchOrder();
                    Console.ReadKey();
                    break;
                case "5":
                    CancelOrder();
                    Console.ReadKey();
                    break;
                case "6":
                    ListOrders();
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção invalida!!!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }

        }while(exibir);

        static bool ValidarEntrada(string entrada)
        {
            if (entrada == null || entrada == "") {
                throw new ArgumentNullException("A entrada não pode ser vazia, digite o nome do cliente!");
            }
            return true;
        }

        static void CreateNewOrder()
        {
            int id;
            string cliente;

            Console.WriteLine("Digite o número do id:");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Entrada invalida! Digite um número...");
            }

            do
            {
                Console.WriteLine("Digite o nome do cliente:");
                cliente = Console.ReadLine();

            } while (!ValidarEntrada(cliente));
            

            Pedido pedido = new Pedido(id, cliente);

            if (restaurante.novoPedido(pedido))
            {
                Console.WriteLine("Pedido realizado com sucesso.");
            }
            else { Console.WriteLine("Não foi possivel realizar o pedido."); }
            
        }
        static void AddNewItem()
        {
            int id, idPedido;
            double preco;
            string desc;

            Console.WriteLine("Digite o id do pedido em que o item será adicionado:");
            while (!int.TryParse(Console.ReadLine(), out idPedido))
            {
                Console.WriteLine("Entrada invalida! Digite um número...");
            }

            Pedido pedido = new Pedido(idPedido);

            pedido = restaurante.buscarPedido(pedido);
            if (pedido.Id != -1)
            {
                Console.WriteLine("Digite o número do id do item:");
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Entrada invalida! Digite um número...");
                }

                do
                {
                    Console.WriteLine("Digite a descrição do item:");
                    desc = Console.ReadLine();

                } while (!ValidarEntrada(desc));

                Console.WriteLine("Digite o preço do item:");
                while (!double.TryParse(Console.ReadLine(), out preco))
                {
                    Console.WriteLine("Entrada invalida! Digite um número...");
                }

                Item item = new Item(id, desc, preco);

                bool itemAdicionado = restaurante.Pedidos[idPedido].adicionarItem(item);

                if (itemAdicionado)
                {
                    Console.WriteLine($"item adicionado com sucesso ao pedido N°{idPedido}");
                }
                else
                {
                    Console.WriteLine("Não foi possivel adicionar o item ao pedido...");
                }
            }
            else
            {
                Console.WriteLine("Pedido não encontrado");
            }
        }
        static void RemoveItem()
        {
            int id, idPedido;

            Console.WriteLine("Digite o id do pedido em que o item será adicionado:");
            while (!int.TryParse(Console.ReadLine(), out idPedido))
            {
                Console.WriteLine("Entrada invalida! Digite um número...");
            }

            Pedido pedido = new Pedido(idPedido);

            pedido = restaurante.buscarPedido(pedido);
            if (pedido.Id != -1)
            {
                Console.WriteLine("Digite o número do id do item:");
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Entrada invalida! Digite um número...");
                }

                Item item = new Item(id);

                if (pedido.removerItem(item))
                {
                    Console.WriteLine($"Item N°{item.Id} removido.");
                }
                else { Console.WriteLine("Não foi possivel remover o item."); }
            }
            else { Console.WriteLine("Pedido não encontrado"); }
        }
        static void SearchOrder()
        {
            int id;

            Console.WriteLine("Digite o número do id do pedido:");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Entrada invalida! Digite um número...");
            }

            Pedido pedido = new Pedido(id);

            pedido = restaurante.buscarPedido(pedido);
            if ( pedido.Id != -1)
            {
                pedido.ToString();
            }
            else { Console.WriteLine("Pedido não encontrado."); }
        }
        static void CancelOrder()
        {
            int id;

            Console.WriteLine("Digite o número do id do pedido:");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Entrada invalida! Digite um número...");
            }

            Pedido pedido = new Pedido(id);

            if (restaurante.cancelarPedido(pedido))
            {
                Console.WriteLine("Pedido cancelado.");
            }
            else
            {
                Console.WriteLine("Não foi possivel cancelar o pedido.");
            };


        }
        static void ListOrders()
        {
            Console.WriteLine(restaurante.ToString());
        }

        static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("=        SISTEMA DE RESTAURANTE      =");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Criar novo pedido");
            Console.WriteLine("2. Adicionar item ao pedido");
            Console.WriteLine("3. Remover item do pedido");
            Console.WriteLine("4. Consultar pedido");
            Console.WriteLine("5. Cancelar pedido");
            Console.WriteLine("6. Listar todos os pedidos do dia");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("0. Sair");
            Console.WriteLine("======================================");
            Console.Write("Digite a opção desejada: ");
        }
    }
}
