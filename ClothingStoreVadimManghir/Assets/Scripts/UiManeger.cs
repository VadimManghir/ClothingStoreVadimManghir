using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UiManeger : MonoBehaviour
{
    public static Action<bool> SetActiveFButton;
    public static Action OpenAction;
    [SerializeField]
    private GameObject fButton;

    private void Start()
    {
        
        fButton.SetActive(false);
        SetActiveFButton += setActiveFButton;
    }

    private void Update()
    {
        if(fButton.activeSelf && Input.GetKey(KeyCode.F))
        {
            OpenAction?.Invoke();
            fButton.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        SetActiveFButton -= setActiveFButton;
    }

    private void setActiveFButton(bool ActiveStatus)
    {
        fButton.SetActive(ActiveStatus);
    }
}
