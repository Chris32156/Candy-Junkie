using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    //Params
    [SerializeField] Sprite RightFace;
    [SerializeField] Sprite LeftFace;
    [SerializeField] float HitEffectDuration;

    //Declare Vars
    Color startingColor;
    float TimeColorChanged = 0;

    //Cached Values
    SpriteRenderer sprite;
    
    void Start()
    {
        //Get Cached Values
        sprite = GetComponent<SpriteRenderer>();

        //Set Defualt
        startingColor = sprite.color;
    }

    private void Update()
    {
        //Checks If Color Needs To Be Reverted
        if (Time.time > HitEffectDuration + TimeColorChanged)
        {
            sprite.color = Color.white;
        }
    }

    public void flipFace(float x)
    {
        //Checks Which Direction Player Is Going Then Changes The Face Sprite
        if (x > 0)
        {
            sprite.sprite = RightFace;
        }
        else if (x < 0)
        {
            sprite.sprite = LeftFace;
        }
    }

    public void GotHit()
    {
        //Update Vars
        TimeColorChanged = Time.time;
        sprite.color = Color.red;
    }
}
