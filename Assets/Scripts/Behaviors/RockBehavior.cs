using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    public ParticleSystem rockFX;
    int HITS_TO_COLLECT = 2;
    int hitsTaken = 0;

    void Update()
    {
        if (hitsTaken >= HITS_TO_COLLECT)
        {
            ResourceEvents.current.OnGrabRockTrigger();
            hitsTaken = 0;
        }
    }
    public void BeenHit(Vector3 hitPoint)
    {
        Instantiate(rockFX, hitPoint, Quaternion.identity);
        hitsTaken++;
    }
}
