using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHitbox : MonoBehaviour
{

    public BoxCollider2D Hitbox;
    public BoxCollider2D BoxCollider;
    bool MouseIsDown = false;
    bool MouseDrag = false;

    List<DragDrop> duckList = new List<DragDrop>();

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

        DragDrop duck = other.GetComponent<DragDrop>();
        if (duck && MouseIsDown && duckList.Count < 10) {
            duck.CheckOffset();
            duckList.Add(duck);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
         DragDrop duck = other.GetComponent<DragDrop>();
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
