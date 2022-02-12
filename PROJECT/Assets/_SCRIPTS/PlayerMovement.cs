using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;

    SpriteRenderer rend;

    //textures for the directions to switch on move
    [SerializeField]
    Sprite playerLeft;
    [SerializeField]
    Sprite playerMid;
    [SerializeField]
    Sprite playerRight;
    [SerializeField]
    Sprite playerUp;
    [SerializeField]
    Sprite playerDown;

    [SerializeField]
    Sprite playerTopLeft;
    [SerializeField]
    Sprite playerTopRight;
    [SerializeField]
    Sprite playerBottomLeft;
    [SerializeField]
    Sprite playerBottomRight;

    private void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //vars to store the current input so we can change sprites
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");

        selectSprite(horiz, vert);

        //movement handling
        float yDir = vert * Time.deltaTime * speed;
        float xDir = horiz * Time.deltaTime * speed;

        transform.Translate(new Vector3(xDir, yDir));
    }

    private void selectSprite(float inx, float iny)
    {
        if(inx != 0 && iny == 0)
        {
            if(inx == -1)
            {
                Debug.Log("A Pressed");
                rend.sprite = playerLeft;
            }
            else if(inx == 1)
            {
                Debug.Log("D Pressed");
                rend.sprite = playerRight;
            }
        }else if (inx == 0 && iny != 0)
        {
            if (iny == 1)
            {
                Debug.Log("W Pressed");
            }
            else if (iny == -1)
            {
                Debug.Log("S Pressed");
                rend.sprite = playerDown;
            }
        }
        else
        {
            if(inx > 0 & iny < 0)
            {
                Debug.Log("top left");
            }
            else if (inx > 0 & iny > 0)
            {
                Debug.Log("top right");
            }
            else if (inx < 0 & iny < 0)
            {
                Debug.Log("bottom left");
            }
            else if (inx < 0 & iny > 0)
            {
                Debug.Log("bottom right");
            }
        }
    }
}
