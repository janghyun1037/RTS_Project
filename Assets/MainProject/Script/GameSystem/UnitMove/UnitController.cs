using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField] private GameObject unitMarker;
    public NavMeshAgent navMeshAgent;

    [Header("직업 데이터")]
    public UnitClassData unitData;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // 소환 후 초기화 (스탯 반영)
    public void Initialize(UnitClassData data)
    {
        unitData = data;

        // 속도 적용
        navMeshAgent.speed = unitData.Speed;

        // 추후 필요 시 체력, 공격력 등 다른 스탯도 여기서 적용 가능
    }

    public void SelectUnit() => unitMarker.SetActive(true);
    public void DeselectUnit() => unitMarker?.SetActive(false);
    public void MoveTo(Vector3 end) => navMeshAgent.SetDestination(end);
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class UnitController : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject unitMarker;
//    public NavMeshAgent navMeshAgent;
//    private UnitClassData unitClassData;

//    private void Awake()
//    {
//        navMeshAgent = GetComponent<NavMeshAgent>();

//        if (unitClassData != null)
//        {
//            navMeshAgent.speed = unitClassData.Speed;
//        }
//    }

//    public void SelectUnit()
//    {
//        unitMarker.SetActive(true);
//    }

//    public void DeselectUnit()
//    {
//        unitMarker?.SetActive(false);
//    }

//    public void MoveTo(Vector3 end)
//    {
//        navMeshAgent.SetDestination(end);
//    }
//}
