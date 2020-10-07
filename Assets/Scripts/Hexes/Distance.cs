using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public int distanceFromStartingPosition;
    public int stepsToGo;
    BattleHex hex;
    Text distanceText;

    void Start()
    {
        hex = GetComponentInParent<BattleHex>();
        distanceText = GetComponent<Text>();
    }

    public void SetDistanceFromStartingHex(BattleHex initialHex)
    {
        distanceFromStartingPosition = initialHex.distanceText.distanceFromStartingPosition
                    + initialHex.distanceText.stepsToGo;
        distanceText.text = distanceFromStartingPosition.ToString();
        distanceText.color = new Color32(255, 255, 255, 255);
    }

    public bool EvaluateDistance(BattleHex initialHex)
    {
        return distanceFromStartingPosition + stepsToGo ==
                initialHex.distanceText.distanceFromStartingPosition;
    }

    public int MakeMePartOfOptimalPath()
    {
        OptimalPath.optimalPath.Add(hex);
        hex.landscape.color = new Color32(150, 150, 150, 255);
        return stepsToGo;
    }
}
