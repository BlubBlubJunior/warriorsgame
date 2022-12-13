using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleecombat : MonoBehaviour
{
    public int damage = 10;
    public int health = 100;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            damage -= health;
        }
    }
}
