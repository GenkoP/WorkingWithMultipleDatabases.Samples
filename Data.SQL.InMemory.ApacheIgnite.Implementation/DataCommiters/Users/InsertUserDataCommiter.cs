using System;
using System.Collections.Generic;
using System.Linq;
using Apache.Ignite.Core.Cache;
using Data.Common.Contracts;
using Data.Models;

namespace Data.SQL.InMemory.ApacheIgnite.Implementation.DataCommiters.Users
{
    public sealed class InsertUserDataCommiter : IDataCommiter
    {
        private readonly IgniteAdapter igniteAdapter;
        private readonly IEntitiesForInsertingProvider<User> usersProvider;

        public InsertUserDataCommiter(IgniteAdapter igniteAdapter, IEntitiesForInsertingProvider<User> usersProvider)
        {
            this.igniteAdapter = igniteAdapter ?? throw new ArgumentNullException($"{nameof(igniteAdapter)} should not be null");
            this.usersProvider = usersProvider ?? throw new ArgumentNullException($"{nameof(usersProvider)} should not be null");
        }

        public void Commit()
        {
            IDictionary<Guid, User> users = this.usersProvider.GetAllEntitiesForInserting().ToDictionary(x => x.Id);

            if (users.Count > 0)
            {
                ICache<Guid, User> userCache = this.igniteAdapter.GetOrCreateCache<Guid, User>(nameof(User));
                userCache.PutAll(users);
            }
        }
    }
}
