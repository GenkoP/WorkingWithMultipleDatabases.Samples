using System;
using System.Collections.Generic;
using Data.Common.Contracts;

namespace Data.Common.Implementation
{
    public sealed class DataCommiterComposite : IDataCommiter
    {
        private readonly IEnumerable<IDataCommiter> dataCommiters;

        public DataCommiterComposite(IEnumerable<IDataCommiter> dataCommiters)
        {
            this.dataCommiters = dataCommiters ?? throw new ArgumentNullException($"{nameof(dataCommiters)} should not be null");
        }

        public void Commit()
        {
            foreach (IDataCommiter dataCommiter in this.dataCommiters)
            {
                dataCommiter.Commit();
            }
        }
    }
}
