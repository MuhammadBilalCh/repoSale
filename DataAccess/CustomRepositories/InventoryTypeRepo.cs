using DataAccess.Core;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomRepositories
{
    public class InventoryTypeRepo : GenericRepository<InventoryType>
    {
        public List<InventoryType> GetAllInventoryTypes()
        {
            return this.GetAll().OrderByDescending(x => x.InventoryTypeId).ToList();
        }

        public bool CheckExistingInventoryType(string InventoryTypeText)
        {
            var invTyp = this.GetQuery(u => u.InventoryTypeName == InventoryTypeText, null).ToList();
            if (invTyp.Count == 0)
                return true;
            else
            {
                return false;
            }
        }

        public void SaveInventoryType(InventoryType invType)
        {
            var invT = this.Find(invType.InventoryTypeId);
            invT.InventoryTypeName = invType.InventoryTypeName;
            //if (invType.InventoryTypeId == 0)
            //{
            //    this.Add(invType);
            //}
            //else
            //{
            this.Update(invT);
            //}
            this.CommitChanges();
        }

        public void SaveAllInventoryTypes(List<InventoryType> invTypes)
        {
            //if (invType.InventoryTypeId == 0)
            //{
            this.AddMany(invTypes);
            //}
            //else
            //{
            //    this.Update(invType);
            //}
            this.CommitChanges();
        }

        public void DeleteInventoryType(int id)
        {
            var invT = this.Find(id);
            this.Delete(invT);
            //this.Delete(new InventoryType() { InventoryTypeId = id });
            this.CommitChanges();
        }
    }
}
