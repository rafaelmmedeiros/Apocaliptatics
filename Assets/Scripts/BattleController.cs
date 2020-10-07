using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleHex targetToMove;
    public static Hero currentAtacker;
    
    void Start()
    {
        currentAtacker = FindObjectOfType<Hero>();
    }

    void Update()
    {

    }

    private void Awake()
    {

    }
}
