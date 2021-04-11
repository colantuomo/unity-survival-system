using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
    void Start()
    {
        UIEvents.current.onUpdate += OnCollected;
    }

    void OnCollected(string name)
    {
        int value = 0;
        Storage.current.resources.TryGetValue(gameObject.name, out value);
        if (value != 0)
        {
            GetComponentInChildren<Text>().text = $"x {value}";
        }
    }
}
