namespace Common.Data
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// The factory base.
    /// </summary>
    /// <typeparam name="TI">
    /// The returned type.
    /// </typeparam>
    /// <typeparam name="T">
    /// The type used for the instance creation.
    /// </typeparam>
    public abstract class FactoryBase<TI, T> : IFactory<TI>
        where T : class, TI
    {
        /// <summary>
        /// The factory function.
        /// </summary>
        private readonly Func<T> factoryCtor;

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryBase{TI,T}"/> class.
        /// </summary>
        protected FactoryBase()
        {
            this.factoryCtor = CreateUsingActivator();
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public TI Create()
        {
            return this.factoryCtor();
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="properties">
        /// The new instance base properties.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public TI Create(Action<TI> properties)
        {
            var instance = this.factoryCtor();

            properties(instance);

            return instance;
        }

        /// <summary>
        /// Return the constructor of <typeparamref name="T"/> in a <see cref="Func{TResult}"/> using activator.
        /// </summary>
        /// <returns>
        /// The <typeparamref name="T"/> constructor.
        /// </returns>
        private static Func<T> CreateUsingActivator()
        {
            var type = typeof(T);

            Func<T> f = () => Activator.CreateInstance(type, true) as T;

            return f;
        }

        /// <summary>
        /// /!\ Not Working /!\
        /// Return the constructor of <typeparamref name="T"/> in a <see cref="Func{TResult}"/> using lambdas.
        /// </summary>
        /// <returns>
        /// The <typeparamref name="T"/> constructor.
        /// </returns>
// ReSharper disable UnusedMember.Local
        private static Func<T> CreateUsingLambdas()
// ReSharper restore UnusedMember.Local
        {
            var type = typeof(T);

            var ctor = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.CreateInstance | BindingFlags.NonPublic, null, new Type[] { }, null);

            var ctorExpression = Expression.New(ctor);
            return Expression.Lambda<Func<T>>(ctorExpression).Compile();
        }
    }
}