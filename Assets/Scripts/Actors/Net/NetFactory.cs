using UnityEngine;

namespace Assets.Scripts
{
    class NetFactory : IFactory<Net>
    {
        public Net GetCreated()
        {
            throw new System.NotImplementedException();
        }
    }
}
