using System;
using Data.Common.Contracts;

namespace Data.Common.Implementation
{
    public sealed class DataCommiterCleanerDecorator : IDataCommiter
    {
        private readonly ICleanable cleaner;
        private readonly IDataCommiter dataCommiter;

        public DataCommiterCleanerDecorator(ICleanable cleaner, IDataCommiter dataCommiter)
        {
            this.cleaner = cleaner ?? throw new ArgumentNullException($"{nameof(cleaner)} should not be null");
            this.dataCommiter = dataCommiter ?? throw new ArgumentNullException($"{nameof(dataCommiter)} should not be null");
        }

        public void Commit()
        {
            this.dataCommiter.Commit();
            this.cleaner.Clean();
        }
    }
}
