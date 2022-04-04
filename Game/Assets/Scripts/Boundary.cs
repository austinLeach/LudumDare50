using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    // public DragDrop dragDrop;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other) {
        Duck duck = other.GetComponent<Duck>();
        if (duck && duck.movingDuck == false) {
            duck.DestroyDuck();
        } 
    }
}
