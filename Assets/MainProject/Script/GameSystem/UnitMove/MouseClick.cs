using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerUnit;
    [SerializeField]
    private LayerMask layerGround;

    public bool isUnits = false;

    private Camera mainCamera;
    private RTSUnitController rtsUnitController;

    private void Awake()
    {
        mainCamera = Camera.main;
        rtsUnitController = GetComponent<RTSUnitController>();
    }

    private void Update()
    {
        //마우스 왼쪽 클릭으로 유닛 선택 or 해제
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray  ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            //광선에 부딫히는 오브젝트가 있을때 (=유닛을 클릭 하였을때)
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerUnit))
            {
                isUnits = true;

                if (hit.transform.GetComponent<UnitController>() == null) return;

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rtsUnitController.ShiftClickSelecUnit(hit.transform.GetComponent<UnitController>());
                }
                else
                {
                    rtsUnitController.ClickSelectUnit(hit.transform.GetComponent<UnitController>());
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            //유닛 오브젝트(layerUnit)을 클릭 했을때
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
            {
                rtsUnitController.MoveSelectedUnits(hit.point);
                isUnits = false;
            }
        }
        
        //광선에 부딫히는 오브젝트가 없을 때
        else
        {
            if (!isUnits)
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    rtsUnitController.DeselcetAll();
                }
            }
        }
    }
}
