using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    Vector3 mouseOffset;
    public bool wandering = true;
    float wanderTimer;

    bool cooldown = false;
    float cooldownTimer;
    float velocityX = 0;
    float velocityY = 0;

    public bool movingDuck = false;
    public bool insideSac = false;
    public bool insideBoundary = false;
    bool isQuacking = true;
    float quackTimer;
    bool quackDialogue = false;
    float quackDialogueTimer;
    bool initializedQuack = false;
    public GameObject quack;
    // Start is called before the first frame update
    void Start()
    {
        wanderTimer = Random.Range(0f, 4f);
        quack.SetActive(false);
        if (GlobalVariables.finalTime) {
            quackTimer = Random.Range(0f, 3f);
        } else {
            quackTimer = Random.Range(10f, 60f);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.finalTime && !initializedQuack) {
            quackTimer = Random.Range(0f, 3f);
            initializedQuack = true;
        }
        if (wandering && !movingDuck) {
            Vector2 position = transform.position;
            position.x = position.x + velocityX * Time.deltaTime;
            position.y = position.y + velocityY * Time.deltaTime;
            transform.position = position;
        }
        Wander();
        GlobalVariables.Timer(ref wandering, ref wanderTimer);
        GlobalVariables.Timer(ref cooldown, ref cooldownTimer);
        GlobalVariables.Timer(ref isQuacking, ref quackTimer);
        GlobalVariables.Timer(ref quackDialogue, ref quackDialogueTimer);
        Quack();
        ReturnQuack();

        if (insideSac && !movingDuck) {
            DestroyDuck();
        }
        if (insideBoundary && !movingDuck) {
            DestroyDuck();
        }
    }

    public void CheckOffset() {
        mouseOffset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseOffset.z = -1;
    }

    public void MoveDuck() {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = -1;
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

    private void OnTriggerEnter2D(Collider2D other) {
        Boundary boundary = other.GetComponent<Boundary>();
        Sacrifice sacrifice = other.GetComponent<Sacrifice>();
        if (sacrifice) {
            insideSac = true;
        }
        if (boundary) {
            insideBoundary = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Boundary boundary = other.GetComponent<Boundary>();
        Sacrifice sacrifice = other.GetComponent<Sacrifice>();
        if (sacrifice) {
            insideSac = false;
        }
         if (boundary) {
            insideBoundary = false;
        }
    }

    void DestroyDuck() {
        Destroy(this.gameObject);
        GlobalVariables.population--;
    }

    void Quack() {
        if(isQuacking) {
            return;
        }
        isQuacking = true;
        if (GlobalVariables.finalTime) {
            quackTimer = Random.Range(1f, 8f);
        }
        else {
            quackTimer = Random.Range(15f, 45f);
        }
        quack.SetActive(true);
        quackDialogue = true;
        quackDialogueTimer = .5f;
    }
    void ReturnQuack() {
        if(quackDialogue) {
            return;
        }
        quack.SetActive(false);
    }
}
