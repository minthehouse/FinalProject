﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;


    private void Start()
    {
    
        defaultScale = buttonScale.localScale;
    
    }



    bool isSound;

    public void OnBtnClick()
    {
        switch(currentType)
        {
            case BTNType.New:
                Debug.Log("New Game");
                break;
            case BTNType.Continue:
                Debug.Log("resume game");
                break;
            case BTNType.Sound:
                if(isSound)
                {
                    isSound =! isSound;
                    Debug.Log("Sound off");
                }
                else
                {
                    Debug.Log("Sound On");
                }
                isSound = !isSound;
                break;
            case BTNType.Option:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                break;
        }

    }


    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

}