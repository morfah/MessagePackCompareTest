using MessagePack;
using MessagePack.Formatters;

namespace MessagePackCSTests.Formatters
{
    public class Vector2Formatter : IMessagePackFormatter<Vector2>
    {
        public void Serialize(ref MessagePackWriter writer, Vector2 value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(2);
            writer.Write(value.X);
            writer.Write(value.Y);
        }

        public Vector2 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var count = reader.ReadArrayHeader();
            if (count != 2)
            {
                throw new InvalidOperationException($"Invalid Vector2 array length: {count}. Expected 2.");
            }

            return new Vector2(reader.ReadSingle(), reader.ReadSingle());
        }
    }
}
