using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace PROJETO_3
{
    class Conn
    {
        private static string returnConn()
        {
            return "server=localhost;database=frota;uid=root;password=;";
        }

        public static void insertQuery(string consulta)
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                try
                {
                    Menu.linha();
                    conn.ConnectionString = Conn.returnConn();
                    conn.Open();
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = consulta;
                    MySqlDataReader reader = command.ExecuteReader();
                    conn.Close();
                    Console.WriteLine("Insert realizado com sucesso!");
                } catch (MySqlException e)
                {
                    
                }

            }
        }/* insertQuery() */

        public static void selectSql(string consulta,int colunas)
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                try
                {
                    conn.ConnectionString = Conn.returnConn();
                    conn.Open();
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = consulta;
                    MySqlDataReader reader = command.ExecuteReader();
                    foreach (IDataRecord s in reader)
                    {
                        for (int i = 0; i < colunas; i++)
                        {
                            Console.Write(reader.GetName(i));
                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                        for (int i = 0; i < colunas; i++)
                        {
                            Console.Write(reader.GetString(i));
                            Console.Write(" | ");
                        }
                        Console.WriteLine();
                        Menu.linha();
                    }
                    conn.Close();
                }
                catch (MySqlException e)
                {
                   
                }

            }
        }/* selectSql() */

        public static void alteraStatus(int id_motorista,int id_veic,string status)
        {
            insertQuery("INSERT INTO GESTAO_VEICULO_MOTORISTAS(ID_VEICULO,ID_MOTORISTA,DATA_INICIO,DATA_FIM,STATUS) VALUES(" + id_veic + "," + id_motorista + ",NOW(),1969-12-12 00:00:01,'"+status+"')");
            insertQuery("UPDATE MOTORISTAS SET STATUS = '" + status + "' WHERE ID = " + id_motorista);
            insertQuery("UPDATE VEICULOS SET STATUS = '" + status + "' WHERE ID = " + id_veic);
        }

        public static void fimTrip(int idTrip)
        {

            int id_motorista = getId("SELECT ID_MOTORISTA FROM GESTAO_VEICULO_MOTORISTAS WHERE ID = " + idTrip + ";");
            int id_veiculos = getId("SELECT ID_VEICULO FROM GESTAO_VEICULO_MOTORISTAS WHERE ID = " + idTrip + ";");

            insertQuery("UPDATE GESTAO_VEICULO_MOTORISTAS SET DATA_FIM = NOW(),STATUS ='ENCERRADA' WHERE ID = "+idTrip+";");
            insertQuery("UPDATE MOTORISTAS SET STATUS = 'LIVRE' WHERE ID =" + id_motorista + ";");
            insertQuery("UPDATE VEICULOS SET STATUS = 'LIVRE' WHERE ID =" + id_veiculos + ";");

            Console.WriteLine("Viagem encerrada!");
            Menu.linha();
        }

        public static int getId (string consulta)
        {
            int id = -1;

            using (MySqlConnection conn = new MySqlConnection())
            {
                try
                {
                    conn.ConnectionString = Conn.returnConn();
                    conn.Open();
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = consulta;
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    id = reader.GetInt16(0);
                    conn.Close();
                }
                catch (MySqlException e)
                {

                }
            }
            return id;
        }/* returStatus */

        public static bool returnStatus(string consulta)
        {
            string status = "OCUPADO";

            using (MySqlConnection conn = new MySqlConnection())
            {
                try
                {
                    conn.ConnectionString = Conn.returnConn();
                    conn.Open();
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = consulta;
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    status = reader.GetString(0);
                    conn.Close();
                }
                catch (MySqlException e)
                {
                  
                }
            }

            if (status == "LIVRE")
            {
                return true;
            }

            return false;
        }/* returStatus */

        public static bool validEncerramento(string consulta)
        {
            string status = "OCUPADO";

            using (MySqlConnection conn = new MySqlConnection())
            {
                try
                {
                    conn.ConnectionString = Conn.returnConn();
                    conn.Open();
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = consulta;
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    status = reader.GetString(0);
                    conn.Close();
                }
                catch (MySqlException e)
                {

                }
            }
            if (status == "ENCERRADA")
            {
                return true;
            }

            return false;
        }

    }/* Class */
}/* Namespace */