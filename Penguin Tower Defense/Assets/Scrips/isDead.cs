using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isDead : MonoBehaviour
{
    [SerializeField] public int hp;
    // Kan g�ra listor av dessa s� att skeppen har flera effective och immuninty
    [SerializeField] public int immunity;
    [SerializeField] public int superEffective;
    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            GameObject g = GameObject.Find("Coins");
            g.GetComponent<coins>().Coins+=20;
            Debug.Log("DEAD");
            Destroy(gameObject);
        }
    }
}
