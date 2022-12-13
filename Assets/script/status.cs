using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour
{
    public int health;
    public int damage;
    public int speed;
    public int defence;

    public string sword;
    public bool canattack = true;
    public float attackcooldown = 1.0f;

    void update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canattack)
            {
                swordattack();
            }
        }
    }
    public void swordattack()
    {
        canattack = false;
        //StartCoroutine(reserattackcooldown());
    }
    IEnumerable reserattackcooldown()
    {
        yield return new WaitForSeconds(attackcooldown);
        canattack = true;
    }
}
