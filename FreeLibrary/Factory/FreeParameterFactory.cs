using FreeLibrary.Interfaces;
using FreeLibrary.Parameter;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FreeLibrary.Factory
{
    public class FreeParameterFactory : IFreeParameterFactory
    {
        private static Lazy<FreeParameterFactory> factory =
            new Lazy<FreeParameterFactory>(() => new FreeParameterFactory());
        private FreeParameterFactory() { }


        public static FreeParameterFactory Instance
        {
            get { return factory.Value; }
        }

        public List<IFreeParameter> GenerateFrom(IFreeDbEntity entity)//, bool isCreate = true)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            PropertyInfo[] propLst = entity.GetType().GetProperties();

            if (propLst == null || propLst.Length == 0)
                throw new Exception("No Property Found.");

            List<IFreeParameter> parameters = new List<IFreeParameter>();
            IFreeParameter prm;
            FreeDbParameterAttribute attr;

            foreach (var prp in propLst)
            {
                attr = null;
                attr = prp.GetCustomAttribute<FreeDbParameterAttribute>();

                if (attr == null)
                    continue;

                if (string.IsNullOrWhiteSpace(attr.Name))
                    throw new Exception("No ColumnName Found.");

                if (!prp.CanRead)
                    throw new Exception("Property must be readable.");

                prm = null;
                prm = new FreeParameter();
                //prm.FullName = string.Format("{0}{1}", attr.ParameterPrefix, attr.Name);
                prm.DbType = attr.DbType;
                prm.Direction = attr.Direction;
                prm.Name = attr.Name;
                prm.IsGeneratedByDb = attr.IsGeneratedByDb;
                prm.Prefix = attr.ParameterPrefix;
                /*
                if (attr.IsGeneratedByDb && isCreate)
                    prm.Direction = System.Data.ParameterDirection.Output;
                else if (attr.IsGeneratedByDb ^ isCreate)
                    prm.Direction = System.Data.ParameterDirection.Input;
                else
                    prm.Direction = attr.Direction;
                */
                //prm.Value = prp.GetValue(entity) ?? DBNull.Value;
                prm.Value = prp.GetValue(entity);

                parameters.Add(prm);
            }

            return parameters;
        }
    }
}
