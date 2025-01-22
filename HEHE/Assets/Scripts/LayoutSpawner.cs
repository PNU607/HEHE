using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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

        SpawnGridData();
    }

    private void SpawnGridData()
    {
        gridData.Clear();

        for (int i=0; i<totalButtons; i++)
        {
            int randomIndex = Random.Range(0, buttonPrefabs.Count);
            gridData.Add(randomIndex);
        }
        gridCheck();
    }

    private void gridCheck()
    {
        bool isGrid = true;
        int ButotnPrefabsSize = buttonPrefabs.Count;
        for (int i=0; i< ButotnPrefabsSize; i++)
        {
            if (gridData.Count(x => x == i) == 0)
            {
                isGrid = false;
                Debug.Log("There exists duplication");
                break;
            }
        }

        if (isGrid)
        {
            SpawnGridButtons();
            Debug.Log("Grid Data: " + string.Join(", ", gridData));
        }
        else
        {
            SpawnGridData();
        }
    }

    private void SpawnGridButtons()
    {
        for (int i=0; i<totalButtons; i++)
        {
            int buttonNumber = gridData[i];
            GameObject selectedPrefab = buttonPrefabs[buttonNumber];
            GameObject newButton = Instantiate(selectedPrefab, parentTransform);
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
                SpawnGridData();
            }
        }
    }

}
