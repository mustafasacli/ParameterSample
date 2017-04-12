using System.Data;

namespace FreeLibrary.Parameter
{
    [System.Diagnostics.DebuggerDisplay("{FullName} - {DbType}- {Direction}")]
    public class FreeParameter
    {
        public string FullName { get; set; }

        public DbType DbType { get; set; } = DbType.Object;

        public ParameterDirection Direction { get; set; } = ParameterDirection.Input;

        public object Value { get; set; }
    }
}
