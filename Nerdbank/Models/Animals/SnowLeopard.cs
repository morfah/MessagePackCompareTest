using Nerdbank.MessagePack;

namespace MessagePackTests.Models.Animals
{
    public class SnowLeopard : Animal
    {
        public SnowLeopard(Guid id, Vector2 position, float depth, Guid? parentId)
            : base(id, position, depth, AnimalTypes.SnowLeopard)
        {
            ParentId = parentId;
        }

        [Key(3)]
        public Guid? ParentId { get; private set; }
    }
}
