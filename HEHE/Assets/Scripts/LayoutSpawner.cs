using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LayoutSpawner : MonoBehaviour
{
    public static LayoutSpawner Instance;

    public List<GameObject> buttonPrefabs;
    public int gridSize = 3;
    public int randomgridData;
    private int totalButtons;
    private List<int> gridData;

    public Transform parentTransform;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        totalButtons = gridSize * gridSize;
        randomgridData = 0;
        gridData = new List<int>();

        GridLayoutGroup gridLayoutGroup = parentTransform.GetComponent<GridLayoutGroup>();
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = gridSize;

        RectTransform rectTransform = parentTransform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 0);

        SpawnGridData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnClear();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (parentTransform.childCount == 0)
            {
                SpawnGridData();
            }
        }
    }

    public void SpawnGridData()
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
        int ButtonPrefabsSize = buttonPrefabs.Count;
        for (int i=0; i< ButtonPrefabsSize; i++)
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

            ButtonIdentifier buttonIdentifier = newButton.GetComponent<ButtonIdentifier>();
            buttonIdentifier.buttonIdentifierNum = buttonNumber;
        }

        SetIndex();

    }

    public void SpawnClear()
    {
        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }
    }

    private void SetIndex()
    {
        randomgridData = Random.Range(0, buttonPrefabs.Count);
        int CountIndex = gridData.Count(x => x == randomgridData);
        IndexManager.Instance.count = CountIndex;
        Debug.Log($"Count : {CountIndex}");
        string indexColor = "";
        if (randomgridData == 0) indexColor = "Red";
        else if (randomgridData == 1) indexColor = "Green";
        else if (randomgridData == 2) indexColor = "Blue";
        Index.Instance.textMeshPro.text = $"Index : {indexColor}";
        Index.Instance.targetIndex = randomgridData;
    }
}

