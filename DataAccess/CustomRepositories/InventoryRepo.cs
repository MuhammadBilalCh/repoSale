using DataAccess.Common;
using DataAccess.Core;
using DataAccess.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomRepositories
{
    public class InventoryRepo : GenericRepository<Inventory>
    {
        public List<Inventory> GetAllInventorys()
        {
            //return this.GetQuery(null, null, "InventoryType").ToList();
            var emp = this.GetQuery(null, null, "InventoryType")
             .Select(x => new Inventory
             {
                 InventoryId = x.InventoryId,
                 InventoryName = x.InventoryName,
                 InventoryNumber = x.InventoryNumber,
                 InitialPrice = Convert.ToDecimal(string.Format("{0:#,##0}", double.Parse(Convert.ToString(x.InitialPrice)))),
                 InventoryTypeId = x.InventoryTypeId,
                 CurrentDate = x.CurrentDate,
                 Description = x.Description,
                 InventoryTypeName = x.InventoryType.InventoryTypeName
             }).OrderByDescending(x => x.InventoryId).ToList();

            return emp;
            //return this.GetAll().ToList();
        }

        public bool CheckExistingInventory(string inventoryNumber,string invName, int invTypeId)
        {
            var emp = this.GetQuery(u => u.InventoryNumber == inventoryNumber && u.InventoryName == invName && u.InventoryTypeId == invTypeId, null).ToList();
            if (emp.Count == 0)
                return true;
            else
            {
                return false;
            }
        }

        public void SaveInventory(Inventory empe)
        {
            var empT = this.Find(empe.InventoryId);
            empT.InventoryName = empe.InventoryName;
            empT.InventoryNumber = empe.InventoryNumber;
            empT.InitialPrice = empe.InitialPrice;
            empT.InventoryTypeId = empe.InventoryTypeId;
            empT.CurrentDate = DateTime.Now;
            empT.Description = empe.Description;
            //if (empe.InventoryId == 0)
            //{
            //    this.Add(empe);
            //}
            //else
            //{
            SaleEntitiesContext.Entry(empT).State = EntityState.Detached;
            //SaleEntitiesContext.Entry(empT).State = EntityState.Modified;
            this.Update(empe);
            //}
            this.CommitChanges();
        }

        public void SaveAllInventorys(List<Inventory> invs)
        {
            //if (empe.InventoryId == 0)
            //{
            this.AddMany(invs);

            //var rpoStock = new StockRepo();
            //List<Stock> lstStock = new List<Stock>();

            //for (int i = 0; i < invs.Count; i++)
            //{
            //    if (invs[i].IsAddedToStock == true)
            //    {


            //        invs[i].Stocks.Add(stkItem);

            //        //SaleEntitiesContext.Entry(stkItem).State = EntityState.Added;
            //        //rpoStock.Add(stkItem);                    
            //    }

            //foreach (var item in invs[i].Stocks)
            //{
            //    if (item.StockId == 0)
            //        SaleEntitiesContext.Entry(item).State = EntityState.Added;
            //    else
            //        SaleEntitiesContext.Entry(item).State = EntityState.Modified;
            //}

            //{

            //}
            //}
            //}
            //else
            //{
            //    this.Update(empe);
            //}
            this.CommitChanges();
        }

        public void DeleteInventory(int id)
        {
            var empT = this.Find(id);
            SaleEntitiesContext.Entry(empT).State = EntityState.Detached;
            this.Delete(empT);
            //this.Delete(new Inventory() { InventoryId = id });
            this.CommitChanges();
        }

        public List<LookupDO> GetInventoryByType(int inventoryTypeId)
        {
            return this.GetAll().Where(x => x.InventoryTypeId == inventoryTypeId)
                                .Select(se => new LookupDO
                                {
                                    Value = se.InventoryId,
                                    Text = se.InventoryName
                                }).ToList();
        }

        public List<LookupDO> GetInventoryByTypeNumber(int inventoryTypeId)
        {
            return this.GetAll().Where(x => x.InventoryTypeId == inventoryTypeId)
                                .Select(se => new LookupDO
                                {
                                    Value = se.InventoryId,
                                    Text = se.InventoryName + " " + se.InventoryNumber
                                }).ToList();
        }


        public Inventory GetInventoryById(int inventoryId)
        {
            return this.GetAll().Where(x => x.InventoryId == inventoryId).FirstOrDefault();
        }
    }
}
