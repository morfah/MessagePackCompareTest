using Nerdbank.MessagePack;

namespace MessagePackTests.Converters
{
    /// <summary>
    /// Point converter for MessagePack. Compatible with FNA & MonoGame.
    /// </summary>
    public class PointConverter : MessagePackConverter<Point>
    {
        public override void Write(ref MessagePackWriter writer, in Point value, SerializationContext context)
        {
            context.DepthStep();
            writer.WriteArrayHeader(2);
            writer.Write(value.X);
            writer.Write(value.Y);
        }

        public override Point Read(ref MessagePackReader reader, SerializationContext context)
        {
            context.DepthStep();
            var count = reader.ReadArrayHeader();
            if (count != 2)
            {
                throw new InvalidOperationException($"Invalid Point array length: {count}. Expected 2.");
            }

            return new Point(reader.ReadInt32(), reader.ReadInt32());
        }
    }
}
