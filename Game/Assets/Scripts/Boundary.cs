using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public DragDrop dragDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D (Collider2D other) {
        Duck duck = other.GetComponent<Duck>();
        if (duck && !dragDrop.MouseIsDown) {
            Destroy(other.gameObject);
        }
    }
}
