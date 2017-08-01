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
    public class ReceivableRepo : GenericRepository<Receivable>
    {
        public List<Receivable> GetAllReceivableByDate(DateTime DateOut, DateTime DateBack)
        {
            var recList = this.GetQuery(m => m.CurrentDate >= DateOut && m.CurrentDate <= DateBack, null, "Employee")
                .Select(x => new Receivable
                {
                    ReceivableId  = x.ReceivableId,
                    EmployeeId = x.EmployeeId,
                    CurrentDate = x.CurrentDate,
                    EmployeeName = x.Employee.EmployeeName,
                    ReceivableAmount = Convert.ToDecimal(string.Format("{0:#,##0}", double.Parse(Convert.ToString(x.ReceivableAmount)))),
                }).OrderByDescending(x => x.ReceivableId).ToList();

            return recList;
        }

        public void UpdateReceivable(Receivable rec)
        {
            //var trnT = this.Find(trne.ReceivableId);
            //trnT.ReceivableName = trne.ReceivableName;
            //trnT.InitialPrice = trne.InitialPrice;
            //trnT.ReceivableTypeId = trne.ReceivableTypeId;
            //trnT.CurrentDate = DateTime.Now;
            //trnT.Description = trne.Description;
            //if (trne.ReceivableId == 0)
            //{
            //    this.Add(trne);
            //}
            //else
            //{
            this.Update(rec);
            //}
            this.CommitChanges();
        }

        public void SaveReceivable(Receivable rec)
        {
            if (rec.ReceivableId == 0)
            {
                //rec.CurrentDate = DateTime.Now;
                this.Add(rec);
            }
            else
            {
                this.Update(rec);
                //var recT = this.Find(rec.ReceivableId);
                //recT.DateOut = rec.DateOut;
                //recT.DateBack = rec.DateBack;
                //recT.TravelFrom = rec.TravelFrom;
                //recT.TravelTo = rec.TravelTo;
                //recT.CurrentDate = DateTime.Now;
                //recT.FareAmount = rec.FareAmount;
                //recT.InventoryId = rec.InventoryId;
                //recT.EmployeeId = rec.EmployeeId;
                //recT.Description = rec.Description;

                //foreach (var item in rec.ReceivableExpenseTypes)
                //{
                //    if (item.ReceivableExpenseTypeId == 0)
                //        recEntitiesContext.Entry(item).State = EntityState.Added;
                //    else
                //        recEntitiesContext.Entry(item).State = EntityState.Modified;
                //}

                this.Update(rec);
            }

            this.CommitChanges();
        }

        public bool DeleteReceivable(int id)
        {
            //this.Delete(new Receivable() { ReceivableId = id });
            //this.CommitChanges();
            //
            var trnT = this.Find(id);
            this.Delete(trnT);

            //foreach (var item in trnT.ReceivableExpenseTypes)
            //{
            //    recEntitiesContext.Entry(item).State = EntityState.Deleted;
            //}
            ////this.Delete(new Receivable() { ReceivableId = id });
            this.CommitChanges();
            return true;
        }


        public Receivable GetReceivableById(int ReceivableId)
        {
            return this.GetAll().Where(x => x.ReceivableId == ReceivableId).FirstOrDefault();
        }

        public decimal GetTotalReceivableByEmployeeId(int EmployeeId)
        {
            var totalReceived  = this.GetAll().Where(x => x.EmployeeId == EmployeeId).Select(x => x.ReceivableAmount).Sum();
            return totalReceived;
        }

        public List<Receivable> GetAllReceivableByEmployeeId(int EmployeeId)
        {
            //var totalReceived = this.GetAll().Where(x => x.EmployeeId == EmployeeId).Select(x => x.ReceivableAmount).Sum();
            //return totalReceived;

            var recList = this.GetQuery(x => x.EmployeeId == EmployeeId, null, "Employee")
               .Select(x => new Receivable
               {
                   ReceivableId = x.ReceivableId,
                   EmployeeId = x.EmployeeId,
                   EmployeeName = x.Employee.EmployeeName,
                   ReceivableAmount = Convert.ToDecimal(string.Format("{0:#,##0}", double.Parse(Convert.ToString(x.ReceivableAmount)))),
               }).OrderByDescending(x => x.ReceivableId).ToList();

            return recList;
        }

    }
}
