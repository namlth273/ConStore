namespace ConSales
{
    public class OrderService : IOrderService
    {
        private readonly IStoreService _storeService;

        public OrderService(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public void BuyClothe(BuyClotheParam param)
        {
            _storeService.AddClothe(new AddClotheParam
            {
                ClotheId = param.ClotheId,
                Quantity = param.Quantity
            });
        }

        public void SellClothe(SellClotheParam param)
        {
            _storeService.RemoveClothe(new RemoveClotheParam
            {
                ClotheId = param.ClotheId,
                Quantity = param.Quantity
            });
        }
    }
}