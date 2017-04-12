using FreeLibrary.Interfaces;
using FreeLibrary.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FreeLibrary.Factory
{
    public class FreeParameterFactory
    {
        private static Lazy<FreeParameterFactory> factory =
            new Lazy<FreeParameterFactory>(() => new FreeParameterFactory());
        private FreeParameterFactory() { }


        public static FreeParameterFactory Instance
        {
            get { return factory.Value; }
        }

        public List<FreeParameter> GenerateFrom(IFreeDbEntity entity, bool isCreate = true)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            PropertyInfo[] propLst = entity.GetType().GetProperties();

            if (propLst == null || propLst.Length == 0)
                throw new Exception("No Property Found.");

            List<FreeParameter> parameters = new List<FreeParameter>();
            FreeParameter prm;
            FreeDbParameterAttribute attr;

            foreach (var prp in propLst)
            {
                if (!prp.CanRead)
                    throw new Exception("Property must be readable.");

                attr = null;
                attr = prp.GetCustomAttribute<FreeDbParameterAttribute>();

                if (attr == null)
                    continue;

                if (string.IsNullOrWhiteSpace(attr.Name))
                    throw new Exception("No ColumnName Found.");

                prm = null;
                prm = new FreeParameter();
                prm.FullName = string.Format("{0}{1}", attr.ParameterPrefix, attr.Name);
                prm.DbType = attr.DbType;
                //prm.Direction = attr.Direction;

                if (attr.IsGeneratedByDb && isCreate)
                    prm.Direction = System.Data.ParameterDirection.Output;
                else if (attr.IsGeneratedByDb ^ isCreate)
                    prm.Direction = System.Data.ParameterDirection.Input;
                else
                    prm.Direction = attr.Direction;

                prm.Value = prp.GetValue(entity) ?? DBNull.Value;

                parameters.Add(prm);
            }

            return parameters;
        }
    }
}
