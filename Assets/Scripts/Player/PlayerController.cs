using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int hitForce;
    public float radius;
    public Transform attackPoint;

    private CinemachineImpulseSource screenshake;
    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody rb;
    private Animator anim;
    void Start()
    {
        screenshake = GetComponent<CinemachineImpulseSource>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", moveHorizontal);
        anim.SetFloat("Vertical", moveVertical);
        MovePlayerTowardsMouse();
        MovePlayer();
    }

    IEnumerator Attack()
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.3f);
        LayerMask layer = LayerMask.GetMask("Environment");
        Collider[] colliders = Physics.OverlapSphere(attackPoint.position, radius, layer);
        if (colliders.Length > 0)
        {
            screenshake.GenerateImpulse();
        }
        foreach (Collider col in colliders)
        {
            switch (col.tag)
            {
                case "Box":
                    col.GetComponent<BoxBehavior>().BeenHit(10f, transform.position, hitForce);
                    break;
                case "Tree":
                    col.GetComponent<TreeBehavior>().BeenHit(col.transform.position);
                    break;
                case "Rock":
                    col.GetComponent<RockBehavior>().BeenHit(col.transform.position);
                    break;
            }
        }
    }



    void MovePlayerTowardsMouse()
    {
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);
    }

    void MovePlayer()
    {
        float sideWalkSpeed = 2f;
        float backwardSpeed = 3f;
        if (moveVertical > 0 && Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (moveVertical < 0 && Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * backwardSpeed * Time.deltaTime, Camera.main.transform);
        }

        if (moveHorizontal < 0 && Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * sideWalkSpeed * Time.deltaTime, Camera.main.transform);
        }
        else if (moveHorizontal > 0 && Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * sideWalkSpeed * Time.deltaTime, Camera.main.transform);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
