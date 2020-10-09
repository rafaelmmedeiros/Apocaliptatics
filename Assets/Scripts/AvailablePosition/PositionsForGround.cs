using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsForGround : MonoBehaviour,
    IAdjacentFinder
{
    IEvaluateHex checkHex = new IsNewGround();

    public void GetAdjacentHexesExtended(BattleHex initialHex)
    {
        List<BattleHex> neighboursToCkeck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);

        foreach (BattleHex hex in neighboursToCkeck)
        {
            if (hex.distanceText.EvaluateDistanceForGround(initialHex))
            {
                hex.isNeighbourgHex = true;
                hex.distanceText.SetDistanceFofGroundUnit(initialHex);
                hex.MakeAvailable();
            }
        }
    }
}
