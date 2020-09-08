using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    //Params
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

    public void GotHit()
    {
        //Update Vars
        TimeColorChanged = Time.time;
        sprite.color = Color.red;
    }
}
