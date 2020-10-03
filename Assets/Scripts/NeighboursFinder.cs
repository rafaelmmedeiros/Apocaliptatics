using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighboursFinder : MonoBehaviour
{
    private BattleHex startingHex;
    List<BattleHex> allNeighbours = new List<BattleHex>();
    private FieldManager fieldManager;
    BattleHex[,] allHexesArray;

    void Start()
    {
        fieldManager = FindObjectOfType<FieldManager>();
        allHexesArray = fieldManager.allHexesArray;
        GetAdjacentHexes();
    }

    public void GetAdjacentHexes()
    {
        startingHex = GetComponentInParent<BattleHex>();

        int initialX = startingHex.horizontalCoordinate - 1;
        int initialY = startingHex.verticalCoordinate - 1;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x + y != 0
                    && allHexesArray[initialX + x, initialY + y].battleHexState == HexState.active)
                {
                    allNeighbours.Add(allHexesArray[initialX + x, initialY + y]);
                }
            }
        }

        foreach (BattleHex hex in allNeighbours)
        {
            hex.landscape.color = new Color32(180, 180, 200, 255);
        }
    }
}