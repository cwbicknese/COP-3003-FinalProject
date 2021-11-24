using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBooster : MonoBehaviour
{
    
    //collision
    void OnTriggerEnter(Collider other)
    {
        //collision with environment/wall
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterStats>().attack.incValue(); // no argument is given so it uses the default parameter in incValue() found in the Stat class

            Destroy(gameObject); //destroys self
        }

    }
}
