using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class CausingDamage : IReaction
{
    private Health Health;
        
    public void SetParametrs(Health health)
    {
        Health = health;
    }
        
    public void React()
    {
        Health.TakingDamage();
    }
}
