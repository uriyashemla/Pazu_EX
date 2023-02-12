using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair : MonoBehaviour
{
    [SerializeField] private Sprite [] cutHairSprite;
    private int i;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        i = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Scissors"&&i<5)
        {
            spriteRenderer.sprite = cutHairSprite[++i];
        }
        if (other.gameObject.tag == "HairGrow" && i >0)
        {
            spriteRenderer.sprite = cutHairSprite[--i];
        }
    }
}
