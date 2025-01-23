using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Index : MonoBehaviour
{
    public static Index Instance;

    public int targetIndex;
    public TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
