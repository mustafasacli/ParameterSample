using System;

namespace FreeLibrary.Entity
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class FreeDbTableAttribute : Attribute
    {
        public string Name { get; set; }

        public string SchemaName { get; set; }
    }
}
