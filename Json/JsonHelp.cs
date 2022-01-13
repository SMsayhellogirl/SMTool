using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;


namespace JTC_Help.Json
{
    /// <summary>
    /// 複寫JsonResult ,使datetime格式 符合 ISO-8601
    /// </summary>
    public class JsonNetResult : JsonResult
    {
        public JsonSerializerSettings SerializerSettings { get; set; }
        public Formatting Formatting { get; set; }

        public JsonNetResult()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrWhiteSpace(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                using (var writer = new JsonTextWriter(response.Output) { Formatting = Formatting })
                {
                    JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                    serializer.Serialize(writer, Data);
                    writer.Flush();
                }
            }
        }

    }

    public class JustJson
    {
        public string ToJsonString(object model)
        {
            return JsonConvert.SerializeObject(model);
        }
        public object ToJsonModel(string model)
        {
            return JsonConvert.DeserializeObject(model);
        }
    }

    public class HttpPostedFileConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var stream = (Stream)value;
            using (var sr = new BinaryReader(stream))
            {
                var buffer = sr.ReadBytes((int)stream.Length);
                writer.WriteValue(Convert.ToBase64String(buffer));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsSubclassOf(typeof(Stream));
        }
    }
}
