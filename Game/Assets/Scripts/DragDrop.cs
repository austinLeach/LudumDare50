using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    public BoxCollider2D Hitbox;
    public BoxCollider2D BoxCollider;
    bool MouseIsDown = false;
    bool MouseDrag = false;

    List<Duck> duckList = new List<Duck>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate() {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = -1;
        transform.position = mouse;
        if (MouseIsDown && MouseDrag) {
            for (int i = 0; i < duckList.Count; i++) {
                duckList[i].MoveDuck();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {

        Duck duck = other.GetComponent<Duck>();
        if (duck && MouseIsDown && duckList.Count < 10) {
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

    private void OnMouseDown() {
        MouseIsDown = true;
    }

    private void OnMouseDrag() {
        MouseDrag = true;
    }

    private void OnMouseUp() {
        MouseIsDown = false;
        MouseDrag = false;
        duckList.Clear();
    }
}
