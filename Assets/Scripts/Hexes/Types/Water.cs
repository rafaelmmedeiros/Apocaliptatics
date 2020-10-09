using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : BattleHex
{
    public override void MakeTargetToMove()
    {
        clickOnMe.ClearPreviousSelectionOfTargetHex();
    }

    public override void MakeAvailable()
    {
        currentState.color = new Color32(255, 255, 255, 0);
    }

    public override bool AvailableToGround()
    {
        return false;
    }
}
