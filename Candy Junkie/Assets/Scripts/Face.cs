using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    //Params
    [SerializeField] Sprite RightFace;
    [SerializeField] Sprite LeftFace;
    [SerializeField] Color HitColor;
    [SerializeField] float HitEffectDuration;

    //Declare Vars
    Color startingColor;
    float TimeColorChanged;

    //Cached Values
    SpriteRenderer sprite;
    
    void Start()
    {
        //Get Cached Values
        sprite = GetComponent<SpriteRenderer>();

        //Set Defualt
        startingColor = sprite.material.color;
    }

    private void Update()
    {
        //Checks If Color Needs To Be Reverted
        if (sprite.color != startingColor && Time.time > TimeColorChanged + Time.time)
        {
            sprite.color = startingColor;
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
        sprite.material.color = HitColor;
    }
}
