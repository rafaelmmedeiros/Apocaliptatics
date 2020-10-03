using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public RowManager[] allRows; 
    public BattleHex[,] allHexesArray;
    void Start()
    {
        allRows = GetComponentsInChildren<RowManager>();
    }

    void Update()
    {

    }
}
