using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyGrenadeToss : MonoBehaviour
{
    bool shooting = true;
    float shootTimer = 20f;
    public GameObject holyGrenade;
    // Start is called before the first frame update
    void Start()
    {
       if (GlobalVariables.upgrades.Count > 4) {
           Destroy(this.gameObject);
       }
    }

    // Update is called once per frame
    void Update()
    {
        GlobalVariables.Timer(ref shooting, ref shootTimer);
        Shoot();
    }
    public void Shoot()
    {
        GameObject projectileObject;
        Projectiles projectile;
        if (shooting)
            return;
        Vector3 position = transform.position;
        position.z = -2;
        projectileObject = Instantiate(holyGrenade, position, Quaternion.identity);
        projectile = projectileObject.GetComponent<Projectiles>();
        shooting = true;
        shootTimer = 20000000f;
        Vector2 direction = new Vector2(-0.2f, .2f);
        projectile.Shoot(direction, 350); 
    }
}
