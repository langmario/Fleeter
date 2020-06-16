using NHibernate;

namespace Fleeter.Core.Database
{
    public interface IConnectionFactory
    {
        ISession OpenSession();
    }
}