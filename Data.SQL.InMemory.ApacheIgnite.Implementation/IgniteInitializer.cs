using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Contracts;

namespace Data.SQL.InMemory.ApacheIgnite.Implementation
{
    public sealed class IgniteInitializer : IInitializer
    {
        private readonly IgniteAdapter igniteAdapter;

        public IgniteInitializer(IgniteAdapter igniteAdapter)
        {
            this.igniteAdapter = igniteAdapter ?? throw new ArgumentNullException($"{nameof(igniteAdapter)} should not be null");
        }

        public void Initialize()
        {
            this.igniteAdapter.IgnitionStart();
        }
    }
}
