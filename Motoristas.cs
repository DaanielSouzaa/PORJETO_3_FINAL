using System;
using System.Collections.Generic;
using System.Text;

namespace PROJETO_3
{
    class Motoristas
    {
        private bool verificaCad(string option)
        {
            if(option == "s")
            {
                return true;
            }
            return false;
        }
        public void addMotoristas()
        {
            bool verificaCad = false;

            Console.WriteLine("Digite o cpf do motorista:");
            string cpf = Console.ReadLine();
            Menu.linha();
            Console.WriteLine("Digite o nome completo do motorista:");
            string nome = Console.ReadLine();

            Menu.linha();
            string status = "LIVRE";

            Console.WriteLine("Digite 's' para confirmar o cadastro:");
            verificaCad = this.verificaCad(Console.ReadLine());
            if(verificaCad == true)
            {
                Conn.insertQuery("INSERT INTO FROTA.MOTORISTAS(NOME,CPF,STATUS,DATA_CADASTRO) VALUES('" + nome + "','" + cpf + "','" + status + "',NOW())");
                Menu.linha();
            }            
        }
    }/* Class */
}/* Namespace */
