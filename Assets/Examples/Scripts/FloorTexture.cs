using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTexture : MonoBehaviour
{
    public bool fliped;
    public SpriteRenderer spriteRen;
    public float flipedNum;
    public float speed = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        flipedNum = 0;
        fliped = false;
        spriteRen = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flipedNum == 1)
        {
            fliped = false;
        }

        if (flipedNum == 2)
        {
            fliped = true;
        }

        if (flipedNum >= 3)
        {
            flipedNum = 0;
        }
        
        if (fliped == true)
        {
            spriteRen.flipX = true;
        }

        if (fliped == false)
        {
            spriteRen.flipX = false;
        }
        flipedNum += speed;
    }
}
