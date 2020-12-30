using FH_Web.Models.DAO;
using member.Models.BLO;
using member.NewFolder.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace member.Models.NewFolder2
{
    public class MemberDAO : IMemberDAO
    {
        private MySqlContext DbContext;
        public MemberDAO(MySqlContext _context)
        {
            if (DbContext == null)
            {
                DbContext = _context;
            }
        }

        public IQueryable<Member> GetByParam(Expression<Func<Member, Boolean>> param)
        {
            try
            {
                IQueryable<Member> result = DbContext.Member.Where(param);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Create(Member item)
        {
            try
            {
                DbContext.Member.Add(item);
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
