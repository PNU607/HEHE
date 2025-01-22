using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexManager : MonoBehaviour
{
    public static IndexManager Instance;
    public int count;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        if (count == 0)
        {
            LayoutSpawner.Instance.SpawnClear();
            LayoutSpawner.Instance.SpawnGridData();
        }
    }
}
