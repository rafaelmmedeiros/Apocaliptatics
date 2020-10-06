using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public RowManager[] allRows;
    static public BattleHex[,] allHexesArray;
    int allRowsLenght;
    public static List<BattleHex> activeHexList = new List<BattleHex>();

    //  Sprites for 
    public Sprite availableAsTarget;
    public Sprite notAvailable;
    public Sprite availableToMove;

    void Awake()
    {
        allRows = GetComponentsInChildren<RowManager>();
        allRowsLenght = allRows.Length;

        for (int i = 0; i < allRowsLenght; i++)
        {
            allRows[i].allHexesInRow = allRows[i].GetComponentsInChildren<BattleHex>();
        }

        CreateAllHexesArray();
        IdentifyHexes();
    }

    private void Start()
    {
        IdentifyHexes();
        AvailablePosition hero = FindObjectOfType<AvailablePosition>();
        IAdjacentFinder adjFinder = new PositionsForFlying();
        hero.GetAvailablePositions(hero.GetComponentInParent<BattleHex>(), 3, adjFinder);
    }

    private void CreateAllHexesArray()
    {
        int heightOfArray = allRows.Length;
        int widthOfArray = allRows[0].allHexesInRow.Length;
        allHexesArray = new BattleHex[widthOfArray, heightOfArray];
        for (int i = 0; i < heightOfArray; i++)
        {
            for (int j = 0; j < widthOfArray; j++)
            {
                allHexesArray[j, i] = allRows[heightOfArray - i - 1].allHexesInRow[widthOfArray - j - 1];
                allHexesArray[j, i].verticalCoordinate = i + 1;
                allHexesArray[j, i].horizontalCoordinate = j + 1;
            }
        }
    }

    private void IdentifyHexes()
    {
        foreach (BattleHex hex in allHexesArray)
        {
            if (Mathf.Abs(hex.transform.position.x) > 409 |
                Mathf.Abs(hex.transform.position.y) > 220)
            {
                hex.MakeInactive();
            }
            else
            {
                hex.MakeActive();
            }
        }

        CreateActiveHexList();
    }

    private void CreateActiveHexList()
    {
        foreach (BattleHex hex in allHexesArray)
        {
            if (hex.battleHexState == HexState.active)
            {
                activeHexList.Add(hex);
            }
        }
    }

}