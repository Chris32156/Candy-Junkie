using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    //Params
    [SerializeField] Sprite RightFace;
    [SerializeField] Sprite LeftFace;

    //Cached Values
    SpriteRenderer sprite;

    void Start()
    {
        //Get Cached Values
        sprite = GetComponent<SpriteRenderer>();
    }

    public void flipFace(float x)
    {
        //Checks Which Direction Player Is Going Then Change Face
        if (x > 0)
        {
            sprite.sprite = RightFace;
        }
        else if (x < 0)
        {
            sprite.sprite = LeftFace;
        }
    }
}
