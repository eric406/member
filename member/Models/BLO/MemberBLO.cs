using member.Models.BLO;
using member.NewFolder.NewFolder;
using member.NewFolder.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace member.Models.BLO
{
    public class MemberBLO : IMemberBLO
    {
        private IMemberDAO MemberDAO;
        public MemberBLO(IMemberDAO _MemberDAO)
        {
            MemberDAO = _MemberDAO;
        }

        public void Create(Member item)
        {
            MemberDAO.Create(item);
        }

        public Member GetByParam(string account, string password)
        {
            try
            {
                if (account != null && password != null)
                {
                    Member Result = MemberDAO.GetByParam(x => x.Account == account && x.Password == password).FirstOrDefault();
                    return Result;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public Member RepeatAccount(string account)
        {
            try
            {
                if (account != null )
                {
                    Member Result = MemberDAO.GetByParam(x => x.Account == account ).FirstOrDefault();
                    return Result;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
