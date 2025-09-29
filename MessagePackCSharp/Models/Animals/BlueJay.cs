using MessagePack;

namespace MessagePackCSharp.Models.Animals
{
    [MessagePackObject]
    public class BlueJay : Animal
    {
        public BlueJay(
            Guid id,
            Vector2 position,
            float depth,
            float rotation,
            Color color,
            Rectangle sourceRectangle,
            bool isPressed,
            List<Guid> targets,
            Guid? parentId)
            : base(id, position, depth, AnimalTypes.BlueJay)
        {
            Rotation = rotation;
            Color = color;
            SourceRectangle = sourceRectangle;
            IsPressed = isPressed;
            Targets = targets ?? [];
            ParentId = parentId;
        }

        [Key(3)]
        public float Rotation { get; private set; }

        [Key(4)]
        public Color Color { get; private set; }

        [Key(6)]
        public Rectangle SourceRectangle { get; private set; }

        [Key(7)]
        public bool IsPressed { get; private set; }

        [Key(8)]
        public List<Guid> Targets { get; private set; }

        [Key(9)]
        public Guid? ParentId { get; private set; }
    }
}
