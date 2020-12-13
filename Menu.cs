using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace PROJETO_3
{
    class Menu
    {        
        public static void exibeMenu()
        {
            Console.WriteLine("1 - Cadastrar motorista!");
            Console.WriteLine("2 - Cadastrar carro!");
            Console.WriteLine("3 - Cadastrar viagem!");
            Console.WriteLine("4 - Finalizar viagem!");
            Console.WriteLine("5 - Relatório de viagens em andamento!");
            Console.WriteLine("6 - Relatório de viagens em encerradas!");
        }

        public static void linha()
        {
            Console.WriteLine("----------------------------------------");
        }
    }
}
