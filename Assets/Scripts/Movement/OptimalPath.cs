using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimalPath : MonoBehaviour
{
    public static List<BattleHex> optimalPath = new List<BattleHex>();
    public static BattleHex nextStep;
    BattleHex targetHex;
    IAdjacentFinder AdjacentOption = new PosForPath();

    internal void MatchPath()
    {
        targetHex = BattleController.targetToMove;
        optimalPath.Add(targetHex);

        int steps = targetHex.distanceText.distanceFromStartingPosition;
        for (int i = steps; i > 1;)
        {
            AdjacentOption.GetAdjacentHexesExtended(targetHex);
            targetHex = nextStep;
            i -= nextStep.distanceText.MakeMePartOfOptimalPath();
        }
    }
}
