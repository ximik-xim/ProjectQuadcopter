using UnityEngine;

namespace Assets.Scripts
{
    public class KnockedDownReaction : IReaction
    {
        Quadcopter _quadcopter;

        public KnockedDownReaction(Quadcopter quadcopter)
        {
            _quadcopter = quadcopter;
        }

        public void React()
        {
            Debug.Log("Knocked Down");
        }
    }
}
