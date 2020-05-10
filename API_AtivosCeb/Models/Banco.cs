using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models
{
    public class Banco
    {
        public static string conexao = @"Data Source=SRVCEB02\TICEB;Initial Catalog=ativos;User ID=sqladmin;Password=Anchor3128;";

        public static int RemoverCategoria(int idCategoria)
        {
            string sql = "DeletarCategoria";

            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                con.Open();
                idCategoria = Convert.ToInt32(comando.ExecuteScalar());
            }
            return idCategoria;
        }

        public static List<reparos> ListarReparos()
        {
            reparos reparos;
            List<reparos> listarReparos = new List<reparos>();
            string sql = "ListarReparos";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        reparos = new reparos();
                        reparos.idReparo = Convert.ToInt32(read["ID"]);
                        reparos.idAtivo = Convert.ToInt32(read["idAtivo"].ToString());
                        reparos.dataEnvio = read["dataEnvio"].ToString();
                        reparos.dataRetorno = read["dataRetorno"].ToString();
                        reparos.descDefeito = read["descDefeito"].ToString();
                        reparos.situacao = read["situacao"].ToString();
                        listarReparos.Add(reparos);
                    }
                }
                return listarReparos;
            }
        }

        public static List<categorias> ListarCategorias()
        {
            categorias categorias;
            List<categorias> listarCategorias = new List<categorias>();
            string sql = "ListarCategoria";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        categorias = new categorias();
                        categorias.idCategoria = Convert.ToInt32(read["ID"]);
                        categorias.descCategoria = read["descCategoria"].ToString();
                        listarCategorias.Add(categorias);
                    }
                }
                return listarCategorias;
            }
        }

        public static String ObterDescCategoriaPorId(int idCategoria)
        {
            String descCategoria = "";
            string sql = "ObterDescCategoriaPorId";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {                        
                        descCategoria = read["DescCategoria"].ToString();
                    }
                }
                return descCategoria;
            }
        }

        public static String ObterDescFabricantePorId(int idFabricante)
        {
            String descFabricante = "";
            string sql = "ObterDescFabricantePorId";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idFabricante", idFabricante);
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        descFabricante = read["DescFabricante"].ToString();
                    }
                }
                return descFabricante;
            }
        }

        public static String ObterDescLocalPorId(int idLocal)
        {
            String descLocal = "";
            string sql = "ObterDescLocalPorId";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idLocal", idLocal);
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        descLocal = read["DescLocal"].ToString();
                    }
                }
                return descLocal;
            }
        }

        public static String ObterDescPisoPorId(int idPiso)
        {
            String descPiso = "";
            string sql = "ObterDescPisoPorId";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPiso", idPiso);
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        descPiso = read["DescPiso"].ToString();
                    }
                }
                return descPiso;
            }
        }

        public static int ObterIdPisoPorDescricao(string descPiso)
        {
            int idPiso = 0;
            string sql = "ObterIdPisoPorDescricao";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@descPiso", descPiso);
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        idPiso = Convert.ToInt32(read["ID"]);
                    }
                }
                return idPiso;
            }
        }

        public static int ObterIdLocalPorDescricao(string descLocal)
        {
            int idLocal = 0;
            string sql = "ObterIdLocalPorDescricao";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@descLocal", descLocal);
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        idLocal = Convert.ToInt32(read["ID"]);
                    }
                }
                return idLocal;
            }
        }

        public static int ObterIdFabricantePorDescricao(string descFabricante)
        {
            int idFabricante = 0;
            string sql = "ObterIdFabricantePorDescricao";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@descFabricante", descFabricante);
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        idFabricante = Convert.ToInt32(read["ID"]);
                    }
                }
                return idFabricante;
            }
        }

        public static int ObterIdCategoriaPorDescricao(string descCategoria)
        {
            int idCategoria = 0;
            string sql = "ObterIdCategoriaPorDescricao";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@descCategoria", descCategoria);
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        idCategoria = Convert.ToInt32(read["ID"].ToString());
                    }
                }
                return idCategoria;
            }
        }

        public static List<fabricantes> ListarFabricantes()
        {
            fabricantes fabricantes;
            List<fabricantes> listarFabricantes = new List<fabricantes>();
            string sql = "ListarFabricante";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        fabricantes = new fabricantes();
                        fabricantes.idFabricante = Convert.ToInt32(read["ID"]);
                        fabricantes.descFabricante = read["descFabricante"].ToString();
                        listarFabricantes.Add(fabricantes);
                    }
                }
                return listarFabricantes;
            }
        }

        public static List<locais> ListarLocais()
        {
            locais locais;
            List<locais> listarLocais = new List<locais>();
            string sql = "ListarLocais";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        locais = new locais();
                        locais.idLocal = Convert.ToInt32(read["ID"]);
                        locais.descLocal = read["descLocal"].ToString();
                        listarLocais.Add(locais);
                    }
                }
                return listarLocais;
            }
        }

        public static List<pisos> ListarPisos()
        {
            pisos pisos;
            List<pisos> listarPisos = new List<pisos>();
            string sql = "ListarPiso";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        pisos = new pisos();
                        pisos.idPiso = Convert.ToInt32(read["ID"]);
                        pisos.descPiso = read["descPiso"].ToString();
                        listarPisos.Add(pisos);
                    }
                }
                return listarPisos;
            }
        }

        public static List<logs> ListarLogs()
        {
            logs logs;
            List<logs> listarLogs = new List<logs>();
            string sql = "ListarLogs";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        logs = new logs();
                        logs.idLogs = Convert.ToInt32(read["ID"].ToString());
                        logs.data = read["data"].ToString();
                        logs.hora = read["hora"].ToString();
                        logs.usuario = read["usuario"].ToString();
                        logs.mensagem = read["mensagem"].ToString();
                        logs.idAtivo = Convert.ToInt32(read["idAtivo"].ToString());
                        listarLogs.Add(logs);
                    }
                }
                return listarLogs;
            }
        }

        public static List<string> ListarModelos(int idCategoria)
        {
            List<string> listarModelos = new List<string>();
            string sql = "ListarModelos";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idCategoria", idCategoria);
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        listarModelos.Add(read["modelo"].ToString());
                    }
                }
                return listarModelos;
            }
        }

        public static List<ativos> ListarAtivos()
        {
            ativos ativos;
            List<ativos> listarAtivos = new List<ativos>();
            string sql = "ListarAtivos";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader read;
                con.Open();

                using (read = comando.ExecuteReader())
                {
                    while (read.Read())
                    {
                        ativos = new ativos();
                        ativos.idAtivo = Convert.ToInt32(read["ID"]);
                        ativos.item = read["item"].ToString();
                        ativos.idPiso = Convert.ToInt32(read["idPiso"]);
                        ativos.idLocal = Convert.ToInt32(read["idLocal"]);
                        ativos.idFabricante = Convert.ToInt32(read["idFabricante"]);
                        ativos.modelo = read["modelo"].ToString();
                        ativos.comentarios = read["comentarios"].ToString();
                        ativos.dataRetirada = read["dataRetirada"].ToString();
                        ativos.dataRegistro = read["dataRegistro"].ToString();
                        ativos.valor = Convert.ToDecimal(read["valor"].ToString());
                        ativos.condicao = read["condicao"].ToString();
                        ativos.idCategoria = Convert.ToInt32(read["idCategoria"]);
                        ativos.serviceTag = read["serviceTag"].ToString();
                        ativos.patrimonio = Convert.ToInt32(read["patrimonio"].ToString());
                        ativos.garantia = read["garantia"].ToString();
                        ativos.numeroSerie = read["numeroSerie"].ToString();
                        listarAtivos.Add(ativos);
                    }
                }
                return listarAtivos;
            }
        }

        public static int InserirCategoria(categorias categorias)
        {
            string sql = "InserirCategoria";

            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@descCategoria", categorias.descCategoria);
                con.Open();
                categorias.idCategoria = Convert.ToInt32(comando.ExecuteScalar());
            }
            return categorias.idCategoria;
        }

        public static int InserirFabricante(fabricantes fabricantes)
        {
            string sql = "InserirFabricante";

            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@descFabricante", fabricantes.descFabricante);
                con.Open();
                fabricantes.idFabricante = Convert.ToInt32(comando.ExecuteScalar());
            }
            return fabricantes.idFabricante;
        }

        public static int InserirLocal(locais locais)
        {
            string sql = "InserirLocal";

            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@descLocal", locais.descLocal);
                con.Open();
                locais.idLocal = Convert.ToInt32(comando.ExecuteScalar());
            }
            return locais.idLocal;
        }

        public static int InserirPiso(pisos pisos)
        {
            string sql = "InserirPiso";

            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@descPiso", pisos.descPiso);
                con.Open();
                pisos.idPiso = Convert.ToInt32(comando.ExecuteScalar());
            }
            return pisos.idPiso;
        }

        public static int AtualizarAtivo(ativos ativos)
        {
            string sql = "AtualizarAtivo";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAtivo", ativos.idAtivo);
                comando.Parameters.AddWithValue("@item", ativos.item);
                comando.Parameters.AddWithValue("@idPiso", ativos.idPiso);
                comando.Parameters.AddWithValue("@idLocal", ativos.idLocal);
                comando.Parameters.AddWithValue("@idFabricante", ativos.idFabricante);
                comando.Parameters.AddWithValue("@modelo", ativos.modelo);
                comando.Parameters.AddWithValue("@comentarios", ativos.comentarios);
                comando.Parameters.AddWithValue("@valor", ativos.valor);
                comando.Parameters.AddWithValue("@condicao", ativos.condicao);
                comando.Parameters.AddWithValue("@idCategoria", ativos.idCategoria);
                comando.Parameters.AddWithValue("@serviceTag", ativos.serviceTag);
                comando.Parameters.AddWithValue("@patrimonio", ativos.patrimonio);
                comando.Parameters.AddWithValue("@numeroSerie", ativos.numeroSerie);
                con.Open();
                ativos.idAtivo = Convert.ToInt32(comando.ExecuteScalar());
            }
            return ativos.idAtivo;
        }

        public static int InserirAtivo(ativos ativos)
        {
            string sql = "InserirAtivo";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@item", ativos.item);
                comando.Parameters.AddWithValue("@idPiso", ativos.idPiso);
                comando.Parameters.AddWithValue("@idLocal", ativos.idLocal);
                comando.Parameters.AddWithValue("@idFabricante", ativos.idFabricante);
                comando.Parameters.AddWithValue("@modelo", ativos.modelo);
                comando.Parameters.AddWithValue("@comentarios", ativos.comentarios);
                comando.Parameters.AddWithValue("@dataRegistro", ativos.dataRegistro);
                comando.Parameters.AddWithValue("@valor", ativos.valor);
                comando.Parameters.AddWithValue("@condicao", ativos.condicao);
                comando.Parameters.AddWithValue("@idCategoria", ativos.idCategoria);
                comando.Parameters.AddWithValue("@serviceTag", ativos.serviceTag);
                comando.Parameters.AddWithValue("@patrimonio", ativos.patrimonio);
                comando.Parameters.AddWithValue("@garantia", ativos.garantia);
                comando.Parameters.AddWithValue("@numeroSerie", ativos.numeroSerie);
                con.Open();
                ativos.idAtivo = Convert.ToInt32(comando.ExecuteScalar());
            }
            return ativos.idAtivo;
        }

        public static int InserirReparo(reparos reparo)
        {
            string sql = "InserirReparo";

            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAtivo", reparo.idAtivo);
                comando.Parameters.AddWithValue("@dataEnvio", reparo.dataEnvio);
                comando.Parameters.AddWithValue("@descDefeito", reparo.descDefeito);
                comando.Parameters.AddWithValue("@situacao", reparo.situacao);
                con.Open();
                reparo.idReparo = Convert.ToInt32(comando.ExecuteScalar());
            }
            return reparo.idReparo;
        }

        public static int InserirLog(logs log)
        {
            string sql = "InserirLog";

            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;                
                comando.Parameters.AddWithValue("@data", log.data);
                comando.Parameters.AddWithValue("@hora", log.hora);
                comando.Parameters.AddWithValue("@usuario", log.usuario);
                comando.Parameters.AddWithValue("@mensagem", log.mensagem);
                comando.Parameters.AddWithValue("@idAtivo", log.idAtivo);
                con.Open();
                log.idLogs = Convert.ToInt32(comando.ExecuteScalar());
            }
            return log.idLogs;
        }

        public static int AlterarCondicao(ativos ativos)
        {
            string sql = "AlterarCondicao";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAtivo", ativos.idAtivo);
                comando.Parameters.AddWithValue("@condicao", ativos.condicao);
                con.Open();
                ativos.idAtivo = Convert.ToInt32(comando.ExecuteScalar());
            }
            return ativos.idAtivo;
        }

        public static int FinalizarReparo(reparos reparos)
        {
            string sql = "FinalizarReparo";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idReparo", reparos.idReparo);
                comando.Parameters.AddWithValue("@dataRetorno", reparos.dataRetorno);
                comando.Parameters.AddWithValue("@situacao", reparos.situacao);
                con.Open();
                reparos.idReparo = Convert.ToInt32(comando.ExecuteScalar());
            }
            return reparos.idReparo;
        }

        public static int DescontinuarAtivo(ativos ativos)
        {
            string sql = "DescontinuarAtivo";
            using (var con = new SqlConnection(conexao))
            {
                var comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAtivo", ativos.idAtivo);
                comando.Parameters.AddWithValue("@item", ativos.item);
                comando.Parameters.AddWithValue("@idPiso", ativos.idPiso);
                comando.Parameters.AddWithValue("@idLocal", ativos.idLocal);
                comando.Parameters.AddWithValue("@idFabricante", ativos.idFabricante);
                comando.Parameters.AddWithValue("@modelo", ativos.modelo);
                comando.Parameters.AddWithValue("@comentarios", ativos.comentarios);
                comando.Parameters.AddWithValue("@dataRetirada", ativos.dataRetirada);
                comando.Parameters.AddWithValue("@valor", ativos.valor);
                comando.Parameters.AddWithValue("@condicao", ativos.condicao);
                comando.Parameters.AddWithValue("@idCategoria", ativos.idCategoria);
                comando.Parameters.AddWithValue("@serviceTag", ativos.serviceTag);
                comando.Parameters.AddWithValue("@patrimonio", ativos.patrimonio);
                comando.Parameters.AddWithValue("@numeroSerie", ativos.numeroSerie);
                con.Open();
                ativos.idAtivo = Convert.ToInt32(comando.ExecuteScalar());
            }
            return ativos.idAtivo;
        }
    }
}