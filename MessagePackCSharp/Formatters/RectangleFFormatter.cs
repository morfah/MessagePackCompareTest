using MessagePack;
using MessagePack.Formatters;

namespace MessagePackCSTests.Formatters
{
    /// <summary>
    /// RectangleF formatter for MessagePack.
    /// </summary>
    public class RectangleFFormatter : IMessagePackFormatter<RectangleF>
    {
        public void Serialize(ref MessagePackWriter writer, RectangleF value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(4);
            writer.Write(value.X);
            writer.Write(value.Y);
            writer.Write(value.Width);
            writer.Write(value.Height);
        }

        public RectangleF Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var count = reader.ReadArrayHeader();
            if (count != 4)
            {
                throw new InvalidOperationException($"Invalid RectangleF array length: {count}. Expected 4.");
            }

            return new RectangleF(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }
    }
}
