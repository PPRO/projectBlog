﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    /// <summary>
    /// Základní rozhraní pro DAO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDaoBase <T>
    {
        IList<T> GetAll();

        object Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);
    }
}
