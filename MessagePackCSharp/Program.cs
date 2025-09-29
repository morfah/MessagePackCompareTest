using MessagePack;
using MessagePackCSharp.Formatters;
using MessagePackCSharp.Models;
using MessagePackCSharp.Models.Animals;

namespace MessagePackCSharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyShape myShape = CreateShape();
            byte[] bytes = MessagePackSerializer.Serialize(myShape, EngineSerializerOptions.Instance.Options);

            MyShape? myShape2 = MessagePackSerializer.Deserialize<MyShape>(bytes, EngineSerializerOptions.Instance.Options);
            byte[] bytes2 = MessagePackSerializer.Serialize(myShape2, EngineSerializerOptions.Instance.Options);

            if (bytes.Length != bytes2.Length)
            {
                throw new Exception("Bad");
            }

            for (int i = 0; i < bytes.Length; i++)
            {
                if (!bytes[i].Equals(bytes2[i]))
                {
                    throw new Exception("Bad");
                }
            }

            Console.WriteLine("Success");
        }

        private static MyShape CreateShape()
        {
            MyShape shape = new(
                Guid.NewGuid(),
                "Test shape",
                new Version(2, 0),
                [
                    new Capybara(Guid.NewGuid(), new Vector2(64f, 0f), 0.1f),
                    new SnowLeopard(Guid.NewGuid(), new Vector2(64f, 128f), 0.1f, null),
                    new KomodoDragon(Guid.NewGuid(), new Vector2(64f, 256f), 0f, 0.1f, Color.White, Rectangle.Empty, false, 0.5f)
                ]);

            return shape;
        }
    }
}