using Nerdbank.MessagePack;

namespace Nerdbank.Models.Animals
{
    public class KomodoDragon : Animal
    {
        public KomodoDragon(
            Guid id,
            Vector2 position,
            float depth,
            float rotation,
            Color color,
            Rectangle sourceRectangle,
            bool isOpened,
            float openedAmount)
            : base(id, position, depth, AnimalTypes.KomodoDragon)
        {
            Rotation = rotation;
            Color = color;
            SourceRectangle = sourceRectangle;
            IsOpened = isOpened;
            OpenedAmount = openedAmount;
        }

        [Key(3)]
        public float Rotation { get; private set; }

        [Key(4)]
        public Color Color { get; private set; }

        [Key(6)]
        public Rectangle SourceRectangle { get; private set; }

        [Key(7)]
        public bool IsOpened { get; private set; }

        [Key(8)]
        public float OpenedAmount { get; private set; }
    }
}
