using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<GameObject> Detecting; 
    
    private void OnTriggerEnter(Collider other)
    {
        Detecting?.Invoke(other.gameObject);
    }
}
