namespace FreeLibrary.Interfaces
{
    public interface IFreeParameter : IFreeDbParameter
    {
        string FullName { get; }

        string Prefix { get; set; }

        object Value { get; set; }
    }
}
