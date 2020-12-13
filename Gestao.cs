using System;
using System.Data.SqlClient;

namespace PROJETO_3
{
    class Gestao
    {
        static void Main(string[] args)
        {
            Motoristas motoristas = new Motoristas();
            Veiculos veiculos = new Veiculos();
            Viagens viagens = new Viagens();

            string resposta = "s";

            while (resposta == "s")
            {
                rodaMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        motoristas.addMotoristas();
                        break;
                    case "2":
                        veiculos.addVeiculos();
                        break;
                    case "3":
                        viagens.addTrip();
                        break;
                    case "4":
                        viagens.fimTrip();
                        break;
                    case "5":
                        viagens.exibeTrip("%","OCUPADO");
                        break;
                    case "6":
                        viagens.exibeTrip("%", "ENCERRADA");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }/* switch */
            }/* while */
        } /* Main */

        public static void rodaMenu()
        {
            Menu.exibeMenu();
        }
    }
}
