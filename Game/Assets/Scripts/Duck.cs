using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    Animator duckAnimator;
    Vector3 mouseOffset;
    public bool wandering = true;
    float wanderTimer;

    bool cooldown = false;
    float cooldownTimer;
    float velocityX = 0;
    float velocityY = 0;
    bool firstSpawn = true;

    public bool movingDuck = false;
    public bool insideSac = false;
    public bool insideBoundary = false;
    bool isQuacking = true;
    float quackTimer;
    bool quackDialogue = false;
    float quackDialogueTimer;
    bool initializedQuack = false;
    public GameObject quack;
    bool hasFallen = false;
    bool isDead = false;
    float shrinkSpeed = 0.7f;
    float scale = 0.7f;
    public ParticleSystem sacrificeAnimation;
    // Start is called before the first frame update
    void Start()
    {
        //set up animator
        duckAnimator = GetComponent<Animator>();
        wanderTimer = Random.Range(0f, 4f);
        quack.SetActive(false);
        if (GlobalVariables.finalTime) {
            quackTimer = Random.Range(0f, 3f);
        } else {
            quackTimer = Random.Range(10f, 60f);
        }
        sacrificeAnimation.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        //stop duck walking in place on spawn
        if (!firstSpawn)
        {
            duckAnimator.SetBool("wandering", wandering);
        }
        else
        {
            duckAnimator.SetBool("wandering", false);    
        }
        

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
            // DestroyDuck();
        }
        if (insideBoundary && !movingDuck && !hasFallen) {
            hasFallen = true;
            DestroyDuck();
        }
        if(hasFallen)
        {
            transform.Rotate(0f, 0f, 4f, Space.Self);
            scale -= Time.deltaTime * shrinkSpeed;
            transform.localScale = new Vector3(scale, scale, scale);
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
        if (!GlobalVariables.finalTime) {
            wanderTimer = Random.Range(0f, 2f);
            velocityX = Random.Range(0f, 5f) - 2.5f;
            velocityY = Random.Range(0f, 5f) - 2.5f;
            wandering = true;
            duckAnimator.SetBool("wandering", wandering);
            wanderTimer = Random.Range(0f, 2f);
            cooldown = true;
            cooldownTimer = Random.Range(3f, 5f);
        } else {
            wanderTimer = Random.Range(0f, .5f);
            velocityX = Random.Range(0f, 1f) - .5f;
            velocityY = Random.Range(0f, 1f) - .5f;            
            wandering = true;
            wanderTimer = Random.Range(0f, .5f);
            cooldown = true;
            cooldownTimer = Random.Range(3f, 5f);
        }
        firstSpawn = false;
    }

    public void DestroyDuck(bool sacrificed = false) {
        if (this.gameObject && sacrificed && !isDead) {
            StartCoroutine(WaitTimer(0.5f));
            sacrificeAnimation.enableEmission = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            // Destroy(this.gameObject);
            // GlobalVariables.population--;
        } else if (this.gameObject && !isDead) {
            hasFallen = true;
            StartCoroutine(WaitTimer(1));
        }
        //Destroy(this.gameObject);
        //GlobalVariables.population--;
    }

    private IEnumerator WaitTimer(float deathTimer)
    {
        if (!isDead)
            GlobalVariables.population--;
        isDead = true;
        yield return new WaitForSeconds(deathTimer);
        //GlobalVariables.population--;
        Destroy(this.gameObject);
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
