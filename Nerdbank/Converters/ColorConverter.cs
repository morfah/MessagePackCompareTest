using Nerdbank.MessagePack;

namespace MessagePackTests.Converters
{
    /// <summary>
    /// Color converter for MessagePack. Compatible with FNA.
    /// </summary>
    public class ColorConverter : MessagePackConverter<Color>
    {
        public override void Write(ref MessagePackWriter writer, in Color value, SerializationContext context)
        {
            context.DepthStep();
            writer.WriteInt32(value.ToArgb());
        }

        public override Color Read(ref MessagePackReader reader, SerializationContext context)
        {
            context.DepthStep();
            Color value = Color.FromArgb(reader.ReadInt32());
            return value;
        }
    }
}
