using System.Data;
using System.Reflection;

namespace Scrabex.WebApi.Utils
{
    public static class HelperMethods
    {
        public static T GetFromDataRow<T>(this DataRow row) where T : new ()
        {
            var obj = new T();
            var type = obj.GetType();
            for(int i = 0; i < row.ItemArray.Length; i++)
            {
                type?.GetProperty(row.Table.Columns[i].ColumnName, BindingFlags.Public | BindingFlags.Instance)
                    ?.SetValue(obj, row.ItemArray[i]);
            }
            
            return obj;
        }
    }
}
