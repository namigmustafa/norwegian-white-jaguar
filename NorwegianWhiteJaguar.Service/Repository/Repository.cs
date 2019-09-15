using NorwegianWhiteJaguar.Interface.Repository;
using NorwegianWhiteJaguar.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace NorwegianWhiteJaguar.Service.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly List<TEntity> entities = new List<TEntity>();
        protected readonly DataSet dataSet = new DataSet();
        //public Repository()
        //{
        //    var ent = new List<Customer>
        //    {
        //        new Customer
        //        {
        //            Id = 1,
        //            Name = "Paul",
        //            Surname = "Marker",
        //            Accounts = new List<Account>
        //            {
        //               new Account
        //               {
        //                   Id = 1,
        //                   Number = "LV1084HABA34387348374837",
        //                   Balance = 500,
        //                   FriendlyName = "Salary"
        //               }
        //            }
        //        }
        //    };

        //    entities.
        //}
        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            return entities.Find(e => e.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities;
        }

        public void Insert(TEntity entity)
        {
            entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
