using BD.Models;
using GraphQL.Types;

namespace MovieReviews.GraphQL.Types
{
    public sealed class BouquetObject : ObjectGraphType<Bouquet>
    {
        public BouquetObject()
        {
            Name = nameof(Bouquet);
            Description = "";

            Field(b => b.id).Description("Id of bouquet");
            Field(b => b.name).Description("name");
            Field(b => b.price).Description("price");
            Field(b => b.linkPhoto).Description("linkPhoto");
        }
    }
}