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

        public static String ObterDescricaoCategorias(int idCategoria)
        {
            String descricao = "";
            string sql = "ObterDescricaoCategorias";
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
                        descricao = read["descCategoria"].ToString();
                    }
                }
                return descricao;
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
                        ativos.idPiso = Convert.ToInt32(read["idPiso"].ToString());
                        ativos.idLocal = Convert.ToInt32(read["idLocal"].ToString());
                        ativos.idFabricante = Convert.ToInt32(read["idFabricante"].ToString());
                        ativos.modelo = read["modelo"].ToString();
                        ativos.comentarios = read["comentarios"].ToString();
                        ativos.dataRetirada = read["dataRetirada"].ToString();
                        ativos.dataRegistro = read["dataRegistro"].ToString();
                        ativos.valor = Convert.ToDecimal(read["valor"].ToString());
                        ativos.condicao = read["condicao"].ToString();
                        ativos.idCategoria = Convert.ToInt32(read["idCategoria"].ToString());
                        ativos.serviceTag = read["serviceTag"].ToString();
                        ativos.patrimonio = Convert.ToInt32(read["patrimonio"].ToString());
                        ativos.garantia = read["garantia"].ToString();
                        ativos.numeroSerie = read["numeroSerie"].ToString();
                        ativos.notaFiscal = read["notaFiscal"].ToString();
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
    }
}