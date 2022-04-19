using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public abstract class Reactable : Entity
    {
        protected Dictionary<Type, IReaction> _reactions = new Dictionary<Type, IReaction>();

        public void AddReaction(IReaction reaction) => _reactions.Add(reaction.GetType(), reaction);

        protected IReaction TryGetReaction<T>() where T : IReaction
        {
            if (_reactions.ContainsKey(typeof(T)))
            {
                var type = typeof(T);
                return _reactions[type];
            }

            new Exception("No Such Reaction");
            return null;
        }
    }
}
