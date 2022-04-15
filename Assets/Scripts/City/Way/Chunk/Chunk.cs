using UnityEngine;

namespace Assets.Scripts
{
    public class Chunk : Mover 
    {
        public float Size => GetComponentInChildren<MeshRenderer>().bounds.size.z;
    }
}