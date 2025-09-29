using MessagePack;
using MessagePack.Formatters;

namespace MessagePackCSharp.Formatters
{
    public class PointFormatter : IMessagePackFormatter<Point>
    {
        public void Serialize(ref MessagePackWriter writer, Point value, MessagePackSerializerOptions options)
        {
            writer.WriteArrayHeader(2);
            writer.Write(value.X);
            writer.Write(value.Y);
        }

        public Point Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var count = reader.ReadArrayHeader();
            if (count != 2)
            {
                throw new InvalidOperationException($"Invalid Point array length: {count}. Expected 2.");
            }

            return new Point(reader.ReadInt32(), reader.ReadInt32());
        }
    }
}
