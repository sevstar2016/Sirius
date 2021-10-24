using System;
using System.Collections.Generic;
using System.Linq;
using BD.Models;
using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using MovieReviews.Database;
using MovieReviews.GraphQL.Types;

namespace MovieReviews.GraphQL
{
    public class QueryObject : ObjectGraphType<object>
    {
        public QueryObject(IMarketRepo repository)
        {
            FieldAsync<BouquetObject, Bouquet>(
                "bouquet",
                "Get bouquet by id",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = ""
                    }),
                context => repository.GetBouquetById(context.GetArgument<int>("id"))
            );

            FieldAsync<SellerObject, Seller>(
                "seller",
                "Get seller by id",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = ""
                    }),
                context => repository.GetSellerById(context.GetArgument<int>("id"))
            );

            FieldAsync<CustomerObject, Customer>(
                "customer",
                "Get customer by id",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = ""
                    }),
                context => repository.GetCustomerById(context.GetArgument<int>("id"))
            );

            FieldAsync<PurchaseObject, Purchase>(
                "purchase",
                "Get purchase by id",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = ""
                    }),
                context => repository.GetPurchaseById(context.GetArgument<int>("id"))
            );
        }
    }
}