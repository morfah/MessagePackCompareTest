using Nerdbank.MessagePack;
using PolyType;

namespace MessagePackTests.Models.Animals
{
    [DerivedTypeShape(typeof(Capybara), Tag = 0)]
    [DerivedTypeShape(typeof(SnowLeopard), Tag = 1)]
    [DerivedTypeShape(typeof(Axolotl), Tag = 2)]
    [DerivedTypeShape(typeof(BlueJay), Tag = 3)]
    [DerivedTypeShape(typeof(KomodoDragon), Tag = 4)]
    [DerivedTypeShape(typeof(Manatee), Tag = 5)]
    [DerivedTypeShape(typeof(RedPanda), Tag = 6)]
    public abstract class Animal
    {
        protected Animal(Guid id, Vector2 position, float depth, AnimalTypes type)
        {
            Id = id;

            SetDepth(depth);

            Position = position;
            Type = type;
        }

        [Key(0)]
        public Guid Id { get; private set; }

        [Key(1)]
        public Vector2 Position { get; private set; }

        [Key(2)]
        public float Depth { get; protected set; }

        [PropertyShape(Ignore = true)]
        public AnimalTypes Type { get; }

        public Animal SetDepth(float depth)
        {
            Depth = depth;
            return this;
        }
    }
}
