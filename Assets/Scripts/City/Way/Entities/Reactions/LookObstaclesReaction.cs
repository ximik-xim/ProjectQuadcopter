using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class LookObstaclesReaction : IReaction
{
    public void React()
    {
        Debug.Log("Увидели препятствие перед собой");
    }
}
