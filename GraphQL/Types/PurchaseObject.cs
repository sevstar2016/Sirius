using BD.Models;
using GraphQL.Types;

namespace MovieReviews.GraphQL.Types
{
    public sealed class PurchaseObject : ObjectGraphType<Purchase>
    {
        public PurchaseObject()
        {
            Name = nameof(Purchase);
            Description = "Purchase";

            Field(m => m.id).Description("Identifier");
            Field(m => m.price).Description("Price");
            Field(m => m.income).Description("Income");
        }
    }
}