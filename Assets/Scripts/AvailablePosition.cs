using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailablePosition : MonoBehaviour
{
    private int step;
    List<BattleHex> initialHexes = new List<BattleHex>();
    PositionsForFlying AdjFinder = new PositionsForFlying();

    public void GetAvailablePositions(BattleHex startingHex, int stepsLimit)
    {

        AdjFinder.GetAdjacentHexesExtended(startingHex);

        for (step = 2; step <= stepsLimit; step++)
        {
            initialHexes = GetNewInitialHexes();
            foreach (BattleHex hex in initialHexes)
            {
                AdjFinder.GetAdjacentHexesExtended(hex);
                hex.isIncluded = true;
            }
        }
    }
    internal List<BattleHex> GetNewInitialHexes()
    {
        initialHexes.Clear();
        foreach (BattleHex hex in FieldManager.allHexesArray)
        {
            if (hex.isNeighbourgHex & !hex.isIncluded)
            {
                initialHexes.Add(hex);
            }
        }
        return initialHexes;
    }
}
