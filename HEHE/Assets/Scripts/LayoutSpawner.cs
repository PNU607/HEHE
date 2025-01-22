using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutSpawner : MonoBehaviour
{
    public List<GameObject> buttonPrefabs;
    public int gridSize = 3;
    private int totalButtons;
    private List<int> gridData;

    public Transform parentTransform;

    private void Start()
    {
        totalButtons = gridSize * gridSize;
        gridData = new List<int>();

        GridLayoutGroup gridLayoutGroup = parentTransform.GetComponent<GridLayoutGroup>();
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = gridSize;

        RectTransform rectTransform = parentTransform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 0);

        SpawnGridButtons();
    }

    void SpawnGridButtons()
    {
        gridData.Clear();

        for (int i=0; i<totalButtons; i++)
        {
            int randomIndex = Random.Range(0, buttonPrefabs.Count);
            GameObject selectedPrefab = buttonPrefabs[randomIndex];

            GameObject newButton = Instantiate(selectedPrefab, parentTransform);

            gridData.Add(randomIndex);
        }

        Debug.Log("Grid Data: " + string.Join(", ", gridData));
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
