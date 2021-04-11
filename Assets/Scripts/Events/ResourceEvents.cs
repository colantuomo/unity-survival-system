using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ResourceEvents : MonoBehaviour
{
    public static ResourceEvents current;
    private void Awake()
    {
        current = this;
    }

    public event Action onGrabWood;
    public void OnGrabWoodTrigger()
    {
        if (onGrabWood != null)
        {
            onGrabWood();
        }
    }

    public event Action onGrabRock;
    public void OnGrabRockTrigger()
    {
        if (onGrabRock != null)
        {
            onGrabRock();
        }
    }

    public event Action onGrabFood;
    public void OnGrabFoodTrigger()
    {
        if (onGrabFood != null)
        {
            onGrabFood();
        }
    }
}
