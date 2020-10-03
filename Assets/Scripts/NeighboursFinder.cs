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

        allNeighbours.Add(allHexesArray[initialX + 1, initialY]);
        allNeighbours.Add(allHexesArray[initialX - 1, initialY]);
        allNeighbours.Add(allHexesArray[initialX, initialY + 1]);
        allNeighbours.Add(allHexesArray[initialX, initialY - 1]);
        allNeighbours.Add(allHexesArray[initialX + 1, initialY + 1]);
        allNeighbours.Add(allHexesArray[initialX - 1, initialY - 1]);

        foreach (BattleHex hex in allNeighbours)
        {
            hex.landscape.color = new Color32(255, 180, 200, 255);
        }
    }
}