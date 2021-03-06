﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models.Repositorios
{
    public class RepositorioCategorias : Interfaces.InterfaceCategorias
    {
        public categorias Add(categorias item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Banco.InserirCategoria(item);
            return item;
        }

        public categorias Get(int id)
        {
            return Banco.ListarCategorias().Find(p => p.idCategoria == id);
        }

        public String GetDescCategoriaPorId(int id)
        {
            return Banco.ObterDescCategoriaPorId(id);
        }

        public IEnumerable<categorias> GetAll()
        {
            return Banco.ListarCategorias();
        }

        public void Remove(int idCategoria)
        {
            Banco.RemoverCategoria(idCategoria: idCategoria);
        }

        public bool Update(categorias item)
        {
            throw new NotImplementedException();
        }
    }
}