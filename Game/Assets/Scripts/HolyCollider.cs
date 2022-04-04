using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyCollider : MonoBehaviour
{
    public GameObject DuckDestroyer;
    public GameObject FinalButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "holyeggcollider") {
            GlobalVariables.HolyHit = true;
            Destroy(other.gameObject);
            DuckDestroyer.SetActive(true);
            FinalButton.SetActive(true);
        }
    }
}
