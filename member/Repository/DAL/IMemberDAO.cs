using FH_Web.Models.DAO;
using member.Models.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace member.NewFolder.NewFolder1
{
    public interface IMemberDAO
    {
        IQueryable<Member> GetByParam(Expression<Func<Member, bool>> param);
        void Create(Member inobj);
    }
}
