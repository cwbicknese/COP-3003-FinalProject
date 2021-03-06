using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyParent
{
    public GameObject drop;
    protected override void die()
    {
        dropRate = 100;
        if (Random.Range(0, 101) <= dropRate) // Random.Range function using integers excludes its max value, so this produces a random number from 0 to 100 and checks if its <= 25.
        {
            Instantiate(drop, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        Destroy(gameObject);
    }


}
