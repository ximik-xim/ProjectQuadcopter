using UnityEngine;

namespace Assets.Scripts
{
    public class Window : MonoBehaviour
    {
        private NetGuy _netGuy;

        public bool IsEmpty => _netGuy == null;

        public void Settle(NetGuy netGuy) => _netGuy = netGuy;
    }
}