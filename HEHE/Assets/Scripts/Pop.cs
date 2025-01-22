using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    public static Pop Instance;

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
    }
    public void OnButtonClick()
    {
        image.sprite = newSprite;

        Debug.Log("Click Test");

        ButtonIdentifier buttonIdentifier = this.GetComponent<ButtonIdentifier>();
        int buttonNum = buttonIdentifier.buttonIdentifierNum;

        Debug.Log($"{buttonNum}");

        int _TargetIndex = Index.Instance.targetIndex;

        if (buttonNum == _TargetIndex)
        {
            IndexManager.Instance.count--;
        }
    }
}
