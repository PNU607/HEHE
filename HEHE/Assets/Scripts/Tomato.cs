using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    public Transform transfrom;

    public IEnumerator VanishTomato()
    {
        Debug.Log("VanishTomato Start");

        float MoveDuration = 0.2f;
        float CoolTime = 0.7f;

        Vector2 currentPosition = transform.position;

        currentPosition.y += 10;
        transform.position = currentPosition;

        yield return new WaitForSeconds(MoveDuration);

        currentPosition.y -= 10;
        transform.position = currentPosition;

        yield return new WaitForSeconds(CoolTime);

        yield return null;
    }
}
