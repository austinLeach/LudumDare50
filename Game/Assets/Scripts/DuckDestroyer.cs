using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject allDucks;
    public GameObject Ducktillery;
    public GameObject shooters;
    void Start()
    {
        Destroy(allDucks);
        Destroy(Ducktillery);
        Destroy(shooters);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
