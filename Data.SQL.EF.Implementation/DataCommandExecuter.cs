using System;
using Data.SQL.Common.Contracts;

namespace Data.SQL.EF.Implementation
{
    public sealed class DataCommandExecuter : IDataCommandExecuter
    {
        private readonly DataContext dataContext;

        public DataCommandExecuter(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException($"{nameof(dataContext)} should not be null");
        }

        public void Execute(string dataCommand)
        {
            this.dataContext.Database.ExecuteSqlCommand(dataCommand);
        }
    }
}
