namespace DataBase.Converters
{
    internal interface IConverter
    {
        internal void Load<T>(string fileName, T obj);
        internal T Unload<T>(string fileName);
    }
}
