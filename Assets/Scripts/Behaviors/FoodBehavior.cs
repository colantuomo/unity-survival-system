using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    public ParticleSystem foodFX;
    public void Collect()
    {
        Instantiate(foodFX, transform.position, Quaternion.identity);
        ResourceEvents.current.OnGrabFoodTrigger();
        Destroy(gameObject);
    }
}
