using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public enum KindOfItem { Hat, Armor }
    public KindOfItem kindOfItem;
    public AnimationsSprite[] spritesForAnimation;
    [SerializeField]
    private SpriteRenderer spriteOnStand;
    [SerializeField]
    private bool ActiveStatus;


    private void Start()
    {
        UiManeger.OpenAction += EquipPlayer;
    }

    private void OnDestroy()
    {
        UiManeger.OpenAction -= EquipPlayer;
    }

    public void EquipPlayer()
    {
        if (!ActiveStatus)
        {
            return;
        }

        CustomAnimator customAnimator = FindObjectOfType<CustomAnimator>();

        AnimationsSprite[] temporarryArray = spritesForAnimation;

        switch (kindOfItem)
        {
            case KindOfItem.Hat:
                temporarryArray = customAnimator.Hat;
                customAnimator.Hat = spritesForAnimation;
                break;
            case KindOfItem.Armor:
                temporarryArray = customAnimator.Armor;
                customAnimator.Armor = spritesForAnimation;
                break;
        }

        spritesForAnimation = temporarryArray;

        foreach(AnimationsSprite animationssprite in spritesForAnimation) 
        {
            if(animationssprite.spriteName == AnimationsSprite.SpriteName.downStay)
            {
                spriteOnStand.sprite = animationssprite.sprite;
                break;
            }
        }

        customAnimator.ChengeSprite(AnimationsSprite.SpriteName.upStay);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stoper")
        {
            ActiveStatus = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stoper")
        {
            ActiveStatus = false;
        }
    }
}
