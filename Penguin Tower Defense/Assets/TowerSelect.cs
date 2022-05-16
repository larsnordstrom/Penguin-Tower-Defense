using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelect : MonoBehaviour
{
    public GameObject tower;
    private int NumberOfType = 1;

    // Start is called before the first frame update
    public void OnMouseDown()
    {

       // Debug.Log("yeahyeahyeah");

        GameObject Tower2Spawn;
        Tower2Spawn = Instantiate(tower, transform.position, Quaternion.identity);
        Tower2Spawn.name = tower.name + " (" + NumberOfType + ")";
        NumberOfType++;
    }
}
