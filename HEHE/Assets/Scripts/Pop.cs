using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    public Sprite newSprite;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public void OnButtonClick()
    {
        image.sprite = newSprite;

        Debug.Log("Click Test");
    }
}
