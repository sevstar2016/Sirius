using BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Threading.Tasks;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using MovieReviews.GraphQL.Types;

namespace MovieReviews.Database
{
    public class MarketRepo : IMarketRepo
    {
        private readonly MarketContext _context;

        public MarketRepo(MarketContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<Bouquet> GetBouquetById(int id)
        {
            return _context.bouquets.FirstOrDefault(b => b.id == id);
        }

        public async Task<Purchase> GetPurchaseById(int id)
        {
            return _context.purchases.FirstOrDefault(p => p.id == id);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return _context.customers.FirstOrDefault(s => s.id == id);
        }

        public async Task<Seller> GetSellerById(int id)
        {
            return _context.sellers.FirstOrDefault(s => s.id == id);
        }

        public async Task<Bouquet> DeleteBouquet(int id)
        {
            var b = _context.bouquets.Remove(_context.bouquets.FirstOrDefault(s=> s.id ==id)).Entity;
            await _context.SaveChangesAsync();
            return b;
        }

        public async Task<Seller> DeleteSeller(int id)
        {
            var s = _context.sellers.Remove(_context.sellers.FirstOrDefault(s=> s.id ==id)).Entity;
            await _context.SaveChangesAsync();
            return s;
        }

        public async Task<Purchase> DeletePurchase(int id)
        {
            var p = _context.purchases.Remove(_context.purchases.FirstOrDefault(s=> s.id ==id)).Entity;
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var c = _context.customers.Remove(_context.customers.FirstOrDefault(s=> s.id ==id)).Entity;
            await _context.SaveChangesAsync();
            return c;
        }


        public async Task<Purchase> PurchaseBouquet(int id, int cId)
        {
            var bouquet = _context.bouquets.Where(b => b.id == id).FirstOrDefaultAsync().Result;
            var cus = _context.customers.Where(c => c.id == cId).FirstOrDefaultAsync().Result;
            var purchase = _context.purchases.Add(new Purchase {bouquetID = id, price = bouquet.price, income = (bouquet.price * 0.3m), Bouquet = bouquet, customerID = cus.id, Customer = cus}).Entity;
            await _context.SaveChangesAsync();
            return purchase;
        }

        public async Task<Bouquet> CreateBouquet(string name, string linkPhoto, int sellerid, decimal price)
        {
            var seller = _context.sellers.Where(s => s.id == sellerid).FirstOrDefaultAsync().Result;
            Console.WriteLine(seller.id);
            var bouquet = _context.bouquets.Add(new Bouquet{linkPhoto = linkPhoto, price = price, name = name, sID = seller.id, seller = seller}).Entity;
            await _context.SaveChangesAsync();
            return bouquet;
        }

        public async Task<Customer> CreateCustomer(string name, string mail)
        {
            var customer = _context.customers.Add(new Customer {name = name, mail = mail}).Entity;
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Seller> CreateSeller(string shopName, string linkPhoto)
        {
            var seller = _context.sellers.Add(new Seller {shopName = shopName, linkPhoto = linkPhoto, dateOfCreation = DateTime.Today}).Entity;
            await _context.SaveChangesAsync();
            return seller;
        }
    }
}
