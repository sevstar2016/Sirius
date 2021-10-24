using BD.Models;
using GraphQL.Types;

namespace MovieReviews.GraphQL.Types
{
    public class SellerObject : ObjectGraphType<Seller>
    {
        public SellerObject()
        {
            Name = nameof(Seller);
            Description = "Seller";
            
            Field(s => s.id).Description("Id of seller");
            Field(s => s.linkPhoto).Description("Photo link");
            Field(s => s.shopName).Description("Shop name");
            Field(s => s.selledBouquets).Description("Selled bouquets");
            Field(s => s.dateOfCreation).Description("Date of creation");
        }
    }
}