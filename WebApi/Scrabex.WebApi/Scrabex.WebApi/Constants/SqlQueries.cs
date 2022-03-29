namespace Scrabex.WebApi.Constants
{
    public static class SqlQueries
    {
        public static string GetAll(string model) => $"SELECT * FROM {model};";
        public static string GetBy(string model, string argument, string argumentValue) => $"SELECT * FROM {model} WHERE {argument} like '{argumentValue}';";
        public static string DeleteBy(string model, string argument, string argumentValue) => $"DELETE FROM {model} WHERE {argument} like '{argumentValue}';";
        public static string UpdateBy(string model, string updatedField, string fieldValue, string argument, string argumentValue) => $"UPDATE {model} SET {updatedField} = '{fieldValue}' WHERE {argument} like '{argumentValue}';";
        public static string Add(string model, IEnumerable<string> values) => $"INSERT INTO {model} VALUES ({GetValues(values)});";

        private static string GetValues(IEnumerable<string> values) => string.Join(", ", values.Select(p => $"'{p}'").ToArray());

    }
}
