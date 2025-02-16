using EntitiesLayer.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace DataAcessLayer.DataAccess
{

    public class ReposBase<Entity>
        where Entity : class, new()
    {
        private IUnitOfWorkbase _UnitOfWork { get; set; }
        public ReposBase(IUnitOfWorkbase unitOfWorkbase)
        {
            _UnitOfWork = unitOfWorkbase;
            //GetList(t => t.Id);
        }
        /// <summary>
        /// select * from ffff where 
        /// inner join 
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public IList<Entity> GetList(Expression<Func<Entity, object>> Expression)

        {
            List<Entity> entities = new List<Entity>();

            using (var data = _UnitOfWork.GetDbContextWriter())
            {
                var entity = data.DbSet<Entity>().Find(Expression);

                entities.Add(entity);

            }

            return entities;

        }
        public void Add(Entity entity)

        {

            using (var data = _UnitOfWork.GetDbContextWriter())
            {
                data.DbSet<Entity>().Add(entity);
                data.SaveChanges();
            }

        }
    }
}
