using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOptimalPath : MonoBehaviour,
    IEvaluateHex
{
    public bool EvaluateHex(BattleHex evaluatedHex)
    {
        return evaluatedHex.isNeighbourgHex;
    }
}
