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

    public void SetDistanceFofGroundUnit(BattleHex initialHex)
    {
        distanceFromStartingPosition = initialHex.distanceText.distanceFromStartingPosition
                    + initialHex.distanceText.stepsToGo;
        DisplayDistanceText();
    }

    public void SetDistanceFofFlyingUnit(BattleHex initialHex)
    {
        distanceFromStartingPosition = initialHex.distanceText.distanceFromStartingPosition
                    + 1;
        DisplayDistanceText();
    }

    private void DisplayDistanceText()
    {
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

    public bool EvaluateDistanceForGround(BattleHex initialHex)
    {
        int currentDistance = initialHex.distanceText.distanceFromStartingPosition
                              + initialHex.distanceText.stepsToGo;
        int stepsLimit = BattleController.currentAtacker.velocity;

        return distanceFromStartingPosition > currentDistance &&
                stepsLimit >= currentDistance;
    }
}
