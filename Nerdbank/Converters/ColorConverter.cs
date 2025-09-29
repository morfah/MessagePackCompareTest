using Nerdbank.MessagePack;

namespace Nerdbank.Converters
{
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
            return Color.FromArgb(reader.ReadInt32());
        }
    }
}
