using FreeLibrary.Interfaces;
using FreeLibrary.Parameter;

namespace FreeLibrary.Entity
{
    public abstract class FreeDbEntity : IFreeDbEntity
    {
        [FreeDbParameter(Name = "OLUSTURAN", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Input, IsGeneratedByDb = true)]
        public long Olusturan { get; set; }


        [FreeDbParameter(Name = "DEGISTIREN", DbType = System.Data.DbType.Int64, Direction = System.Data.ParameterDirection.Input, IsGeneratedByDb = true)]
        public long Degistiren { get; set; }

        [FreeDbParameter(Name = "OLUSTURMATARIH", DbType = System.Data.DbType.DateTime, Direction = System.Data.ParameterDirection.Input, IsGeneratedByDb = true)]
        public long OlusturmaTarihi { get; set; }


        [FreeDbParameter(Name = "DEGISTIRMETARIH", DbType = System.Data.DbType.DateTime, Direction = System.Data.ParameterDirection.Input, IsGeneratedByDb = true)]
        public long DegistirmeTarihi { get; set; }

    }
}
