using Nerdbank.MessagePack;

namespace MessagePackTests.Converters
{
    public sealed class EngineSerializer
    {
        private static readonly EngineSerializer _instance = new();

        private EngineSerializer()
        {
            Serializer = new MessagePackSerializer();

            Serializer = Serializer with
            {
                Converters = [
                    ..Serializer.Converters,
                    new ColorConverter(),
                    new PointConverter(),
                    new RectangleConverter(),
                    new RectangleFConverter(),
                    new Vector2Converter(),
                ]
            };
        }

        public static EngineSerializer Instance => _instance;

        public MessagePackSerializer Serializer { get; }
    }
}
