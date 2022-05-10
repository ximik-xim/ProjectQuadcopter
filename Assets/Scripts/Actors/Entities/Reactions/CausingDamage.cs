namespace Assets.Scripts
{
    public class CausingDamage : IReaction
    {
        private Health _targetHealth;

        public CausingDamage(Health targetHealth) => _targetHealth = targetHealth;

        public void React() => _targetHealth.TakeDamage();
    }
}