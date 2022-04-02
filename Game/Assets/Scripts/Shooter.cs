using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    bool shooting = true;
    float shootTimer;
    public GameObject eggProjectile;
    public GameObject bulletProjectile;
    // Start is called before the first frame update
    void Start()
    {
        shootTimer = Random.Range(0f, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GlobalVariables.Timer(ref shooting, ref shootTimer);
        Shoot();
    }
    public void Shoot()
    {
        GameObject projectileObject;
        Projectiles projectile;
        if (shooting)
        {
            return;
        }
        else
        {
            int random = Random.Range(0, 2);
            Vector3 position = transform.position;
            position.z = -2;
            if (random == 0) {
                projectileObject = Instantiate(eggProjectile, position, Quaternion.identity);
            }
            else {
                projectileObject = Instantiate(bulletProjectile, position, Quaternion.identity);
            }
        }
        projectile = projectileObject.GetComponent<Projectiles>();
        Vector2 direction = new Vector2(.5f, .3f);
        projectile.Shoot(direction);  //second number is speed of projectile
        shooting = true;
        shootTimer = Random.Range(2f, 5f);
    }
}
