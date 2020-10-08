using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsForFlying :
    IAdjacentFinder
{
    IEvaluateHex checkHex = new IsNewHex();

    public void GetAdjacentHexesExtended(BattleHex initialHex)
    {
        List<BattleHex> neighboursToCkeck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);

        foreach (BattleHex hex in neighboursToCkeck)
        {
            hex.isNeighbourgHex = true;
            hex.distanceText.SetDistanceFromStartingHex(initialHex);
            hex.MakeAvailable();
        }
    }
}
