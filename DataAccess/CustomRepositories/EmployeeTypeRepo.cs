using DataAccess.Core;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomRepositories
{
    public class EmployeeTypeRepo : GenericRepository<EmployeeType>
    {
        public List<EmployeeType> GetAllEmployeeTypes()
        {
            return this.GetAll().OrderByDescending(x => x.EmployeeTypeId).ToList();
        }

        public bool CheckExistingEmployeeType(string EmployeeTypeText)
        {
            var empTyp = this.GetQuery(u => u.EmployeeTypeName == EmployeeTypeText, null).ToList();
            if (empTyp.Count == 0)
                return true;
            else
            {
                return false;
            }
        }

        public void SaveEmployeeType(EmployeeType empType)
        {
            var empT = this.Find(empType.EmployeeTypeId);
            empT.EmployeeTypeName = empType.EmployeeTypeName;
            //if (empType.EmployeeTypeId == 0)
            //{
            //    this.Add(empType);
            //}
            //else
            //{
            this.Update(empT);
            //}
            this.CommitChanges();
        }

        public void SaveAllEmployeeTypes(List<EmployeeType> empTypes)
        {
            //if (empType.EmployeeTypeId == 0)
            //{
            this.AddMany(empTypes);
            //}
            //else
            //{
            //    this.Update(empType);
            //}
            this.CommitChanges();
        }

        public void DeleteEmployeeType(int id)
        {
            var empT = this.Find(id);
            this.Delete(empT);
            //this.Delete(new EmployeeType() { EmployeeTypeId = id });
            this.CommitChanges();
        }
    }
}
