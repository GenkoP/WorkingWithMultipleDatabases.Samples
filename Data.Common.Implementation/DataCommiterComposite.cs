using System;
using System.Collections.Generic;
using Data.Common.Contracts;

namespace Data.Common.Implementation
{
    public sealed class DataCommiterComposite : IDataCommiter
    {
        private readonly ICleanable cleaner;
        private readonly IEnumerable<IDataCommiter> dataCommiters;

        public DataCommiterComposite(ICleanable cleaner, IEnumerable<IDataCommiter> dataCommiters)
        {
            this.cleaner = cleaner ?? throw new ArgumentNullException($"{nameof(cleaner)} should not be null");
            this.dataCommiters = dataCommiters ?? throw new ArgumentNullException($"{nameof(dataCommiters)} should not be null");
        }

        public void Commit()
        {
            foreach (IDataCommiter dataCommiter in this.dataCommiters)
            {
                dataCommiter.Commit();
            }

            this.cleaner.Clean();
        }
    }
}
