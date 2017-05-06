using FreeLibrary.Interfaces;
using System.Collections.Generic;

namespace FreeLibrary.Factory
{
    public interface IFreeParameterFactory
    {
        List<IFreeParameter> GenerateFrom(IFreeDbEntity entity);//, bool isCreate = true);
    }
}
