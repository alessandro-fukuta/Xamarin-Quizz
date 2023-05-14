using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace xTCC_Questoes.Model
{
    public class Conexao
    {


        public string StrConexao = "host=192.168.1.250;" +
                                   "port=3306;"+
                                   "database=xtcc_questoes;" +
                                   "user=fukuta;" +
                                   "password=Se39iry0#";

        public MySqlConnection conn = null;
        public ArrayList Clientes = new ArrayList();
        public bool ret = false;
        public string ErroMSG;
        public string StrQuery = "";
        public MySqlDataReader Dr;


        public Conexao()
        {

        }

        public bool Abre_Conexao()
        {
            try
            {
                conn = new MySqlConnection(StrConexao);
                conn.Open();
                //   Toast.MakeText(Application.Context, "MYSQL CONECTADO" , ToastLength.Long).Show();

                ret = true;
            }
            catch (Exception ex)
            {
                ErroMSG = "Erro ao conectar" + ex;
                ret = false;
            }

            return ret;

        }

        public bool Fecha_Conexao()
        {
            try
            {
                conn = new MySqlConnection(StrConexao);
                conn.Close();
                ret = true;
            }
            catch (Exception ex)
            {
                ErroMSG = "Erro ao conectar" + ex;
                ret = false;
            }

            return ret;

        }

    }
}