using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public static Storage current;
    public Dictionary<string, int> resources = new Dictionary<string, int>();
    private void Awake()
    {
        current = this;
    }

    public void addResource(string name)
    {
        int amount = 1;
        if (resources.ContainsKey(name))
        {
            int value;
            resources.TryGetValue(name, out value);
            value++;
            resources[name] = value;
        }
        else
        {
            resources.Add(name, amount);
        }
        UIEvents.current.OnUpdateTrigger(name);
    }
}
