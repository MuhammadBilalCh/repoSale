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
    public class TransportRepo : GenericRepository<Transport>
    {
        public List<Transport> GetAllTransportsByDate(DateTime DateOut, DateTime DateBack)
        {
            var trans1 = this.GetQuery(m => m.DateOut >= DateOut && m.DateBack <= DateBack, null, "Inventory,Employee")
                .Select(x => new Transport
                {
                    TransportId = x.TransportId,
                    DateOut = x.DateOut,
                    InventoryId = x.InventoryId,
                    InventoryName = x.Inventory.InventoryName,
                    InventoryNumber = x.Inventory.InventoryNumber,
                    TravelFrom = x.TravelFrom,
                    DateBack = x.DateBack,
                    TravelTo = x.TravelTo,
                    FareAmount = Convert.ToDecimal(string.Format("{0:#,##0}", double.Parse(Convert.ToString(x.FareAmount)))),
                    AdvanceAmount = Convert.ToDecimal(string.Format("{0:#,##0}", double.Parse(Convert.ToString(x.AdvanceAmount)))),
                    EmployeeId = x.Employee.EmployeeId,
                    EmployeeName = x.Employee.EmployeeName
                }).OrderByDescending(x => x.TransportId).ToList();

            return trans1;
        }

        public void UpdateTransport(Transport trne)
        {
            var trnT = this.Find(trne.TransportId);
            //trnT.TransportName = trne.TransportName;
            //trnT.InitialPrice = trne.InitialPrice;
            //trnT.TransportTypeId = trne.TransportTypeId;
            //trnT.CurrentDate = DateTime.Now;
            //trnT.Description = trne.Description;
            //if (trne.TransportId == 0)
            //{
            //    this.Add(trne);
            //}
            //else
            //{
            this.Update(trnT);
            //}
            this.CommitChanges();
        }

        public void SaveTransport(Transport trans)
        {
            if (trans.TransportId == 0)
            {
                trans.CurrentDate = DateTime.Now;
                this.Add(trans);
            }
            else
            {
                //var transT = this.Find(trans.TransportId);
                //transT.DateOut = trans.DateOut;
                //transT.DateBack = trans.DateBack;
                //transT.TravelFrom = trans.TravelFrom;
                //transT.TravelTo = trans.TravelTo;
                //transT.CurrentDate = DateTime.Now;
                //transT.FareAmount = trans.FareAmount;
                //transT.InventoryId = trans.InventoryId;
                //transT.EmployeeId = trans.EmployeeId;
                //transT.Description = trans.Description;

                foreach (var item in trans.TransportExpenseTypes)
                {
                    if (item.TransportExpenseTypeId == 0)
                        TransEntitiesContext.Entry(item).State = EntityState.Added;
                    else
                        TransEntitiesContext.Entry(item).State = EntityState.Modified;
                }

                this.Update(trans);
            }

            this.CommitChanges();
        }

        public bool DeleteTransport(int id)
        {

            var expenses = TransEntitiesContext.TransportExpenseTypes.Where(x => x.TransportId == id);
            TransEntitiesContext.TransportExpenseTypes.RemoveRange(expenses);
            this.Delete(new Transport() { TransportId = id });
            this.CommitChanges();
            return true;
            //var trnT = this.Find(id);
            //this.Delete(trnT);

            //foreach (var item in trnT.TransportExpenseTypes)
            //{
            //    TransEntitiesContext.Entry(item).State = EntityState.Deleted;
            //}
            ////this.Delete(new Transport() { TransportId = id });
            //this.CommitChanges();
        }


        public Transport GetTransportById(int TransportId)
        {
            return this.GetAll().Where(x => x.TransportId == TransportId).FirstOrDefault();
        }

        public decimal GetTotalAdvanceByEmployeeId(int EmployeeId)
        {
            var totlaSum = this.GetAll().Where(x => x.EmployeeId == EmployeeId).Select(x => x.AdvanceAmount).Sum();
            return totlaSum;
        }

        public decimal GetTotalFareByEmployeeId(int EmployeeId)
        {
            var totlaSum = this.GetAll().Where(x => x.EmployeeId == EmployeeId).Select(x => x.FareAmount).Sum();
            return totlaSum;
        }

        public decimal GetTotalExepnseByEmployeeId(int EmployeeId)
        {
            //var totlaSum = this.GetAll().Where(x => x.EmployeeId == EmployeeId).Select(x => x.AdvanceAmount).Sum();
            var TransIds = this.GetAll().Where(x => x.EmployeeId == EmployeeId).Select(x => x.TransportId).ToList();

            var _repo = new TransportExpenseTypeRepo();

            decimal totalExp = 0;
            foreach (var itemId in TransIds)
            {
                totalExp = totalExp + _repo.GetTotalTransportExpense(itemId);
            }

          //var oldBalance = totlaSum -

            return totalExp;
        }

    }
}
