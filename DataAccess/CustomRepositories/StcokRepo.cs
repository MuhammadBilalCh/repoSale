using DataAccess.Core;
using DataAccess.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomRepositories
{
    public class StockRepo : GenericRepository<Stock>
    {
        public IList GetAllStocks()
        {
            //return this.GetQuery(null, null, "StockType").ToList();
            var stk = this.GetQuery(null, null, "Inventory,Inventory.InventoryType")
             .Select(x => new
             {
                 StockId = x.StockId,
                 Description = x.Description,
                 InventoryId = x.InventoryId,
                 InventoryName = x.Inventory.InventoryName,
                 InventoryTypeName = x.Inventory.InventoryType.InventoryTypeName,
                 CurrentDate = x.CurrentDate,
                 NumberCount = x.NumberCount,
                 Price = x.Price,
                 IsPurchase = x.IsPurchase,
                 ProcessDate = x.ProcessDate
             }).ToList();

            return stk;
            //return this.GetAll().ToList();
        }

        public Stock GetAllStocksById(int stockId)
        {
            //return this.GetQuery(null, null, "StockType").ToList();
            var stk = this.GetQuery(null, null, "Inventory.InventoryType").Where(x => x.StockId == stockId)
             .Select(x => new Stock
             {
                 StockId = x.StockId,
                 Description = x.Description,
                 InventoryId = x.InventoryId,
                 CurrentDate = x.CurrentDate,
                 NumberCount = x.NumberCount,
                 Price = x.Price,
                 InventoryTypeId = x.Inventory.InventoryType.InventoryTypeId,
                 IsPurchase = x.IsPurchase,
                 ProcessDate = x.ProcessDate
             }).FirstOrDefault();

            return stk;
            //return this.GetAll().ToList();
        }

        public List<Stock> GetAllStocksByDate(DateTime startDate, DateTime endDate, bool isPurchase)
        {
            //return this.GetQuery(null, null, "Inventory").ToList();
            var stk = this.GetQuery(null, null, "Inventory,Inventory.InventoryType").Where(x => x.ProcessDate >= startDate && x.ProcessDate <= endDate && x.IsPurchase == isPurchase)
             .Select(x => new Stock
              {
                  StockId = x.StockId,
                  Description = x.Description,
                  InventoryId = x.InventoryId,
                  InventoryName = x.Inventory.InventoryName,
                  InventoryTypeName = x.Inventory.InventoryType.InventoryTypeName,
                  InventoryNumber = x.Inventory.InventoryNumber,
                  InventoryTypeId = x.Inventory.InventoryType.InventoryTypeId,
                  CurrentDate = x.CurrentDate,
                  NumberCount = x.NumberCount,
                  Price = Convert.ToDecimal(string.Format("{0:#,##0}", double.Parse(Convert.ToString(x.Price)))),
                  IsPurchase = x.IsPurchase,
                  ProcessDate = x.ProcessDate
              }).OrderByDescending(x => x.StockId).ToList();

            return stk;
            //return this.GetAll().ToList();
        }

        public void SaveStock(Stock stke)
        {
            var stkT = this.Find(stke.StockId);
            stkT.Description = stke.Description;
            stkT.InventoryId = stke.InventoryId;
            stkT.NumberCount = stke.NumberCount;
            stkT.CurrentDate = DateTime.Now;
            stkT.Description = stke.Description;
            stkT.Price = stke.Price;
            stkT.IsPurchase = stke.IsPurchase;
            stkT.ProcessDate = stke.ProcessDate;
            //if (stke.StockId == 0)
            //{
            //    this.Add(stke);
            //}
            //else
            //{
            this.Update(stkT);
            //}
            this.CommitChanges();
        }

        public void SaveAllStocks(List<Stock> stks)
        {
            //if (stke.StockId == 0)
            //{
            this.AddMany(stks);
            //}
            //else
            //{
            //    this.Update(stke);
            //}
            this.CommitChanges();
        }

        public void DeleteStock(int id)
        {
            var stkT = this.Find(id);
            this.Delete(stkT);
            //this.Delete(new Stock() { StockId = id });
            this.CommitChanges();
        }

        public Stock GetStockByInventoryId(int inventoryId)
        {
            return this.GetAll().Where(x => x.InventoryId == inventoryId).FirstOrDefault();
        }

        public int GetNumberInStock(int inventoryId)
        {
            var purTotal = this.GetAll().Where(x => x.InventoryId == inventoryId && x.IsPurchase == true).Count();
            var salTotal = this.GetAll().Where(x => x.InventoryId == inventoryId && x.IsPurchase == false).Count();
            var inStock = purTotal - salTotal;
            return inStock;
        }
    }
}
