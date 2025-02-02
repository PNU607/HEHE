using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    public bool isButtonClicked;

    public Sprite newSprite;
    private Image image;

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

            isButtonClicked = true;

            StartCoroutine(VanishUpdate());

            //Destroy(gameObject);
        }

        else if ((buttonNum != _TargetIndex) || (isButtonClicked != false))
        {
            Debug.Log("Wrong!");
        }
    }

    public IEnumerator VanishUpdate()
    {
        Tomato tomato = this.GetComponent<Tomato>();
        yield return StartCoroutine(tomato.VanishTomato());
        IndexManager.Instance.count--;
    }
}
