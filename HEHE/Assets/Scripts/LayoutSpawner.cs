using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutSpawner : MonoBehaviour
{
    public GameObject buttonPrefab;
    public int gridSize = 3;
    public int totalButtons;
    public Transform parentTransform; //������ ��ư�� ��ġ�� �θ� ��ü�� transform

    private void Start()
    {
        totalButtons = gridSize * gridSize;

    GridLayoutGroup gridLayoutGroup = parentTransform.GetComponent<GridLayoutGroup>();
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = gridSize;

        RectTransform rectTransform = parentTransform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 0);

        SpawnGridButtons();
    }

    void SpawnGridButtons()
    {

        for (int i=0; i<totalButtons; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, parentTransform);
            newButton.name = $"Button {i + 1}"; //$ : ���ڿ� ����
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (Transform child in parentTransform)
            {
                Destroy(child.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (parentTransform.childCount == 0)
            {
                SpawnGridButtons();
            }
        }
    }

}
