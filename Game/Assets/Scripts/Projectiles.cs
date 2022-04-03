using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    Rigidbody2D rigidBody2D;
    float speed = 3;
    public bool Boss = false;
    public bool isNuke = false;


    // Start is called before the first frame update
    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.z = -2;
        if (!isNuke) {
            transform.Rotate(0f,0f,15f, Space.Self);
        }
    }

    public void Shoot(Vector2 direction, int force = 800) 
    {
        rigidBody2D.AddForce(direction.normalized * force);
    }

    public Rigidbody2D GetRigidBody2D()
    {
        return rigidBody2D;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "finalboss") {
            if (this.gameObject.tag == "artilery") {
                GlobalVariables.BossHealth -= 2500;
            } else if (this.gameObject.tag == "nuke") {
                GlobalVariables.nukeCollided = true;
            }
            Destroy(this.gameObject);
        }
    }
}
