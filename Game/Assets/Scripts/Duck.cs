using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    Vector3 mouseOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
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
}
