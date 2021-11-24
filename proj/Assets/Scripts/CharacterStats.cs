using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=e8GmfoaOB4Y&t=245s

public class CharacterStats : MonoBehaviour
{

    //HP
    public float hpMax = 100f;
    public float hp;

    //MP
    public float mpMax = 100f;
    public float mp;

    //Atk and Def
    public Stat attack;
    public Stat defense;

    //gold
    public int gold = 0;

    public CharacterStats() // default contructor sets hp to 100 if no parameters
    {
        hpMax = 100f;
        hp = hpMax;
    }
    public CharacterStats(float maxHealth) // uses 1 parameter, maxHealth, and sets hp to it
    {
        hpMax = maxHealth;
        hp = hpMax;
    }

    void Awake()
    {
        hp = hpMax;
        mp = mpMax;
    }

    void Update()
    {

    }

    public void takeDamage(float damage)
    {
        damage -= defense.getValue(); //damage is reduced by the value of the defense stat
        damage = Mathf.Clamp(damage, 0, float.MaxValue); //prevents damage from being negative

        hp -= damage;

        //damage number shown
        GameObject.Find("dmg_text").GetComponent<DamageNumbers>().dmgAmount = damage;
        GameObject.Find("dmg_text").GetComponent<DamageNumbers>().dmgCounter = 120;

        if (hp <= 0)
        {
            die(); // In CharacterStats, die() is virtual, so it will go down to the most derived form of the function
                   // to override it, which will be in Enemy1 or Enemy2.
        }

    }

    // Polymorphism: when die() is called, because it is virtual, it will look for the most derived class that has the function.
    virtual protected void die() 
    {
        Destroy(gameObject);
    }


}
