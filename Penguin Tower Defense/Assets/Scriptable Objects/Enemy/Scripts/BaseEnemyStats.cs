using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BaseEnemyStats", menuName = "Enemy/EnemyStats")]
public class BaseEnemyStats : ScriptableObject
{
    [SerializeField] private int hp;
    [SerializeField] private int dmg;
    [SerializeField] private float speed;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Dmg
    {
        get { return dmg; }
        private set { dmg = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
}
