using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public int distanceFromStartingPosition;
    public int stepsToGo;
    BattleHex battleHex;
    Text distanceText;

    void Start()
    {
        battleHex = GetComponentInParent<BattleHex>();
        distanceText = GetComponent<Text>();
    }

    public void SetDistanceFromStartingHex(BattleHex initialHex)
    {
        distanceFromStartingPosition = initialHex.distanceText.distanceFromStartingPosition
            + initialHex.distanceText.stepsToGo;

        distanceText.text = distanceFromStartingPosition.ToString();
        distanceText.color = new Color32(255, 255, 255, 255);
    }
}
