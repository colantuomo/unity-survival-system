using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    private Rigidbody rb;
    public float health = 30f;
    public ParticleSystem woodFX;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool canBreak = health <= 0;
        if (canBreak)
        {
            ResourceEvents.current.OnGrabWoodTrigger();
            Destroy(gameObject);
        }
    }

    public void BeenHit(float damage, Vector3 playerPosition, float hitForce = 2f)
    {
        health -= damage;
        Vector3 dir = transform.position - playerPosition;
        rb.AddForce(new Vector3(dir.x, 0f, dir.z) * hitForce, ForceMode.Impulse);
        Instantiate(woodFX, playerPosition, Quaternion.identity);
    }

}
