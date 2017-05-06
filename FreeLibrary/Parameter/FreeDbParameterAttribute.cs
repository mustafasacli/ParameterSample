using FreeLibrary.Interfaces;
using System;
using System.Data;

namespace FreeLibrary.Parameter
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    [System.Diagnostics.DebuggerDisplay("{Name} - {ParameterPrefix} - {DbType} - {Direction} - {IsGeneratedByDb}")]
    public class FreeDbParameterAttribute : Attribute, IFreeDbParameter
    {
        public string Name { get; set; }

        public virtual string ParameterPrefix { get { return "p"; } }

        public DbType DbType { get; set; }

        public ParameterDirection Direction { get; set; } = ParameterDirection.Input;

        public bool IsGeneratedByDb { get; set; } = false;
    }
}
