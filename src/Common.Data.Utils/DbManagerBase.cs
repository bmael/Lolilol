namespace Common.Data.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    using Common.Data.Managers;
    using Common.Data.Models;

    using ServiceStack.OrmLite;

    using Tools.Linq.Expressions;

    /// <summary>
    /// The database manager base class.
    /// </summary>
    /// <typeparam name="TI">
    /// The type to manage interface.
    /// </typeparam>
    /// <typeparam name="T">
    /// A implementation of TI, must be specified because OrmLite need a concrete type.
    /// </typeparam>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Just learn what Orm mean already :o.")]
    public abstract class DbManagerBase<TI, T> : ICrudManager<TI>, IGetManager<TI>, ISearchManager<TI>
        where TI : IHasId
        where T : class, TI, new()
    {
        #region attributes
        #endregion

        #region .ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="DbManagerBase{TI,T}"/> class. 
        /// </summary>
        /// <param name="db">
        /// An <see cref="IDbConnection"/>.
        /// </param>
        protected DbManagerBase(IDbConnection db)
        {
            this.Db = db;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the database connection.
        /// </summary>
        protected IDbConnection Db { get; set; } // Injected in ctor by IOC

        #endregion

        #region ICrudManager implementation

        /// <summary>
        /// Insert the given item in the database.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The TI.
        /// </returns>
        public virtual TI Create(TI item)
        {
            if (item.Id == default(long))
            {
                item.Id = this.Db.GetNewId<T>();
            }

            this.Db.Insert(item as T);

            return this.Get(item.Id);

            /* // Transaction don't work in this case with Sqlite (can't use this.Get(Item.Id) while in a transaction).
            var trans = this.Db.OpenTransaction();
            try
            {
                this.Db.Insert(item as T);

                trans.Commit();

                return this.Get(item.Id);
            }
            catch (Exception ex)
            {
                trans.Rollback();

                throw;
            }
            finally
            {
                trans.Dispose();
            }
             */
        }

        /// <summary>
        /// Update the given item in the database.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public virtual void Update(TI item)
        {
            var trans = this.Db.OpenTransaction();
            try
            {
                this.Db.Save(item as T);

                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();

                throw;
            }
            finally
            {
                trans.Dispose();
            }
        }

        /// <summary>
        /// Remove the given item with the given id from the database.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public virtual void Remove(long id)
        {
            var trans = this.Db.OpenTransaction();
            try
            {
                this.Db.DeleteById<T>(id);

                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();

                throw;
            }
            finally
            {
                trans.Dispose();
            }
        }

        /// <summary>
        /// Remove the given item from the database.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public virtual void Remove(TI item)
        {
            this.Remove(item.Id);
        }
        #endregion

        #region IGetManager implementation

        /// <summary>
        /// Get all items from database
        /// </summary>
        /// <returns>
        /// An items list.
        /// </returns>
        public virtual IEnumerable<TI> Get()
        {
            var ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();
            ev.OrderBy("Id");

            return this.Db.Select(ev);
        }

        /// <summary>
        /// Get all items from database ordered by the given column.
        /// </summary>
        /// <param name="orderKey">
        /// The order key.
        /// </param>
        /// <typeparam name="TKey">
        /// An lambda expression containing the ordering column
        /// </typeparam>
        /// <returns>
        /// An items list.
        /// </returns>
        public virtual IEnumerable<TI> Get<TKey>(Expression<Func<TI, TKey>> orderKey)
        {
            var ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();

            // Convert the given expression visitor arg of type TI to one with the concrete type T and use it to order the result.
            ev.OrderBy(DelegateConversionVisitor.Convert<TI, T, TKey>(orderKey));

            return this.Db.Select(ev);
        }

        /// <summary>
        /// Get 10 items from database.
        /// </summary>
        /// <param name="page">
        /// The items page.
        /// </param>
        /// <returns>
        /// An items list.
        /// </returns>
        public virtual IEnumerable<TI> Get(int page)
        {
            var ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();
            ev.Limit(page * 10, 10)
                .OrderBy("Id");

            return this.Db.Select(ev);
        }

        /// <summary>
        /// Get 10 items from database ordered by the given column.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="orderKey">
        /// The order key.
        /// </param>
        /// <typeparam name="TKey">
        /// An lambda expression containing the ordering column
        /// </typeparam>
        /// <returns>
        /// An items list.
        /// </returns>
        public virtual IEnumerable<TI> Get<TKey>(int page, Expression<Func<TI, TKey>> orderKey)
        {
            var ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();

            // Convert the given expression visitor arg of type TI to one with the concrete type T and use it to order the result.
            ev.Limit(page * 10, 10)
                .OrderBy(DelegateConversionVisitor.Convert<TI, T, TKey>(orderKey));

            return this.Db.Select(ev);
        }

        /// <summary>
        /// Get n items from database.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="span">
        /// The number of items to get.
        /// </param>
        /// <returns>
        /// An items list.
        /// </returns>
        public virtual IEnumerable<TI> Get(int page, int span)
        {
            var ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();
            ev.Limit(page * span, span)
                .OrderBy("Id");

            return this.Db.Select(ev);
        }

        /// <summary>
        /// Get n items from database ordered by the given column.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="span">
        /// The number of items to get.
        /// </param>
        /// <param name="orderKey">
        /// The order key.
        /// </param>
        /// <typeparam name="TKey">
        /// An lambda expression containing the ordering column
        /// </typeparam>
        /// <returns>
        /// An items list.
        /// </returns>
        public virtual IEnumerable<TI> Get<TKey>(int page, int span, Expression<Func<TI, TKey>> orderKey)
        {
            var ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();

            // Convert the given expression visitor arg of type TI to one with the concrete type T and use it to order the result. 
            ev.Limit(page * span, span)
                .OrderBy(DelegateConversionVisitor.Convert<TI, T, TKey>(orderKey));

            return this.Db.Select(ev);
        }

        /// <summary>
        /// Get an item from the database with the given id
        /// </summary>
        /// <param name="id">
        /// The id to get.
        /// </param>
        /// <returns>
        /// An object with type TI.
        /// </returns>
        public virtual TI Get(long id)
        {
            return this.Db.GetByIdOrDefault<T>(id);
        }
        #endregion

        #region ISearchManager implementation

        /// <summary>
        /// Search an item in the database.
        /// </summary>
        /// <param name="predictate">
        /// The search pre-dictate.
        /// </param>
        /// <returns>
        /// A list of matches.
        /// </returns>
        public virtual IEnumerable<TI> Search(Expression<Func<TI, bool>> predictate)
        {
            var ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();

            // Convert the given expression visitor arg of type TI to one with the concrete type T and use it to order the result.
            ev.Where(DelegateConversionVisitor.Convert<TI, T, bool>(predictate));

            return this.Db.Select(ev);
        }
        #endregion
    }
}
