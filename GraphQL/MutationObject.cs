using System;
using System.Net.Http.Headers;
using BD.Models;
using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using MovieReviews.Database;
using MovieReviews.GraphQL.Types;

namespace MovieReviews.GraphQL
{
    public class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(IMarketRepo repository)
        {
            Name = "Mutations";
            Description = "The base mutation for all the entities in our object graph.";

            FieldAsync<PurchaseObject, Purchase>(
                "PurchaseBouquet",
                "Add review to a movie.",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "Bouquet ID"
                    },
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "cid",
                        Description = "Customer ID"
                    }),
                context =>
                {
                    var bouquetId = context.GetArgument<int>("id");
                    var customerId = context.GetArgument<int>("cid");
                    return repository.PurchaseBouquet(bouquetId, customerId);
                });

            FieldAsync<BouquetObject, Bouquet>(
                "CreateBouquet", "Create Bouquet",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "name",
                        Description = "name"
                    },
                    new QueryArgument<NonNullGraphType<DecimalGraphType>>
                    {
                        Name = "price",
                        Description = "price"
                    },
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "linkPhoto",
                        Description = "link Photo"
                    },
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "sellerID",
                        Description = "Seller ID"
                    }
                ),
                context =>
                {
                    var name = context.GetArgument<string>("name");
                    var price = context.GetArgument<decimal>("price");
                    var linkPhoto = context.GetArgument<string>("linkPhoto");
                    var sellerID = context.GetArgument<int>("sellerID");
                    return repository.CreateBouquet(name, linkPhoto, sellerID, price);
                });

            FieldAsync<CustomerObject, Customer>(
                "CreateCustomer", "Create Customer",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "name",
                        Description = "Customer name"
                    },
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "mail",
                        Description = "Customer email"
                    }
                ),
                _conext =>
                {
                    var name = _conext.GetArgument<string>("name");
                    var mail = _conext.GetArgument <string>("mail");
                    return repository.CreateCustomer(name, mail);
                }
            );

            FieldAsync<SellerObject, Seller>(
                "CreateSeller", "Create Seller",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "shopName",
                        Description = "Shop name"
                    },
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "linkPhoto",
                        Description = "Photo link"
                    }
                ),
                context =>
                {
                    var shopName = context.GetArgument<string>("shopName");
                    var linkPhoto = context.GetArgument<string>("linkPhoto");
                    return repository.CreateSeller(shopName, linkPhoto);
                }
            );


            FieldAsync<BouquetObject, Bouquet>(
                "DeleteBouquet", "Delete Bouquet",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "ID"
                    }
                ),
                context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.DeleteBouquet(id);
                }
            );
            
            FieldAsync<SellerObject, Seller>(
                "DeleteSeller", "Delete seller",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "ID"
                    }
                ),
                context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.DeleteSeller(id);
                }
            );
            
            FieldAsync<CustomerObject, Customer>(
                "DeleteCustomer", "Delete customer",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "ID"
                    }
                ),
                context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.DeleteCustomer(id);
                }
            );
            
            FieldAsync<PurchaseObject, Purchase>(
                "DeletePurchase", "Delete Purchase",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "ID"
                    }
                ),
                context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.DeletePurchase(id);
                }
            );
        }
    }
}