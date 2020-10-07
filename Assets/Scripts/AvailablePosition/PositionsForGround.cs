using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsForGround : MonoBehaviour,
    IAdjacentFinder
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetAdjacentHexesExtended(BattleHex initialHex)
    {
        List<BattleHex> neighboursToCkeck = NeighboursFinder.GetAdjacentHexes(initialHex);

        foreach (BattleHex hex in neighboursToCkeck)
        {
            hex.isNeighbourgHex = true;
            hex.distanceText.SetDistanceFromStartingHex(initialHex);
        }
    }
}
