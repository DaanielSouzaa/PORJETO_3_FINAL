using System;
using System.Collections.Generic;
using System.Text;

namespace PROJETO_3
{
    class Veiculos
    {
        public void addVeiculos()
        {

            Console.WriteLine("Digite o fabricante do veículo:");
            string fabricante = Console.ReadLine();

            Menu.linha();
            Console.WriteLine("Digite o modelo do veículo:");
            string modelo = Console.ReadLine();

            Menu.linha();
            Console.WriteLine("Digite a placa do veículo:");
            string placa = Console.ReadLine();

            Menu.linha();
            Console.WriteLine("Digite o chassi do veículo:");
            string chassi = Console.ReadLine();

            Menu.linha();
            string status = "LIVRE";

            Conn.insertQuery("INSERT INTO FROTA.VEICULOS(MODELO,FABRICANTE,PLACA,CHASSI,DATA_CADASTRO,STATUS) VALUES('" + modelo + "','" + fabricante + "','" + placa + "','" + chassi + "'," + "NOW(),'" + status + "');");
            Menu.linha();
        }/* addVeiculos */
    }/* class */
}/* namespace */
