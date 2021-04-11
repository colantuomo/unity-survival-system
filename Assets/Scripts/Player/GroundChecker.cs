using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public float radius;
    private int foodLayer;
    void Start()
    {
        foodLayer = LayerMask.GetMask("Food");
    }

    void FixedUpdate()
    {
        FoodChecker();
    }

    void FoodChecker()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, foodLayer);
        foreach (Collider col in colliders)
        {
            col.GetComponent<FoodBehavior>().Collect();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
