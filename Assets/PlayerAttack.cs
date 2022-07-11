using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwordAttack();
        }
    }
    void SwordAttack()
    {
        Invoke("EnableSword", 0);
        Invoke("DisableSword", 0.1f);
    }

    void EnableSword()
    {
        sword.SetActive(true);
    }
    void DisableSword()
    {
        sword.SetActive(false);
    }
}
