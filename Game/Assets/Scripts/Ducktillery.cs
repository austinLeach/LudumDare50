using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducktillery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalVariables.upgrades.Count < 4) {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
