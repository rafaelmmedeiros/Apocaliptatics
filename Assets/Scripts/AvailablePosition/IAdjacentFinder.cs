using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAdjacentFinder
{
    void GetAdjacentHexesExtended(BattleHex initialHex);
}
