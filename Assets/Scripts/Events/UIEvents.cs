using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public static UIEvents current;
    private void Awake()
    {
        current = this;
    }

    public event Action<string> onUpdate;
    public void OnUpdateTrigger(string name)
    {
        if (onUpdate != null)
        {
            onUpdate(name);
        }
    }
}
