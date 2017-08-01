using DataAccess.Core;
using DataAccess.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomRepositories
{
    public class TransportExpenseTypeRepo : GenericRepository<TransportExpenseType>
    {
        //public Decimal GetPreviousBalanceTransport(int invId)
        //{
        //    return this.GetQuery(m => m.Transport.InventoryId == invId, null, "Transport").Select(s => s.Amount).Sum();
        //}

        public Decimal GetTotalTransportExpense(int transportId)
        {
            return this.GetQuery(m => m.Transport.TransportId == transportId, null, "Transport").Select(s => s.Amount).Sum();
        }

        public Decimal GetTotalEmployeeExpense(int employeeId)
        {
            var data = this.GetQuery(m => m.Transport.EmployeeId == employeeId, null, "Transport")
                .Select(s => s.Amount).Sum();
            return data;
        }

        public Decimal GetTotalEmployeeExpenseExcludingCurrent(int employeeId, int transportId)
        {
            var data = this.GetQuery(m => m.Transport.EmployeeId == employeeId && m.TransportId!= transportId, null, "Transport")
                .Select(s => s.Amount).Sum();
            return data;
        }


        public List<TransportExpenseType> GetAllTransportExpenseType(int transId)
        {
            var list  = this.GetQuery(m => m.Transport.TransportId == transId, null, "ExpenseType").Select(x => new TransportExpenseType
            {
                TransportExpenseTypeId = x.TransportExpenseTypeId,
                ExpenseTypeId = x.ExpenseTypeId,
                Amount = Convert.ToDecimal(string.Format("{0:#,##0}", double.Parse(Convert.ToString(x.Amount)))),
                ExpenseTypeName = x.ExpenseType.ExpenseTypeName,
                TransportId = x.TransportId,
                Description = x.Description
            }).ToList();

            return list;
        }

        public void DeleteTransportExpenseType(int id)
        {
            //var invT = this.Find(id);
            //this.Delete(invT);
            this.Delete(new TransportExpenseType() { TransportExpenseTypeId = id });
            this.CommitChanges();
        }
    }
}
