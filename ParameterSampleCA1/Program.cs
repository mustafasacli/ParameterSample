using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeLibrary.Entity;
using FreeLibrary.Parameter;
using FreeLibrary.Factory;
using FreeLibrary.Interfaces;

namespace ParameterSampleCA1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Name = "Levent" };
            List<IFreeParameter> prms = FreeParameterFactory.Instance.GenerateFrom(p);

            foreach (var item in prms)
            {
                Console.WriteLine($"ParameterName: {item.FullName} - Db Type: {item.DbType} - Parameter Direction: {item.Direction} - Value: {item.Value ?? "NULL"}");
            }

            Console.ReadKey();
        }
    }

    [FreeDbTable(Name = "PERSON", SchemaName = "MST")]
    public class Person : FreeDbEntity
    {
        [FreeDbParameter(Name = "PID", DbType = System.Data.DbType.Int32, IsGeneratedByDb = true)]
        public int Id { get; set; }

        [FreeDbParameter(Name = "PERSONNAME", DbType = System.Data.DbType.String)]
        public string Name { get; set; }
    }
}
