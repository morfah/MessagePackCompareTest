using MessagePack;
using MessagePackCSharp.Models.Animals;

namespace MessagePackCSharp.Models
{
    [MessagePackObject]
    public partial class MyShape
    {
        public MyShape(
            Guid id,
            string? name,
            Version version,
            List<Animal> animals)
        {
            Id = id;
            Version = version;
            Animals = animals ?? [];

            SetName(name);
        }

        [Key(0)]
        public Guid Id { get; }

        [Key(1)]
        public string? Name { get; private set; }

        [Key(2)]
        public Version Version { get; private set; }

        [Key(7)]
        public List<Animal> Animals { get; }

        public MyShape SetName(string? name)
        {
            Name = name;
            return this;
        }

        public MyShape AddShapeItem(Animal shapeItem)
        {
            ArgumentNullException.ThrowIfNull(shapeItem);

            Animals.Add(shapeItem);
            return this;
        }
    }
}
