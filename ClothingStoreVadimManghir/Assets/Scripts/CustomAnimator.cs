using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationsSprite
{
    public enum SpriteName
    {
        upStay, upLeftLeg, upRightLeg, downStay, downLeftLeg, downRightLeg, rightStay, rightLeftLeg, rightRightLeg,
        leftStay, leftLeftLeg, leftRightLeg
    }

    public SpriteName spriteName;
    public Sprite sprite;
}

public class CustomAnimator : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer PlayerSpriteRenderer, HeatSpriteRenderer, ArmorSpriteRenderer;

    public AnimationsSprite[] Player, Hat, Armor;

    public enum AnimationsName
    {
        Up, UpMove, Down, DownMove, Right, RightMove, Left, LeftMove,
    }

    public AnimationsName curentAnimationName;

    private float drag = 0.2f;

    public void Play(AnimationsName animationName)
    {
        if (animationName == curentAnimationName)
        {
            return;
        }
        else
        {
            StopAllCoroutines();
            curentAnimationName = animationName;
        }

        switch (animationName)
        {
            case AnimationsName.UpMove:
                StartCoroutine(UpMove());
                break;
            case AnimationsName.Up:
                Up();
                break;
            case AnimationsName.DownMove:
                StartCoroutine(DownMove());
                break;
            case AnimationsName.Down:
                Down();
                break;
            case AnimationsName.LeftMove:
                StartCoroutine(LeftMove());
                break;
            case AnimationsName.Left:
                Left();
                break;
            case AnimationsName.RightMove:
                StartCoroutine(RightMove());
                break;
            case AnimationsName.Right:
                Right();
                break;
        }
    }

    public void ChengeSprite(AnimationsSprite.SpriteName nextSprite)
    {
        foreach( var animationsSprite in Player )
        {
            if(animationsSprite.spriteName == nextSprite)
            {
                PlayerSpriteRenderer.sprite = animationsSprite.sprite;
                break;
            }
        }

        if(Hat != null)
        {
            foreach (var animationsSprite in Hat)
            {
                if (animationsSprite.spriteName == nextSprite)
                {
                    HeatSpriteRenderer.sprite = animationsSprite.sprite;
                    break;
                }
            }
        }

        if (Armor != null)
        {
            foreach (var animationsSprite in Armor)
            {
                if (animationsSprite.spriteName == nextSprite)
                {
                    ArmorSpriteRenderer.sprite = animationsSprite.sprite;
                    break;
                }
            }
        }

    }

    IEnumerator UpMove()
    {
        while (true)
        {
            ChengeSprite(AnimationsSprite.SpriteName.upLeftLeg);   

            yield return new WaitForSeconds(drag);

            ChengeSprite(AnimationsSprite.SpriteName.upRightLeg);

            yield return new WaitForSeconds(drag);
        }
    }

    void Up()
    {
        ChengeSprite(AnimationsSprite.SpriteName.upStay);
    }

    IEnumerator DownMove()
    {
        while (true)
        {
            ChengeSprite(AnimationsSprite.SpriteName.downLeftLeg);

            yield return new WaitForSeconds(drag);

            ChengeSprite(AnimationsSprite.SpriteName.downRightLeg);

            yield return new WaitForSeconds(drag);
        }
    }

    void Down()
    {
        ChengeSprite(AnimationsSprite.SpriteName.downStay);
    }

    IEnumerator LeftMove()
    {
        while (true)
        {
            ChengeSprite(AnimationsSprite.SpriteName.leftLeftLeg);

            yield return new WaitForSeconds(drag);

            ChengeSprite(AnimationsSprite.SpriteName.leftStay);

            yield return new WaitForSeconds(drag);

            ChengeSprite(AnimationsSprite.SpriteName.leftRightLeg);

            yield return new WaitForSeconds(drag);

            ChengeSprite(AnimationsSprite.SpriteName.leftStay);

            yield return new WaitForSeconds(drag);
        }
    }

    void Left()
    {
        ChengeSprite(AnimationsSprite.SpriteName.leftStay);
    }

    IEnumerator RightMove()
    {
        while (true)
        {
            ChengeSprite(AnimationsSprite.SpriteName.rightLeftLeg);

            yield return new WaitForSeconds(drag);

            ChengeSprite(AnimationsSprite.SpriteName.rightStay);

            yield return new WaitForSeconds(drag);

            ChengeSprite(AnimationsSprite.SpriteName.rightRightLeg);

            yield return new WaitForSeconds(drag);

            ChengeSprite(AnimationsSprite.SpriteName.rightStay);

            yield return new WaitForSeconds(drag);
        }
    }

    void Right()
    {
        ChengeSprite(AnimationsSprite.SpriteName.rightStay);
    }
}
