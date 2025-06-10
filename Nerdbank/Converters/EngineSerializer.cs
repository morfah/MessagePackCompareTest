using Nerdbank.MessagePack;

namespace MessagePackTests.Converters
{
    public sealed class EngineSerializer
    {
        private static readonly EngineSerializer _instance = new EngineSerializer();

        private EngineSerializer()
        {
            Serializer = new MessagePackSerializer()
                .WithGuidConverter(OptionalConverters.GuidFormat.BinaryLittleEndian);

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
