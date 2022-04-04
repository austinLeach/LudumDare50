using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class DragDrop : MonoBehaviour
{

    public BoxCollider2D Hitbox;
    public bool MouseIsDown = false;
    public bool MouseDrag = false;
    public AudioSource audio;
    public int numberCanPickUp = 1;
    List<Duck> duckList = new List<Duck>();
    public Texture2D openHand;
    public Texture2D closeHand;

    // Start is called before the first frame update
    void Start()
    {
        audio.time = GlobalVariables.timeInAudio1;
        GlobalVariables.food = 100;
        GlobalVariables.water = 100;
        GlobalVariables.godHappiness = 250;
        GlobalVariables.money = 20;
        GlobalVariables.foodPerSec = 0;
        GlobalVariables.waterPerSec = 0;
        GlobalVariables.moneyPerSec = 0;
        GlobalVariables.population = 0;
        GlobalVariables.currentSpawnRate = 1f;
        GlobalVariables.numberOfSacrificed = 0;
        GlobalVariables.upgrades.Clear();
        GlobalVariables.BossHealth = 100000;
        GlobalVariables.nukeCollided = false;
        GlobalVariables.HolyHit = false;
        GlobalVariables.wonGame = false;
        GlobalVariables.LostToFood = false;
        GlobalVariables.LostToWater = false;
        GlobalVariables.LostToGod = false;
        GlobalVariables.finalTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GlobalVariables.MouseIsDown = true;
            MouseIsDown = true;
            MouseDrag = true;
            Cursor.SetCursor(closeHand, new Vector2(16, 30), CursorMode.Auto);
        }
        if (Input.GetMouseButtonUp(0)) {
            GlobalVariables.MouseIsDown = false;
            MouseIsDown = false;
            Cursor.SetCursor(openHand, new Vector2(16, 30), CursorMode.Auto);
            for (int i = 0; i < duckList.Count; i++) {
            duckList[i].movingDuck = false;
            }
            duckList.Clear();
        }
    }

    private void FixedUpdate() {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = -2;
        transform.position = mouse;
        if (MouseIsDown && MouseDrag) {
            for (int i = 0; i < duckList.Count; i++) {
                duckList[i].movingDuck = true;
                duckList[i].MoveDuck();
            }
        }

        if (GlobalVariables.population >= 1000) {
            GlobalVariables.timeInAudio1 = audio.time;
            SceneManager.LoadScene("inbetween2");
        }
        else if(GlobalVariables.food < 0) {
            GlobalVariables.LostToFood = true;
            GlobalVariables.timeInAudio1 = audio.time;
            SceneManager.LoadScene("inbetween2");
        }
        else if(GlobalVariables.water < 0) {
            GlobalVariables.LostToWater = true;
            GlobalVariables.timeInAudio1 = audio.time;
            SceneManager.LoadScene("inbetween2");
        }
        else if (GlobalVariables.godHappiness < 0) {
            GlobalVariables.LostToGod = true;
            GlobalVariables.timeInAudio1 = audio.time;
            SceneManager.LoadScene("inbetween2");
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        Duck duck = other.GetComponent<Duck>();
        if (duck && MouseIsDown && duckList.Count < numberCanPickUp) {
            duck.CheckOffset();
            duckList.Add(duck);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Duck duck = other.GetComponent<Duck>();
        if (duck && !MouseDrag) {
            duckList.Remove(duck);
        }
    }
}
