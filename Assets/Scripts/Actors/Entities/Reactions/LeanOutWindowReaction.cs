using UnityEngine;

namespace Assets.Scripts
{
    public class LeanOutWindowReaction : IReaction
    {
        public LeanOutWindowReaction()
        {

        }

        public void React()
        {
            Debug.Log("Lean Out The Window");
        }
    }
}
