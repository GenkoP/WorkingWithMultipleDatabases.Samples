using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Common.Contracts;
using Data.Models;
using Data.SQL.Common.Contracts;

namespace Data.SQL.Common.Implementation.CommandBuilders.Promotions
{
    public sealed class InsertPromotionCommandBuilder : ICommandBuilder
    {
        private readonly IEntitiesForInsertingProvider<Promotion> promotionsProvider;

        public InsertPromotionCommandBuilder(IEntitiesForInsertingProvider<Promotion> promotionsProvider)
        {
            this.promotionsProvider = promotionsProvider ?? throw new ArgumentNullException($"{nameof(promotionsProvider)} should not be null");
        }

        public string Build()
        {
            IList<Promotion> promotions = promotionsProvider.GetAllEntitiesForInserting().ToList();

            if (promotions.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"INSERT INTO {nameof(Promotion)}s ({nameof(Promotion.Id)}, {nameof(Promotion.Name)}, {nameof(Promotion.CategoryName)})");
            sql.AppendLine("VALUES");

            Promotion promotion = null;
            for (int i = 0; i < promotions.Count; i++)
            {
                promotion = promotions[i];

                if (i != 0)
                {
                    sql.Append(",");
                }

                sql.AppendLine($"('{promotion.Id}', '{promotion.Name}', '{promotion.CategoryName}')");
            }

            return sql.ToString();
        }
    }
}
