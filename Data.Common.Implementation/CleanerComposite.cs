using System;
using System.Collections.Generic;
using Data.Common.Contracts;

namespace Data.Common.Implementation
{
    public sealed class CleanerComposite : ICleanable
    {
        private readonly IEnumerable<ICleanable> cleaners;

        public CleanerComposite(IEnumerable<ICleanable> cleaners)
        {
            this.cleaners = cleaners ?? throw new NullReferenceException("Cleaners collection should not be null");
        }

        public void Clean()
        {
            foreach (ICleanable cleaner in cleaners)
            {
                cleaner.Clean();
            }
        }
    }
}
