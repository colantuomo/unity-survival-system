using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
    public ParticleSystem woodFX;
    int HITS_TO_COLLECT = 3;
    int hitsTaken = 0;

    void Update()
    {
        if (hitsTaken >= HITS_TO_COLLECT)
        {
            ResourceEvents.current.OnGrabWoodTrigger();
            hitsTaken = 0;
            Destroy(gameObject);
        }
    }
    public void BeenHit(Vector3 hitPoint)
    {
        Instantiate(woodFX, hitPoint, Quaternion.identity);
        hitsTaken++;
    }
}
