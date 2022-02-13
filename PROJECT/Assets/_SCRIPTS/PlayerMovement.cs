using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;

    SpriteRenderer rend;
    PlayerCombat comb;

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
        comb = gameObject.GetComponent<PlayerCombat>();
    }

    void Update()
    {
        //vars to store the current input so we can change sprites
        float vert = Input.GetAxisRaw("Vertical");
        float horiz = Input.GetAxisRaw("Horizontal");

        selectSprite(horiz, vert);

        //movement handling
        float yDir = vert * Time.deltaTime * speed;
        float xDir = horiz * Time.deltaTime * speed;

        transform.Translate(new Vector3(xDir, yDir));
    }

    private void selectSprite(float inx, float iny)
    {
        //selects the sprite to use baised on the axis x and y
        if(inx != 0 && iny == 0)
        {
            if(inx < 0)
            {
                //Debug.Log("A Pressed");
                rend.sprite = playerLeft;
            }
            else if(inx > 0)
            {
                //Debug.Log("D Pressed");
                rend.sprite = playerRight;
            }
        }else if (inx == 0 && iny != 0)
        {
            if (iny > 0)
            {
                //Debug.Log("W Pressed");
                rend.sprite = playerUp;
            }
            else if (iny < 0)
            {
                //Debug.Log("S Pressed");
                rend.sprite = playerDown;
            }
        }
        else
        {
            if(inx < 0 && iny > 0)
            {
                //Debug.Log("top left");
                rend.sprite = playerTopLeft;
            }
            else if (inx > 0 && iny > 0)
            {
                //Debug.Log("top right");
                rend.sprite = playerTopRight;
            }
            else if (inx < 0 && iny < 0)
            {
                //Debug.Log("bottom left");
                rend.sprite = playerBottomLeft;
            }
            else if (inx > 0 && iny < 0)
            {
                //Debug.Log("bottom right");
                rend.sprite = playerBottomRight;
            }
        }
    }
}
