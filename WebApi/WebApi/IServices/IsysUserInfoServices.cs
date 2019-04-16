using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace IServices
{
    public interface ISysUserInfoServices : IBaseServices<SysUserInfo>
    {
        Task<SysUserInfo> SaveUserInfo(string loginName, string loginPWD);
        Task<string> GetUserRoleNameStr(string loginName, string loginPWD);
    }
}
