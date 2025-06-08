namespace MessagePackTests.Models.Animals
{
    public class RedPanda : Animal
    {
        public RedPanda(Guid id, Vector2 position, float depth)
            : base(id, position, depth, AnimalTypes.RedPanda)
        {
        }
    }
}
