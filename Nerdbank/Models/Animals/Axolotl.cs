using Nerdbank.MessagePack;

namespace Nerdbank.Models.Animals
{
    public class Axolotl : Animal
    {
        public Axolotl(
            Guid id,
            Vector2 position,
            float depth,
            float rotation,
            Color color,
            Rectangle sourceRectangle,
            Guid? parentId)
            : base(id, position, depth, AnimalTypes.Axolotl)
        {
            Rotation = rotation;
            Color = color;
            SourceRectangle = sourceRectangle;
            ParentId = parentId;
        }

        [Key(3)]
        public float Rotation { get; private set; }

        [Key(4)]
        public Color Color { get; private set; }

        [Key(6)]
        public Rectangle SourceRectangle { get; private set; }

        [Key(7)]
        public Guid? ParentId { get; private set; }
    }
}
