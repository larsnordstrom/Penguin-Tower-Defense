using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static int playerLives;
    [SerializeField] private int startLives = 20; 


    void Start()
    {
        playerLives = startLives;
    }

    public static int PlayerLives
    {
        get { return playerLives; }
        set { playerLives = value; }
    }
    

}
