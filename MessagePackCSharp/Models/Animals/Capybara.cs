using MessagePack;

namespace MessagePackTests.Models.Animals
{
    [MessagePackObject]
    public sealed class Capybara : Animal
    {

        public Capybara(Guid id, Vector2 position, float depth)
            : base(id, position, depth, AnimalTypes.Capybara)
        {
        }
    }
}
