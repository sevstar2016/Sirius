using BD.Models;
using GraphQL.Types;

namespace MovieReviews.GraphQL.Types
{
    public class CustomerObject : ObjectGraphType<Customer>
    {
        public CustomerObject()
        {
            Name = nameof(Customer);
            Description = "Customer";

            Field(c => c.id).Description("Customer ID");
            Field(c => c.mail).Description("Customer mail");
            Field(c => c.name).Description("Customer name");
        }
    }
}