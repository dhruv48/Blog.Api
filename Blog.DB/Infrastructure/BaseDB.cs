using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Blog.DB.Infrastructure
{
    public class BaseDB
    {
        private const string CONNECTION_STRING = "ConnectionString";
        protected SqlConnection connection;
        //protected JsonSerilzationSettings nullvaluesettings
        protected JsonSerializerSettings nullValueSettings;

        public BaseDB(IConfiguration configuration)
        {
            var connecionString = configuration.GetSection(CONNECTION_STRING);
            if (string.IsNullOrWhiteSpace(connecionString.Value))
                throw new Exception("Connection String not Found or Null!");

            connection = new SqlConnection(connecionString.Value);
            nullValueSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
            };

            AddTypeHandler(JObjectHandler.Instance);
        }

      

        internal class JArrayTypeHandler : Dapper.SqlMapper.TypeHandler<JArray>
        {
            public override JArray Parse(object value)
            {
                string json = value.ToString();
                return JArray.Parse(json);
            }

            public override void SetValue(System.Data.IDbDataParameter parameter, JArray value)
            {
                parameter.Value = value;
            }

        }

        // dapper extension to implement JObject support
        class JObjectHandler : Dapper.SqlMapper.TypeHandler<JObject>
        {
            private JObjectHandler() { }
            public static JObjectHandler Instance { get; } = new JObjectHandler();
            public override JObject Parse(object value)
            {
                var json = (string)value;
                return json == null ? null : JObject.Parse(json);
            }
            public override void SetValue(System.Data.IDbDataParameter parameter, JObject value)
            {
                parameter.Value = value?.ToString(Newtonsoft.Json.Formatting.None);
            }
        }

        public class JsonObjectTypeHandler : Dapper.SqlMapper.ITypeHandler
        {
            public void SetValue(System.Data.IDbDataParameter parameter, object value)
            {
                parameter.Value = (value == null)
                ? (object)DBNull.Value
                : JsonConvert.SerializeObject(value);
                parameter.DbType = DbType.String;
            }

            public object Parse(Type destinationType, object value)
            {
                return JsonConvert.DeserializeObject(value.ToString(), destinationType);
            }
        }
    }
}
