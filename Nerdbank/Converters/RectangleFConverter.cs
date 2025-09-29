using Nerdbank.MessagePack;

namespace Nerdbank.Converters
{
    public class RectangleFConverter : MessagePackConverter<RectangleF>
    {
        public override void Write(ref MessagePackWriter writer, in RectangleF value, SerializationContext context)
        {
            context.DepthStep();
            writer.WriteArrayHeader(4);
            writer.Write(value.X);
            writer.Write(value.Y);
            writer.Write(value.Width);
            writer.Write(value.Height);
        }

        public override RectangleF Read(ref MessagePackReader reader, SerializationContext context)
        {
            context.DepthStep();
            var count = reader.ReadArrayHeader();
            if (count != 4)
            {
                throw new InvalidOperationException($"Invalid RectangleF array length: {count}. Expected 4.");
            }

            return new RectangleF(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }
    }
}
