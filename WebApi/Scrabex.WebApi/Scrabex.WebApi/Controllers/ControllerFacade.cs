using Scrabex.WebApi.Constants;
using Scrabex.WebApi.Models;
using Scrabex.WebApi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Scrabex.WebApi.Controllers
{
    public class ControllerFacade : IControllerFacade
    {
        protected IDictionary<Type, ModelMetadata> _modelMetadata;
        private readonly string _connString;

        public ControllerFacade(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("devConnection");
            _modelMetadata = new Dictionary<Type, ModelMetadata>
            {
                { typeof(User), GetMeta<User>() },
                { typeof(UserDetail), GetMeta<UserDetail>() },
                { typeof(Scenario), GetMeta<Scenario>() },
                { typeof(ScenarioStep), GetMeta<ScenarioStep>() },
                { typeof(ScenarioComponent), GetMeta<ScenarioComponent>() }
            };
        }
        public IEnumerable<T> GetAll<T>() where T : new()
        {
            var results = new List<T>();
            var rows = GetRows(_modelMetadata[typeof(T)].GetAll);
            var enumerator = rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var row = enumerator.Current as DataRow;
                if (row is null) continue;
                results.Add(row.GetFromDataRow<T>());
            }
            return results;
        }

       /* protected T Add<T>(object[] params) where T : new()
        {

        }
       */

        private DataRowCollection GetRows(string query)
        {
            var table = new DataTable();
            using var conn = new SqlConnection(_connString);
            conn.Open();
            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            table.Load(reader);
            return table.Rows;
        }



        private ModelMetadata GetMeta<T>()
        {
            
            switch(typeof(T).Name)
            {
                case "User":
                    return GetMeta(TableNames.Users, typeof(T));

                case "UserDetail":
                    return GetMeta(TableNames.UserDetails, typeof(T));

                case "Scenario":
                    return GetMeta(TableNames.Scenarios, typeof(T));

                case "ScenarioStep":
                    return GetMeta(TableNames.ScenarioSteps, typeof(T));

                case "ScenarioComponent":
                    return GetMeta(TableNames.ScenarioComponents, typeof(T));

                default:
                    throw new NotImplementedException("No metadata defined for given entity.");
            }
        }

        private ModelMetadata GetMeta(string model, Type type) => new ModelMetadata(
                    type,
                    SqlQueries.GetAll(model),
                    (values) => SqlQueries.Add(model, values),
                    (field, fieldValue, arg, argValue) => SqlQueries.UpdateBy(model, field, fieldValue, arg, argValue),
                    (arg, argValue) => SqlQueries.DeleteBy(model, arg, argValue),
                    (arg, argValue) => SqlQueries.GetBy(model, arg, argValue));
    }
}
