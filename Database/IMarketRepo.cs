using BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using MovieReviews.GraphQL.Types;

namespace MovieReviews.Database
{
    public interface IMarketRepo
    {
        public Task<Purchase> PurchaseBouquet(int id, int cId);
        public Task<Bouquet> CreateBouquet(string name, string linkPhoto, int sellerID, decimal price);
        public Task<Customer> CreateCustomer(string name, string mail);
        public Task<Seller> CreateSeller(string shopName, string linkPhoto);
        
        public Task<Bouquet> GetBouquetById(int id);
        public Task<Purchase> GetPurchaseById(int id);
        public Task<Customer> GetCustomerById(int id);
        public Task<Seller> GetSellerById(int id);

        public Task<Bouquet> DeleteBouquet(int id);
        public Task<Seller> DeleteSeller(int id);
        public Task<Purchase> DeletePurchase(int id);
        public Task<Customer> DeleteCustomer(int id);
    }
}
