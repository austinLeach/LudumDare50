using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    Sprite newSprite;
    Rigidbody2D rigidBody2D;
    
    public float velocityY;
    public SpriteRenderer spriteRenderer;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    int spriteNum;
      
    // Start is called before the first frame update
    void Start()
    {
        ChangeSprite();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocityX;
        velocityX = Random.Range(-0.5f, -2.5f);
        


        Vector2 position = transform.position;
        position.x = position.x + velocityX * Time.deltaTime;
        position.y = position.y + velocityY * Time.deltaTime;
        transform.position = position;
    }

    void ChangeSprite()
    {
       spriteNum = Random.Range(1, 6);
        switch (spriteNum)
        {
            case 1: 
                newSprite = Sprite1;
                break;
            case 2:
                newSprite = Sprite2;
                break;
            case 3:
                newSprite = Sprite3;
                break;
            case 4:
                newSprite = Sprite4;
                break;
            case 5:
                newSprite = Sprite5;
                break;
            default:
                break;
        }

        spriteRenderer.sprite = newSprite;
    }

}
