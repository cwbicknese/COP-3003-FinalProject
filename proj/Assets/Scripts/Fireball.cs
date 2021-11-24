using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private int duration = 600; // this is private so that the variable is only accessible within this class
    public float dmg;           // this is public so that other classes may access this variable

    // generics in C# are mostly the same as templates in C++, but there are some differences:
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/differences-between-cpp-templates-and-csharp-generics

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
        //collision with environment/wall
        if (other.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject); //destroys self
        }
    
        //collision with enemy
        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.GetComponent<EnemyParent>().takeDamage(dmg); // calls takeDamage() from EnemyParent. EnemyParent has no function takeDamage(), so it finds it in its superclass CharacterStats.
                                                                          
            Destroy(gameObject); //destroys self
        }

    }

}
