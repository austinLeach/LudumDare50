using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    bool shooting = true;
    float shootTimer = 2f;
    public GameObject eggProjectile;
    public GameObject bulletProjectile;
    public GameObject artileryProjectile;
    public bool isArtilery = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!isArtilery) {
            shootTimer = Random.Range(0f, 5f);
        }
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
            if (!isArtilery) {
                int random = Random.Range(0, 2);
                Vector3 position = transform.position;
                position.z = -2;
                if (random == 0) {
                    Debug.Log("First");
                    projectileObject = Instantiate(eggProjectile, position, Quaternion.identity);
                }
                else {
                    Debug.Log("else");
                    projectileObject = Instantiate(bulletProjectile, position, Quaternion.identity);
                }
            } else {
                Vector3 position = transform.position;
                position.z = -2;
                projectileObject = Instantiate(artileryProjectile, position, Quaternion.identity);
            }
        }
        projectile = projectileObject.GetComponent<Projectiles>();
        shooting = true;
        if(!isArtilery) {
            shootTimer = Random.Range(2f, 5f);
            Vector2 direction = new Vector2(.5f, .3f);
            projectile.Shoot(direction);  //second number is speed of projectile
        } else {
            shootTimer = 2f;
            Vector2 direction = new Vector2(.5f, .19f);
            projectile.Shoot(direction); 
        }
    }
}
