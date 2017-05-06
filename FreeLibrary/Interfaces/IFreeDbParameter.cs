using System.Data;

namespace FreeLibrary.Interfaces
{
    public interface IFreeDbParameter
    {
        string Name { get; set; }

        string ParameterPrefix { get; }

        DbType DbType { get; set; }

        ParameterDirection Direction { get; set; }

        bool IsGeneratedByDb { get; set; }
    }
}
