using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int lives = 3;
    public int health = 3;
    [SerializeField]
    private GameObject blink;
    public float knockBackForce;
    public float knockBackDuration;
    // Start is called before the first frame update
    void Start()
    {
        blink.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int damageAmount)
    {
        health -= damageAmount;
        Blink();
        if (health <= 0)
        {
            lives--;
            if (lives <= 0)
            {
                //die
                //Invoke("Death", 0.1f);
                return;
            }
            return;
        }
        //damage animation + sound + etc
        
        //update UI
    }

    void Death()
    {
        Destroy(gameObject);
    }

    void Blink()
    {
        Invoke("EnableBlink", 0);
        Invoke("DisableBlink", 0.1f);
    }

    void EnableBlink()
    {
        blink.SetActive(true);
    }
    void DisableBlink()
    {
        blink.SetActive(false);
    }

   
}
