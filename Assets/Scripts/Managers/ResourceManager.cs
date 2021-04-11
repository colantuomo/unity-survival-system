using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    void Start()
    {
        ResourceEvents.current.onGrabWood += OnWoodCollected;
        ResourceEvents.current.onGrabFood += OnFoodCollected;
        ResourceEvents.current.onGrabRock += OnRockCollected;
    }

    void OnWoodCollected()
    {
        Storage.current.addResource("Wood");
    }

    void OnRockCollected()
    {
        Storage.current.addResource("Rock");
    }

    void OnFoodCollected()
    {
        Storage.current.addResource("Food");
    }
}
