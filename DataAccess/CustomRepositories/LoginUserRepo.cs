using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;
using DataAccess.Core;
using DataAccess.EntityFramework;
using DataAccess.Utill;

namespace DataAccess.CustomRepositories
{
    public class LoginUserRepo : GenericRepository<LoginUser>
    {
        public LoginUserRepo()
        {

        }
        public IList GetUserDetails(int id)
        {
            var user = this.GetQuery(x => x.UserId == id, null)
             .Select(x => new
             {
                 ID_USER = x.UserId,
                 LOGIN_NAME = x.UserName,
                 PASSWORD = x.UserPassword
             }).ToList();

            //var user = this.GetQuery(m => m.ID_USER == id, null, "CMS_USER_ROLE").ToList()[0];
            //var actPassword = Cryptography.Decrypt(user.PASSWORD);
            //user.PASSWORD = actPassword;
            return user;
        }
        public void SaveUsers(LoginUser user)
        {
            //var enPassword = Cryptography.Encrypt(user.UserPassword);
            //user.UserPassword = enPassword;

            //if (user.UserId == 0)
            //{
            //    this.Add(user);
            //}
            //else
            //{
            //    this.Add(user);
            //}

            this.CommitChanges();
        }

        public bool ValidateUser(string loginName, string password)
        {
            //string loginStatus = "";
            // var passWord = Cryptography.Encrypt(password);
            return this.GetQuery(u => u.UserName.ToUpper() == loginName.ToUpper() && u.UserPassword == password, null).Any();
            //if (user.Count == 0)
            //    loginStatus = "Invalid";
            //else
            //{
            //    loginStatus = "ValidUser";
            //}
            //return loginStatus;
            //return this.GetAll().Where(u => u.LOGIN_NAME.ToUpper() == loginName.ToUpper() && u.PASSWORD == Cryptography.Encrypt(password) && u.APPLICATIONID == applicationId).ToList().Any();
        }
    }
}
