using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int lives = 3;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            lives--;
            if (lives <= 0)
            {
                //die
            }
        }
        //update UI
    }
}
