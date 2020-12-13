using System;
using System.Collections.Generic;
using System.Text;

namespace PROJETO_3
{
    class Viagens
    {
        public void addTrip()
        {
            bool validaMotorista = false;
            bool validaVeiculo = false;

            int id_motorista = -1;
            int id_veic = -1;

            while (validaMotorista == false || validaVeiculo == false)
            {
                Console.WriteLine("Escolha um dos motoristas disponíveis:");
                Conn.selectSql("SELECT ID,NOME,CPF FROM FROTA.MOTORISTAS WHERE STATUS = 'LIVRE';", 3);

                if (id_motorista < 0)
                {
                    try
                    {
                        id_motorista = int.Parse(Console.ReadLine());
                        validaMotorista = Conn.returnStatus("SELECT STATUS FROM FROTA.MOTORISTAS WHERE ID = "+id_motorista);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Valor inválido!");
                        id_motorista = -1;
                        validaMotorista = false;
                    }
                }
                Menu.linha();
                Console.WriteLine("Veiculos disponíveis");
                Conn.selectSql("SELECT ID,FABRICANTE,MODELO,PLACA,CHASSI FROM FROTA.VEICULOS WHERE STATUS = 'LIVRE';", 5);

                if (id_veic < 0)
                {
                    try
                    {
                        id_veic = int.Parse(Console.ReadLine());
                        validaVeiculo = Conn.returnStatus("SELECT STATUS FROM FROTA.VEICULOS WHERE ID = " + id_motorista);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Valor inválido!");
                        id_veic = -1;
                        validaMotorista = false;
                    }
                }/* if */
                if (validaVeiculo == false)
                {
                    id_veic = -1;
                }

                if (validaMotorista == false)
                {
                    id_motorista = -1;
                }
            }/* while */

            Conn.alteraStatus(id_motorista, id_veic, "OCUPADO");
        } /* addTrip() */

        public void fimTrip()
        {
            bool validEncerramento = false;

            exibeTrip("%","OCUPADO");
            Console.WriteLine("Escolha uma das viagens para encerrar");

            while (validEncerramento == false)
            {
                try
                {
                    Console.WriteLine("Escolha um id:");
                    int idTrip = int.Parse(Console.ReadLine());
                    Conn.fimTrip(idTrip);
                    validEncerramento = Conn.validEncerramento("SELECT STATUS FROM GESTAO_VEICULO_MOTORISTAS WHERE ID = "+idTrip);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Erro de formato!");
                }
            }
            
        }

        public void exibeTrip(string id,string status)
        {
            Console.WriteLine("-----------------------------");
            if(status == "ENCERRADA")
            {
                Console.WriteLine("VIAGENS ENCERRADAS");
            } else if(status == "OCUPADO")
            {
                Console.WriteLine("VIAGENS EM ANDAMENTO");
            }
            Menu.linha();
            Conn.selectSql("SELECT GM.ID,M.NOME,V.MODELO,GM.DATA_INICIO,GM.DATA_FIM FROM frota.gestao_veiculo_motoristas AS GM " +
                "INNER JOIN MOTORISTAS AS M ON M.ID = GM.ID_MOTORISTA INNER JOIN VEICULOS AS V ON V.ID = GM.ID_VEICULO WHERE 1=1" +
                " AND GM.STATUS = '"+status+ "' AND GM.ID like '" + id +"'; ", 5);
        }
    }
}
