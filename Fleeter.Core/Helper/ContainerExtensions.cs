using Autofac;
using Fleeter.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Helper
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder UseFleeter(this ContainerBuilder cb)
        {
            cb.RegisterType<ConnectionFactory>().SingleInstance().AutoActivate();

            return cb;
        }
    }
}
