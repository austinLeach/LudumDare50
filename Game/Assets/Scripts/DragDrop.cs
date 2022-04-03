using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DragDrop : MonoBehaviour
{

    public BoxCollider2D Hitbox;
    public bool MouseIsDown = false;
    public bool MouseDrag = false;

    public int numberCanPickUp = 1;
    List<Duck> duckList = new List<Duck>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            MouseIsDown = true;
            MouseDrag = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            MouseIsDown = false;
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
            SceneManager.LoadScene("FinalBoss");
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
