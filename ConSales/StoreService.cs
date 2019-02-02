using System;
using System.Collections.Generic;
using System.Linq;

namespace ConSales
{
    public class StoreService : IStoreService
    {
        private Guid _dummyTShirtId = Guid.NewGuid();
        private Guid _dummyDressShirtId = Guid.NewGuid();

        public List<Store> Stores { get; set; }
        public List<Clothe> AllClothes { get; set; }
        public List<Pricing> AllPricings { get; set; }

        public StoreService()
        {
            CreateDummyClothes();
            CreateDummyClotheInStore();
        }

        public void AddClothe(AddClotheParam param)
        {
            var clotheToAdd = Stores.FirstOrDefault(w => w.Name == param.Name);
            if (clotheToAdd != null) clotheToAdd.Quantity += param.Quantity;
        }

        public void RemoveClothe(RemoveClotheParam param)
        {
            var clotheToAdd = Stores.FirstOrDefault(w => w.Name == param.Name
                                                         && w.Size == param.Size
                                                         && w.Color == param.Color);
            if (clotheToAdd != null && clotheToAdd.Quantity > 0) clotheToAdd.Quantity -= param.Quantity;
        }

        public List<Clothe> GetAllClothes()
        {
            return AllClothes;
        }

        public List<StoreModel> GetAllStores()
        {
            var storeModels = (from store in Stores
                join clothe in AllClothes on store.ClotheId equals clothe.Id
                select new StoreModel
                {
                    Id = store.Id,
                    ClotheId = clothe.Id,
                    Name = clothe.Name,
                    Quantity = store.Quantity,
                    RetailPrice = store.RetailPrice,
                    BuyInPrice = store.BuyInPrice,
                    Size = store.Size,
                    Color = store.Color
                }).ToList();

            return storeModels;
        }

        private void CreateDummyClotheInStore()
        {
            Stores = new List<Store>()
            {
                new Store
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    ClotheId = _dummyTShirtId,
                    BuyInPrice = 6,
                    RetailPrice = 12,
                    Color = "Red",
                    Size = "S",
                },
                new Store
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    ClotheId = _dummyTShirtId,
                    BuyInPrice = 6,
                    RetailPrice = 12,
                    Color = "Red",
                    Size = "M",
                },
                new Store
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    ClotheId = _dummyTShirtId,
                    BuyInPrice = 6,
                    RetailPrice = 12,
                    Color = "Blue",
                    Size = "S",
                },
                new Store
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    ClotheId = _dummyTShirtId,
                    BuyInPrice = 6,
                    RetailPrice = 12,
                    Color = "Blue",
                    Size = "M",
                },

                new Store
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    ClotheId = _dummyDressShirtId,
                    BuyInPrice = 8,
                    RetailPrice = 20,
                    Color = "Red",
                    Size = "S",
                },
                new Store
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    ClotheId = _dummyDressShirtId,
                    BuyInPrice = 8,
                    RetailPrice = 20,
                    Color = "Red",
                    Size = "M",
                },
                new Store
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    ClotheId = _dummyDressShirtId,
                    BuyInPrice = 8,
                    RetailPrice = 20,
                    Color = "Blue",
                    Size = "S",
                },
                new Store
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    ClotheId = _dummyDressShirtId,
                    BuyInPrice = 8,
                    RetailPrice = 20,
                    Color = "Blue",
                    Size = "M",
                },
            };
        }

        private void CreateDummyClothes()
        {
            AllClothes = new List<Clothe>
            {
                new Clothe
                {
                    Id = _dummyTShirtId,
                    Name = "T-Shirt"
                },
                new Clothe
                {
                    Id = _dummyDressShirtId,
                    Name = "Dress Shirt"
                },
            };
        }
    }
}