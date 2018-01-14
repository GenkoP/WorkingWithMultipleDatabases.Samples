using System;
using System.Collections.Generic;
using System.Text;
using Data.SQL.Common.Contracts;

namespace Data.SQL.Common.Implementation.CommandBuilders
{
    public sealed class CommandBuilderComposite : ICommandBuilder
    {
        private readonly IEnumerable<ICommandBuilder> commandBuilders;

        public CommandBuilderComposite(IEnumerable<ICommandBuilder> commandBuilders)
        {
            this.commandBuilders = commandBuilders ?? throw new ArgumentNullException($"{commandBuilders} should not be null");
        }

        public string Build()
        {
            StringBuilder sql = new StringBuilder();

            foreach (ICommandBuilder commandBuilder in commandBuilders)
            {
                sql.AppendLine(commandBuilder.Build());
            }

            return sql.ToString();
        }
    }
}
