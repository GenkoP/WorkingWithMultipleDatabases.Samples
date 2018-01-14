using System;
using Data.Common.Contracts;
using Data.SQL.Common.Contracts;

namespace Data.SQL.Common.Implementation
{
    public sealed class DataCommiter : IDataCommiter
    {
        private readonly ICommandBuilder commandBuilder;
        private readonly IDataCommandExecuter dataCommandExecuter;

        public DataCommiter(ICommandBuilder commandBuilder, IDataCommandExecuter dataCommandExecuter)
        {
            this.commandBuilder = commandBuilder ?? throw new ArgumentNullException($"{nameof(commandBuilder)} should not be null");
            this.dataCommandExecuter = dataCommandExecuter ?? throw new ArgumentNullException($"{nameof(dataCommandExecuter)} should not be null");
        }

        public void Commit()
        {
            string sqlCommand = this.commandBuilder.Build();
            if (!string.IsNullOrWhiteSpace(sqlCommand))
            {
                this.dataCommandExecuter.Execute(sqlCommand);
            }
        }
    }
}
