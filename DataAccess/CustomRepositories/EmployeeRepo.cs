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
    public class EmployeeRepo : GenericRepository<Employee>
    {
        public List<Employee> GetAllEmployees()
        {
            //return this.GetQuery(null, null, "EmployeeType").ToList();
            var emp = this.GetQuery(null, null, "EmployeeType")
             .Select(x => new Employee
             {
                 EmployeeId = x.EmployeeId,
                 EmployeeName = x.EmployeeName,
                 FatherName = x.FatherName,
                 CNICNo = x.CNICNo,
                 EmployeeTypeId = x.EmployeeTypeId,
                 EmployeeTypeName = x.EmployeeType.EmployeeTypeName,
                 PhoneNo = x.PhoneNo,
                 Address = x.Address,
                 Pay = x.Pay == null ? (decimal?)null : Convert.ToDecimal(string.Format("{0:#,##0}", double.Parse(Convert.ToString(x.Pay)))),
             }).OrderByDescending(x=>x.EmployeeId).ToList();

            return emp;
            //return this.GetAll().ToList();
        }

        public bool CheckExistingEmployeeCNIC(string CNICNo)
        {
            var emp = this.GetQuery(u => u.CNICNo == CNICNo, null).ToList();
            if (emp.Count == 0)
                return true;
            else
            {
                return false;
            }
        }

        public void SaveEmployee(Employee empe)
        {
            var empT = this.Find(empe.EmployeeId);
            empT.EmployeeName = empe.EmployeeName;
            empT.FatherName = empe.FatherName;
            empT.EmployeeTypeId = empe.EmployeeTypeId;
            empT.CNICNo = empe.CNICNo;
            empT.CurrentDate = DateTime.Now;
            empT.PhoneNo = empe.PhoneNo;
            empT.Pay = empe.Pay;
            empT.Address = empe.Address;
            //if (empe.EmployeeId == 0)
            //{
            //    this.Add(empe);
            //}
            //else
            //{
            this.Update(empT);
            //}
            this.CommitChanges();
        }

        public void SaveAllEmployees(List<Employee> emps)
        {
            //if (empe.EmployeeId == 0)
            //{
            this.AddMany(emps);
            //}
            //else
            //{
            //    this.Update(empe);
            //}
            this.CommitChanges();
        }

        public void DeleteEmployee(int id)
        {
            var empT = this.Find(id);
            this.Delete(empT);
            //this.Delete(new Employee() { EmployeeId = id });
            this.CommitChanges();
        }

    }
}
