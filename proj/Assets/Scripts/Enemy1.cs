using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyParent
{
    public GameObject drop;
    protected override void die() 
    {
        dropRate = 25;
        if (Random.Range(0, 101) <= dropRate) // Random.Range function using integers excludes its max value, so this produces a random number from 0 to 100 and checks if its <= 25.
        {
            Instantiate(drop, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        Destroy(gameObject);
    }

    // Enemy1 is a subclass of EnemyParent, which is a subclass of CharacterStats.
    // Subclasses inherit all members their superclasses possess, and can add more.
    // The die() function above overrides the protected virtual die() function in CharacterStats because Enemy1 is an EnemyParent class which is a CharacterStats class. 
    // When die() is called in CharacterStats, it will use this varient of die() because it is the most derived.


}
