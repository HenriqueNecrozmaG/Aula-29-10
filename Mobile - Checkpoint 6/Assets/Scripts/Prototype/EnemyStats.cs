using System;
using UnityEngine;

[Serializable]
public class EnemyStats : IPrototype<EnemyStats>
{
    public string name;
    public int health;
    public float speed;
    public float scoreGiven;
    public Color enemyColor;

    public EnemyStats Clone()
    {
        return (EnemyStats)this.MemberwiseClone();
    }
}
