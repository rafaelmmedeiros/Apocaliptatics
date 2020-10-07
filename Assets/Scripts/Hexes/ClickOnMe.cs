using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnMe : MonoBehaviour, IPointerClickHandler
{
    BattleHex hex;
    public bool isTargetHex = false;
    public FieldManager fieldManager;

    void Awake()
    {
        hex = GetComponent<BattleHex>();
        fieldManager = FindObjectOfType<FieldManager>();
    }

    void Update()
    {

    }

    // INTERFACE IMPLEMENTATIONS
    public void OnPointerClick(PointerEventData eventData)
    {
        ClearPreviousSelectionOfTargetHex();
        if (hex.isNeighbourgHex)
        {
            hex.MakeTargetToMove();
            BattleController.currentAtacker.GetComponent<OptimalPath>().MatchPath();
        }
    }

    public void ClearPreviousSelectionOfTargetHex()
    {
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.clickOnMe.isTargetHex == true)
            {
                hex.GetComponent<ClickOnMe>().isTargetHex = false;
                hex.MakeAvailable();
            }

        }
    }
}
