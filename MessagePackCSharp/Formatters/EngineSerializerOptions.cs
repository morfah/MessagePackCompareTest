using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;

namespace MessagePackCSharp.Formatters
{
    public sealed class EngineSerializerOptions
    {
        private static readonly EngineSerializerOptions _instance = new();

        private EngineSerializerOptions()
        {
            Options = CreateOptions();
        }

        public static EngineSerializerOptions Instance => _instance;

        public MessagePackSerializerOptions Options { get; }

        private static MessagePackSerializerOptions CreateOptions()
        {
            IMessagePackFormatter[] formatters =
            [
                new ColorFormatter(),
                new Vector2Formatter(),
                new PointFormatter(),
                new RectangleFFormatter(),
                new RectangleFormatter(),
            ];

            IFormatterResolver resolver = CompositeResolver.Create(formatters,
            [
                NativeGuidResolver.Instance,
                StandardResolver.Instance // Fallback resolver
            ]);

            MessagePackSerializerOptions options = MessagePackSerializerOptions.Standard
                .WithResolver(resolver)
                .WithCompression(MessagePackCompression.Lz4Block);

            return options;
        }
    }
}
