using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Common.Contracts;
using Data.Models;
using Data.SQL.Common.Contracts;

namespace Data.SQL.Common.Implementation.CommandBuilders.Users
{
    public sealed class InsertUserCommandBuilder : ICommandBuilder
    {
        private readonly IEntitiesForInsertingProvider<User> usersProvider;

        public InsertUserCommandBuilder(IEntitiesForInsertingProvider<User> usersProvider)
        {
            this.usersProvider = usersProvider ?? throw new ArgumentNullException($"{nameof(usersProvider)} should not be null");
        }

        public string Build()
        {
            IList<User> users = this.usersProvider.GetAllEntitiesForInserting().ToList();

            if (users.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"INSERT INTO [{nameof(User)}s] ({nameof(User.Id)}, {nameof(User.Username)}, [{nameof(User.Password)}], {nameof(User.Email)})");
            sql.AppendLine("VALUES");

            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];
                if (i != 0)
                {
                    sql.Append(", ");
                }

                sql.AppendLine($"('{user.Id}', '{user.Username}', '{user.Password}', '{user.Email}')");
            }

            return sql.ToString();
        }
    }
}
