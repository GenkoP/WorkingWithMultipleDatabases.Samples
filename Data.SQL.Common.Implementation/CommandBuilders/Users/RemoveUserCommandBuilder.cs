using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Common.Contracts;
using Data.Models;
using Data.SQL.Common.Contracts;

namespace Data.SQL.Common.Implementation.CommandBuilders.Users
{
    public sealed class RemoveUserCommandBuilder : ICommandBuilder
    {
        private readonly IEntitiesForRemovingProvider<Guid, User> userIdsProvider;

        public RemoveUserCommandBuilder(IEntitiesForRemovingProvider<Guid, User> userIdsProvider)
        {
            this.userIdsProvider = userIdsProvider ?? throw new ArgumentNullException($"{nameof(userIdsProvider)} should not be null");
        }

        public string Build()
        {
            IList<Guid> userIds = this.userIdsProvider.GetAllEntitiesForRemoving().ToList();

            if (userIds.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append($"DELETE FROM {nameof(User)}s WHERE Id IN (");

            for (int i = 0; i < userIds.Count; i++)
            {
                Guid id = userIds[i];
                if (i != 0)
                {
                    sql.Append(", ");
                }

                sql.Append($"'{id}'");
            }

            sql.Append(")");

            return sql.ToString();
        }
    }
}
