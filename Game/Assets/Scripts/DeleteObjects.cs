using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjects : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       
        BoxCollider2D boxCollider = new BoxCollider2D();   

    }

    // Update is called once per frame
    void Update()
    {
    

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

}
