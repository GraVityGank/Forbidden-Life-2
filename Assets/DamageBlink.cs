using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlink : MonoBehaviour
{
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (startBlinking == true)
        {
            SpriteBlinkingEffect();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") //change according to your game
        {
            sprite.color = new Color(1, 0, 0, 1);
            startBlinking = true;
        }

    }
    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            sprite.color = new Color(1, 1, 1, 1);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true; //make changes
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false; //make changes
            }
        }
    }
}
