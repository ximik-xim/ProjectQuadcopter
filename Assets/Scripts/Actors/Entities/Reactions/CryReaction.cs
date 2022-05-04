using Assets.Scripts;
using UnityEngine;

public class CryReaction : IReaction
{
    public void React()
    {
        Debug.Log("Увидели препятствие перед собой");
    }
}
