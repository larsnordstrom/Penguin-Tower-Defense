using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{    
    // skjuta prefabsen
    private Transform fp; 
    [SerializeField]  
    private GameObject bulletPrefab;
    private GameObject clone;
    private Rigidbody2D pew;


    // punkt att skjutas ifrån
    private Vector3 pos;
    private Vector3 angle;

    // variabler från bullets
    private float b_speed;
    private float b_dmg;
    private float b_firerate;
    private int b_affect;
    private bool shootingStopped = false; 
   
    void Start()
    {
        fp = transform.Find("firePoint");
        //hämtar alla variabler från bullet
        
        b_dmg = bulletPrefab.GetComponent<bulletVar>().dmg;
        b_speed = bulletPrefab.GetComponent<bulletVar>().speed;
        b_firerate = bulletPrefab.GetComponent<bulletVar>().firerate;
        b_affect = bulletPrefab.GetComponent<bulletVar>().affect;
        
    }
    private void Update()
    {
        // För testing, kan ta bort detta sen när det fungerar
        if (Input.GetKeyDown("space"))
        {
            startShooting();
        }
        else if(Input.GetKeyDown("return"))
        {
            Debug.Log("you have stopped");
            stopShooting();
        }
    }

    public void startShooting() {
        shootingStopped = false;
        shooting();
        StartCoroutine(Countdown());
    }
    public void stopShooting()
    {
        shootingStopped = true;
    }
    private IEnumerator Countdown()
    {
        // add arrays 
        float duration = b_firerate; // 3 seconds you can change this 
                                     //to whatever you want
        while (duration > 0f)
        {
            if (shootingStopped){
                yield break;
            }
            else {
                yield return new WaitForSeconds(1);
            }

            duration--;
        }
        shooting();
        StartCoroutine(Countdown());
    }

    public void shooting() {
        // räknar ur posiiton och rikting där projectilen ska skjutas 
        pos = fp.position;
        angle = fp.transform.eulerAngles;
        angle += new Vector3(0, 0, 90);
        // skapar en klon av bullet prefab som skjuts iväg
        clone = Instantiate(bulletPrefab, pos, Quaternion.Euler(angle));
        pew = clone.GetComponent<Rigidbody2D>();
        // ger en relativ force rakt uppåt, så det hållet som vapnet pekar
        pew.AddRelativeForce(new Vector3(0, -b_speed), ForceMode2D.Force);
        Destroy(clone, 2f);
        spriteAnimation a = gameObject.GetComponentInParent<spriteAnimation>();
        a.enabled = true;

    }
    // special effect 

    // i enemie titta vad det är fär effect på den kulan, om det är samma effekt som fienden gör detta
    // if(effekt == myEffekt){
    //  Do nothing 
    // or do all
    // }
}
