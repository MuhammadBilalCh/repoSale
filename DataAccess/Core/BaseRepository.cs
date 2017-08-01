using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DataAccess.EntityFramework;
using DataAccess.Common;

namespace DataAccess.Core
{
    public class BaseRepository : IDisposable
    {

        /// <summary>
        /// The context object for the database
        /// </summary>
        protected IUnitOfWork _unitOfWork;

        protected SaleEntities SaleEntitiesContext
        {
            get { return (SaleEntities)((UnitOfWork)_unitOfWork).Context; }
        }

        public BaseRepository()
        {
            _unitOfWork = new UnitOfWork();
        }
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// This function provides the dropdown text & values against lookupName.
        /// </summary>
        /// <param name="lookupName"></param>
        /// <returns></returns>
        public List<LookupDO> GetLookUpList(string lookupName)
        {

            List<LookupDO> list = new List<LookupDO>();
            var ctx = this.SaleEntitiesContext;
            switch (lookupName)
            {
                case "InventoryType":
                    list = ctx.InventoryTypes
                                 .Select(se => new LookupDO
                                 {
                                     Value = se.InventoryTypeId,
                                     Text = se.InventoryTypeName
                                 }).ToList();
                    break;
            }
            return list;
        }

        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (((UnitOfWork)_unitOfWork).Context != null)
                {
                    ((UnitOfWork)_unitOfWork).Context.Dispose();
                    ((UnitOfWork)_unitOfWork).Context = null;
                }
            }
        }
    }
}
