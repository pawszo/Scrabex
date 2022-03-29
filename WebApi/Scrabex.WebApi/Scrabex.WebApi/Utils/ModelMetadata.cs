namespace Scrabex.WebApi.Utils
{
    public class ModelMetadata
    {
        public ModelMetadata(Type type, string getAll, Func<IEnumerable<string>, string> add, Func<string, string, string, string, string> update, Func<string, string, string> delete, Func<string, string, string> get)
        {
            Type = type;
            GetAll = getAll;
            Add = add;
            Update = update;
            Delete = delete;
            Get = get;
        }

        public Type Type { get; set; }
        public string GetAll { get; set; }
        public Func<IEnumerable<string>,string> Add { get; set; }
        public Func<string,string,string,string,string> Update { get; set; }
        public Func<string,string,string> Delete { get; set; }
        public Func<string,string,string> Get { get; set; }
    }
}
