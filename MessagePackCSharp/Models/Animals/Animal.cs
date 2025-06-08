using MessagePack;

namespace MessagePackTests.Models.Animals
{
    [Union(0, typeof(Capybara))]
    [Union(1, typeof(SnowLeopard))]
    [Union(2, typeof(Axolotl))]
    [Union(3, typeof(BlueJay))]
    [Union(4, typeof(KomodoDragon))]
    [Union(5, typeof(Manatee))]
    [Union(6, typeof(RedPanda))]
    [MessagePackObject]
    public abstract partial class Animal
    {
        private readonly string _name;

        protected Animal(Guid id, Vector2 position, float depth, AnimalTypes type)
        {
            Id = id;

            SetDepth(depth);

            Position = position;
            Type = type;

            _name = type.ToString();
        }

        [Key(0)]
        public Guid Id { get; private set; }

        [Key(1)]
        public Vector2 Position { get; private set; }

        [Key(2)]
        public float Depth { get; protected set; }

        [IgnoreMember]
        public AnimalTypes Type { get; }

        public Animal SetDepth(float depth)
        {
            Depth = depth;
            return this;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
