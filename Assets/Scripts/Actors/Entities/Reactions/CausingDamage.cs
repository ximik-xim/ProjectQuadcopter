using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class CausingDamage : IReaction
{
    private Health Health;

    public CausingDamage(Quadcopter quadcopter)
    {
        Health = quadcopter.gameObject.GetComponent<Health>();
    }
        
    public void React()
    {
        Health.TakingDamage();
    }
}
