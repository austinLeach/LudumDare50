using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    float speed = 3;
    public bool Boss = false;


    // Start is called before the first frame update
    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.z = -2;
    }

    public void Shoot(Vector2 direction) 
    {
        rigidBody2D.AddForce(direction.normalized * 800);
    }

    public Rigidbody2D GetRigidBody2D()
    {
        return rigidBody2D;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "finalboss") {
            Destroy(this.gameObject);
        }
    }
}
