using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RadiusableDetector : MonoBehaviour
{
    [SerializeField] 
    [Range(0.1f,10)]
    private float _radius;
    [SerializeField] 
    [Range(0.05f,1f)]
    private float _timeDetect;
[SerializeField]
    private float _maxDist = 1;

    [SerializeField] private Vector3 size;//
    [SerializeField] private Vector3 pos;
    [SerializeField] private Vector3 napr;
    [SerializeField] private Vector3 sizeSten = Vector3.one;
    public event Action<GameObject> Detecting;


    private void Start()
    {
        StartCoroutine(Enumerable());
    }

    private void ScanRadius()
    {
        RaycastHit hit;

        if (Physics.BoxCast(transform.position, sizeSten * _radius/2, napr, out hit,transform.rotation,_maxDist))
        {
            Detecting?.Invoke(hit.collider.gameObject); 
            Debug.Log("нашел обьект" +hit.collider.gameObject.name );
            
        }
        
        // if (TryGetComponent<Collider>(out Collider col))
        // {
        //     Debug.Log(col.bounds.center);
        // }
    }

    private void OnDrawGizmos()
    {
        size.x = _radius;
        size.y = _radius;
        //size.z = (_maxDist - 1) * napr.normalized.z;
        //pos.z = (1 + _maxDist / 2 + 0.5f * (_radius - 1)) * napr.normalized.z;

        size.z = (_maxDist - (1)) * napr.normalized.z;
        pos.z = ((0.5f + (sizeSten.z / 2)*_radius) + _maxDist / 2) * napr.normalized.z;
        Gizmos.DrawWireCube(transform.position + pos, size);
     
    }
 
    IEnumerator Enumerable()
    {
        yield return new WaitForSeconds(_timeDetect);
        ScanRadius();
        StartCoroutine(Enumerable());
    }
    


}
