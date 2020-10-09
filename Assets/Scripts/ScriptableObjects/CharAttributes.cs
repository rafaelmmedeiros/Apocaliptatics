using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroAttributes", menuName = "Fighter")]
public class CharAttributes : ScriptableObject
{
    public int velociry;
    public float initiative;
    public int hp;
    public int attack;
    public int resistence;
    public int stack;
    public Sprite heroSprite;
    public Hero heroSO;
}

