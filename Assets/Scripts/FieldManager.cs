﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public RowManager[] allRows;
    public BattleHex[,] allHexesArray;
    int allRowsLenght;
    void Start()
    {
        allRows = GetComponentsInChildren<RowManager>();
        allRowsLenght = allRows.Length;

        for (int i = 0; i < allRowsLenght; i++)
        {
            allRows[i].allHexesInRow = allRows[i].GetComponentsInChildren<BattleHex>();
        }

        CreateAllHexesArray();
        CreateActiveHexesArray();
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

    private void CreateActiveHexesArray()
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
    }

}
