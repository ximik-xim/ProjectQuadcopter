using UnityEngine;

namespace Assets.Scripts
{
    public class Chunk : Movable 
    {
        public float Size => GetComponentInChildren<MeshRenderer>().bounds.size.z;
    }
}