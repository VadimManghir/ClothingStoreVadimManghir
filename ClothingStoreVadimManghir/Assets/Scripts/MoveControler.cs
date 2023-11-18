using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stopers
{
    public enum kindOfStoper { Up, Down, Left, Right };
    public kindOfStoper Stoper;
    public bool ActiveStatus;
    [SerializeField]
    public GameObject ByuMenu;


}

public class MoveControler : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    float horizontalInput, verticalInput;
    public Stopers[] stopers = new Stopers[4];
    CustomAnimator animator;

    private void Start()
    {
        if(animator== null)
        {
            animator = GetComponent<CustomAnimator>();
        }
    }


    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 MoveDirection = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        MoveDirection = CheckStopers(MoveDirection);
        transform.Translate(MoveDirection);
        ChoseAnimations(MoveDirection);
    }

    private Vector3 CheckStopers(Vector3 direction)
    {
        foreach(Stopers stoper in stopers) 
        {
            if (stoper.ActiveStatus)
            {
                switch (stoper.Stoper)
                {
                    case Stopers.kindOfStoper.Up:
                        if (direction.y > 0) { direction.y = 0; }
                        break;
                    case Stopers.kindOfStoper.Down:
                        if (direction.y < 0) { direction.y = 0; }
                        break;
                    case Stopers.kindOfStoper.Right:
                        if (direction.x > 0) { direction.x = 0; }
                        break;
                    case Stopers.kindOfStoper.Left:
                        if (direction.x < 0) { direction.x = 0; }
                        break;
                }
            }
        }

        return direction;
    }

    private void ChoseAnimations(Vector3 direction)
    {
        if (direction.x != 0)
        {
            if (direction.x > 0)
            {
                animator.Play(CustomAnimator.AnimationsName.RightMove); 
            }
            else
            {
                animator.Play(CustomAnimator.AnimationsName.LeftMove);
            }
        }
        else if (direction.y != 0)
        {
            if (direction.y > 0)
            {
                animator.Play(CustomAnimator.AnimationsName.UpMove);
            }
            else
            {
                animator.Play(CustomAnimator.AnimationsName.DownMove);  
            }
        }
        else
        {
            switch (animator.curentAnimationName)
            {
                case CustomAnimator.AnimationsName.RightMove:
                    animator.Play(CustomAnimator.AnimationsName.Right);
                    break;
                case CustomAnimator.AnimationsName.LeftMove:
                    animator.Play(CustomAnimator.AnimationsName.Left);
                    break;
                case CustomAnimator.AnimationsName.UpMove:
                    animator.Play(CustomAnimator.AnimationsName.Up);
                    break;
                case CustomAnimator.AnimationsName.DownMove:
                    animator.Play(CustomAnimator.AnimationsName.Down);
                    break;
                default:
                    animator.Play(animator.curentAnimationName);
                    break;
            }


        }
    }

    
}
