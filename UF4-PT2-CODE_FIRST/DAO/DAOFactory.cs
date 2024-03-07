using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UF4_PT2_CODE_FIRST.DAO
{
    public class DAOFactory
    {
        public static IDAOManager CreateDAOManager(MyDbContext context)
        {
            return new DAOManager(context);
        }
    }

}
