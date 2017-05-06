using FreeLibrary.Interfaces;
using System.Data;
using System;

namespace FreeLibrary.Parameter
{
    [System.Diagnostics.DebuggerDisplay("{FullName} - {DbType}- {Direction}")]
    public class FreeParameter : IFreeParameter
    {
        public string FullName { get { return $"{Prefix}{Name}"; } }

        public DbType DbType { get; set; } = DbType.Object;

        public ParameterDirection Direction { get; set; } = ParameterDirection.Input;

        public object Value { get; set; }

        public string Name { get; set; }

        public string ParameterPrefix { get { return "p"; } }

        public bool IsGeneratedByDb { get; set; } = false;

        public string Prefix { get; set; }
    }
}
