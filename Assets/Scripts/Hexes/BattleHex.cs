using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HexState { inactive, active };

public class BattleHex : MonoBehaviour
{
    public int horizontalCoordinate;
    public int verticalCoordinate;
    public HexState battleHexState;
    public bool isSecondLevel = false;
    public Image landscape;

    void Start()
    {

    }

    void Update()
    {

    }
}
