using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptimalPath : MonoBehaviour
{
    public static List<BattleHex> optimalPath = new List<BattleHex>();
    public static BattleHex nextStep;
    public List<Image> landscapes = new List<Image>();

    BattleHex targetHex;
    IAdjacentFinder AdjacentOption = new PosForPath();
    Move move;
    private void Start()
    {
        move = GetComponent<Move>();
    }

    internal void MatchPath()
    {
        optimalPath.Clear();
        targetHex = BattleController.targetToMove;
        optimalPath.Add(targetHex);

        int steps = targetHex.distanceText.distanceFromStartingPosition;
        for (int i = steps; i > 1;)
        {
            AdjacentOption.GetAdjacentHexesExtended(targetHex);
            targetHex = nextStep;
            i -= nextStep.distanceText.MakeMePartOfOptimalPath();
        }
        ManagePath();
    }

    void ManagePath()
    {
        landscapes.Clear();
        optimalPath.Reverse();
        foreach (BattleHex hex in optimalPath)
        {
            landscapes.Add(hex.landscape);
        }
        move.path = landscapes;
    }
}
