using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    Vector3 mouseOffset;
    bool wandering = true;
    float wanderTimer = 3f;

    bool cooldown = false;
    float cooldownTimer;
    float velocityX = 0;
    float velocityY = 0;

    public bool movingDuck = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wandering && !movingDuck) {
            Vector2 position = transform.position;
            position.x = position.x + velocityX * Time.deltaTime;
            position.y = position.y + velocityY * Time.deltaTime;
            transform.position = position;
        }
        Wander();
        GlobalVariables.Timer(ref wandering, ref wanderTimer);
        GlobalVariables.Timer(ref cooldown, ref cooldownTimer);
    }

    public void CheckOffset() {
        mouseOffset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseOffset.z = 0;
    }

    public void MoveDuck() {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        transform.position = mouse + mouseOffset;
    }

    void Wander() {
        if (wandering || cooldown) {
            return;
        }
        float zero = 0;
        float max = 2;
        wanderTimer = Random.Range(zero, max);
        velocityX = Random.Range(zero, 1f) - .5f;
        velocityY = Random.Range(zero, 1f) - .5f;
        wandering = true;
        wanderTimer = Random.Range(zero, .5f);
        cooldown = true;
        cooldownTimer = Random.Range(3f, 5f);
    }
}