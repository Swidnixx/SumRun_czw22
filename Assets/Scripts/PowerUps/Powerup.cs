using System;
using UnityEngine;

public abstract class Powerup : ScriptableObject
{
    public bool isActive;
    public float duration = 1;
    public int level = 1;
    public int upgradeCost = 100;
}
