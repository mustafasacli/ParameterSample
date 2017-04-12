using FreeLibrary.Interfaces;
using FreeLibrary.Parameter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeLibrary.DataAccess
{
    public abstract class BaseDataAccess<T> where T : IFreeDbEntity
    {
        internal virtual DbConnectionStringBuilder ConnectionStringBuilder
        {
            get { return null; }
        }

        internal virtual DbConnection Connection
        {
            get { return null; }
        }


        internal DataSet FillDataSet(string query, CommandType cmdType, FreeParameter[] parameters = null)
        {
            DataSet ds = new DataSet();

            return ds;
        }

    }
}
