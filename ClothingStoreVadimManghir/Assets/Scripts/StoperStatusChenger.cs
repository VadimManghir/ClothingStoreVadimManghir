using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoperStatusChenger : MonoBehaviour
{
    public Stopers.kindOfStoper kindOfStoper;
    MoveControler moveControler;
    int numberOfStoper;

    private void Start()
    {
        moveControler = transform.parent.GetComponent<MoveControler>();

        for(int i=0;i< moveControler.stopers.Length; i++)
        {
            if (moveControler.stopers[i].Stoper == kindOfStoper)
            {
                numberOfStoper = i;
                return;
            }
        }
    }

    private void CheckColisionTag(string colliisionTag, bool activStatus)
    {
        if (colliisionTag == "HardObject")
        {
            moveControler.stopers[numberOfStoper].ActiveStatus = activStatus;
        }
        else if (colliisionTag == "InteractiveObject")
        {
           
            UiManeger.SetActiveFButton?.Invoke(activStatus);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckColisionTag(collision.gameObject.tag, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckColisionTag(collision.gameObject.tag, false);
    }
}
