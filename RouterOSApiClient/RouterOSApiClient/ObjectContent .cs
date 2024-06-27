using System.Net;
using System.Text.Json;

namespace RouterOSApiClient {
    // Обходной путь для решение проблемы с отправкой заголовка Content-Length
    // https://github.com/dotnet/runtime/issues/70793

    public class ObjectContent : HttpContent {

        public ObjectContent(Type type, object value, JsonSerializerOptions settings) {
            ObjectType = type;
            Settings = settings;
            Value = value;

            JsonSerializer.Serialize(_stream, Value, ObjectType, Settings);
            _stream.Position = 0;
        }

        private readonly MemoryStream _stream = new MemoryStream();
        public Type ObjectType { get; }
        private JsonSerializerOptions Settings { get; }
        public object Value { get; private set; }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context) {
            _stream.CopyTo(stream);
        }

        protected override bool TryComputeLength(out long length) {
            length = _stream.Length;
            // length successfully computed
            return true;
        }
    }
}
