using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitSpawnData
{
    public GameObject prefab;      // 소환할 프리팹
    public UnitClassData unitData; // 직업 데이터 (ScriptableObject)
    public float weight = 1f;      // 소환 확률 가중치
}

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private int maxUnitCount = 5;
    [SerializeField] private List<UnitSpawnData> unitSpawnDataList;

    private Vector2 maxSzie = new Vector2(22, 22);
    private Vector2 minSize = new Vector2(-22, -22);

    public List<UnitController> SpawnUnits()
    {
        List<UnitController> unitList = new List<UnitController>(maxUnitCount);

        for (int i = 0; i < maxUnitCount; ++i)
        {
            UnitSpawnData spawnData = GetWeightedRandomData();

            Vector3 position = new Vector3(
                Random.Range(minSize.x, maxSzie.x),
                1,
                Random.Range(minSize.y, maxSzie.y)
            );

            GameObject clone = Instantiate(spawnData.prefab, position, Quaternion.identity);
            UnitController unit = clone.GetComponent<UnitController>();

            // 여기서 직업 데이터 기반 초기화
            unit.Initialize(spawnData.unitData);

            unitList.Add(unit);
        }

        return unitList;
    }

    private UnitSpawnData GetWeightedRandomData()
    {
        float totalWeight = 0f;
        foreach (var data in unitSpawnDataList)
            totalWeight += data.weight;

        float randomValue = Random.Range(0f, totalWeight);
        float cumulative = 0f;

        foreach (var data in unitSpawnDataList)
        {
            cumulative += data.weight;
            if (randomValue < cumulative)
                return data;
        }

        // fallback: 마지막 요소
        return unitSpawnDataList[unitSpawnDataList.Count - 1];
    }
}
