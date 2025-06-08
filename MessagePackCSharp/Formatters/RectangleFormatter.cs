using MessagePack;
using MessagePack.Formatters;

namespace MessagePackCSTests.Formatters
{
    public class RectangleFormatter : IMessagePackFormatter<Rectangle>
    {
        public void Serialize(ref MessagePackWriter writer, Rectangle value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(4);
            writer.Write(value.X);
            writer.Write(value.Y);
            writer.Write(value.Width);
            writer.Write(value.Height);
        }

        public Rectangle Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var count = reader.ReadArrayHeader();
            if (count != 4)
            {
                throw new InvalidOperationException($"Invalid Rectangle array length: {count}. Expected 4.");
            }

            return new Rectangle(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        }
    }
}
