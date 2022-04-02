using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiksMouse : MonoBehaviour
{
    public int money = 0;
    public Collider2D myObject;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.collider.name == "Money")
                {
                    Debug.Log("Youre on the money");
                    money++;
                }
                else if(hit.collider.name == "Sacrifice")
                {
                    Debug.Log("You tryna to sacrifice some fools?");
                    if(myObject != null)
                    {
                        Destroy(myObject.gameObject);
                    }
                }
            }
        }
    }
}
