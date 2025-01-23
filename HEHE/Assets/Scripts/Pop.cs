using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    public static Pop Instance;

    public bool isButtonClicked;

    public Sprite newSprite;
    private Image image;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        image = GetComponent<Image>();
        isButtonClicked = false;
    }
    public void OnButtonClick()
    {
        ButtonIdentifier buttonIdentifier = this.GetComponent<ButtonIdentifier>();
        int buttonNum = buttonIdentifier.buttonIdentifierNum;

        //Debug.Log($"{buttonNum}");

        int _TargetIndex = Index.Instance.targetIndex;

        if ((buttonNum == _TargetIndex) && (isButtonClicked == false))
        {
            Debug.Log("Good!");

            image.sprite = newSprite;

            IndexManager.Instance.count--;

            isButtonClicked = true;
        }

        else if ((buttonNum != _TargetIndex) || (isButtonClicked != false))
        {
            Debug.Log("Wrong!");
        }
    }
}
