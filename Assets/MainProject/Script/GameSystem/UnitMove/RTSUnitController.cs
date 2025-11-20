using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RTSUnitController : MonoBehaviour
{
    [SerializeField]
    private UnitSpawner unitSpawner;
    private List<UnitController> selectedUnitList;
    public List<UnitController> UnitList { private set; get; }

    public UnitClassData[] unitClassData = new UnitClassData[5];

    private UnitController unitController;

    private void Awake()
    {
        //Count = unitSpawner.count;
        selectedUnitList = new List<UnitController>();
        UnitList = unitSpawner.SpawnUnits();
        unitController = GetComponent<UnitController>();
    }

    public void ClickSelectUnit(UnitController newUnit)
    {
        DeselcetAll();
        SelectUnit(newUnit);
    }

    public void ShiftClickSelecUnit(UnitController newUnit)
    {
        if (selectedUnitList.Contains(newUnit))
        {
            DeselectUnit(newUnit);
        }
        else
        {
            SelectUnit(newUnit);
        }
    }

    public void DragSelectUnit(UnitController newUnit)
    {
        //새로운 유닛을 선택했다면
        if (!selectedUnitList.Contains(newUnit))
        {
            SelectUnit(newUnit);
        }
    }

    public void MoveSelectedUnits(Vector3 end)
    {
        for(int i = 0; i < selectedUnitList.Count; i++)
        {
            selectedUnitList[i].MoveTo(end);
        }
    }

    public void DeselcetAll()
    {
        for(int i = 0; i < selectedUnitList.Count; i++)
        {
            selectedUnitList[i].DeselectUnit();
        }

        selectedUnitList.Clear();
    }

    private void SelectUnit(UnitController newUnit)
    {
        newUnit.SelectUnit();

        selectedUnitList.Add(newUnit);
    }

    private void DeselectUnit(UnitController newUnit)
    {
        newUnit.DeselectUnit();

        selectedUnitList.Remove(newUnit);
    }
    /*
    private void Update()
    {
        Count = unitSpawner.count;
    }//*/
}
