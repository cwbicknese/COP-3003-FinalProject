using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpell : MonoBehaviour
{
    public int duration = 200;
    public float dmg;

    private bool hurt = false;

    // Update is called once per frame
    void Update()
    {
        //automatic self destruction after a certain amount of time
        duration--;
        if (duration <= 0)
        {
            Destroy(gameObject); //destroys self
        }

    }

    //collision
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision detected");
        //collision with enemy
        if (other.gameObject.CompareTag("enemy"))
        {
            if (hurt == false) //this ensures that it only hits once instead of every frame
            {
                dmg /= 2; //ice is half as strong as the attack value passed to it from PlayerMovement when it is created
                dmg += other.gameObject.GetComponent<CharacterStats>().defense.getValue(); //adds foe's defense so that it pierces defense
                other.gameObject.GetComponent<EnemyParent>().takeDamage(dmg);
                Debug.Log("ice damage: " + dmg);
                hurt = true;
            }
        }
    }

}
