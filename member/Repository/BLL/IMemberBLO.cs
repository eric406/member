using member.Models.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace member.NewFolder.NewFolder
{
    public interface IMemberBLO
    {
        Member GetByParam(string account, string password);
        Member RepeatAccount(string account);
        void Create(Member item);
    }
}
