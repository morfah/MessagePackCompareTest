using MessagePack;
using MessagePack.Formatters;

namespace MessagePackCSTests.Formatters
{
    /// <summary>
    /// Color formatter for MessagePack. Compatible with FNA.
    /// </summary>
    public class ColorFormatter : IMessagePackFormatter<Color>
    {
        public void Serialize(ref MessagePackWriter writer, Color value, MessagePackSerializerOptions options)
        {
            writer.WriteInt32(value.ToArgb());
        }

        public Color Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            Color value = Color.FromArgb(reader.ReadInt32());
            return value;
        }
    }
}
