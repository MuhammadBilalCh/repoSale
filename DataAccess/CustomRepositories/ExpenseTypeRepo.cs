using DataAccess.Core;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomRepositories
{
    public class ExpenseTypeRepo : GenericRepository<ExpenseType>
    {
        public List<ExpenseType> GetAllExpenseTypes()
        {
            return this.GetAll().OrderByDescending(x => x.ExpenseTypeId).ToList();
        }

        public bool CheckExistingExpenseType(string ExpenseTypeText)
        {
            var expTyp = this.GetQuery(u => u.ExpenseTypeName == ExpenseTypeText, null).ToList();
            if (expTyp.Count == 0)
                return true;
            else
            {
                return false;
            }
        }

        public void SaveExpenseType(ExpenseType expType)
        {
            var expT = this.Find(expType.ExpenseTypeId);
            expT.ExpenseTypeName = expType.ExpenseTypeName;
            //if (expType.ExpenseTypeId == 0)
            //{
            //    this.Add(expType);
            //}
            //else
            //{
            this.Update(expT);
            //}
            this.CommitChanges();
        }

        public void SaveAllExpenseTypes(List<ExpenseType> expTypes)
        {
            //if (expType.ExpenseTypeId == 0)
            //{
            this.AddMany(expTypes);
            //}
            //else
            //{
            //    this.Update(expType);
            //}
            this.CommitChanges();
        }

        public void DeleteExpenseType(int id)
        {
            var expT = this.Find(id);
            this.Delete(expT);
            //this.Delete(new ExpenseType() { ExpenseTypeId = id });
            this.CommitChanges();
        }

        
    }
}
