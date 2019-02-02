using System;
using System.Collections.Generic;

namespace ConSales
{
    public interface IBaseModel
    {
        Guid Id { get; set; }
    }

    public class Clothe : IBaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Pricing : IBaseModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }

    }

    public class Store : IBaseModel
    {
        public Guid Id { get; set; }
        public Guid ClotheId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal BuyInPrice { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }

    public class OrderType : IBaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class OrderItem : IBaseModel
    {
        public Guid Id { get; set; }
        public OrderType OrderTypeId { get; set; }
        public Guid ClotheId { get; set; }
        public int Quantity { get; set; }
    }

    public class BuyClotheParam
    {
        public Guid ClotheId { get; set; }
        public int Quantity { get; set; }
    }

    public class SellClotheParam : BuyClotheParam
    {

    }

    public interface IOrderService
    {
        void BuyClothe(BuyClotheParam param);
        void SellClothe(SellClotheParam param);
    }

    public interface IStoreService
    {
        void AddClothe(AddClotheParam param);
        void RemoveClothe(RemoveClotheParam param);
        List<Clothe> GetAllClothes();
        List<StoreModel> GetAllStores();
    }

    public class AddClotheParam
    {
        public Guid ClotheId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }

    public class RemoveClotheParam : AddClotheParam
    {

    }

    public class StoreModel
    {
        public Guid Id { get; set; }
        public Guid ClotheId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal BuyInPrice { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
