using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Common.Contracts;
using Data.Models;
using Data.SQL.Common.Contracts;

namespace Data.SQL.Common.Implementation.CommandBuilders.Promotions
{
    public sealed class RemovePromotionCommandBuilder : ICommandBuilder
    {
        private readonly IEntitiesForRemovingProvider<Guid, Promotion> promotionIdsProvider;

        public RemovePromotionCommandBuilder(IEntitiesForRemovingProvider<Guid, Promotion> promotionIdsProvider)
        {
            this.promotionIdsProvider = promotionIdsProvider ?? throw new ArgumentNullException($"{nameof(promotionIdsProvider)} should not be null");
        }

        public string Build()
        {
            IList<Guid> promotionIds = promotionIdsProvider.GetAllEntitiesForRemoving().ToList();

            if (promotionIds.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sql = new StringBuilder();
            sql.Append($"DELETE FROM {nameof(Promotion)}s WHERE Id IN (");

            for (int i = 0; i < promotionIds.Count; i++)
            {
                Guid id = promotionIds[i];
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
