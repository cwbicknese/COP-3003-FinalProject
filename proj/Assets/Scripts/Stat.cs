using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=e8GmfoaOB4Y&t=245s

[System.Serializable] //enables [SerializeField]
public class Stat 
{
    [SerializeField] //makes it show in Unity Inspector

    private int baseValue; // encapsulation: protects members from being modified
                           // Private members can only be accessed from within the class that defines it.
                           // Protected members can be accessed by child/parent classes.
                           // Public members can be accessed by classes that have no relation to the class. 
                           // baseValue is set to private so that it can only be modified directly from within this class
                           // the functions below are public so that other functions may get, set, increase, or decrease baseValue
    public int getValue()
    {
        return baseValue;
    }
    public void setValue(int newValue)
    {
        baseValue = newValue;
    }
    public void incValue(int amount = 1) // default parameter sets the increase amount to 1 if no argument is given in the call
    {
        baseValue += amount;
    }
    public void decValue(int amount = 1) // default parameter sets the decrease amount to 1 if no argument is given in the call
    {
        baseValue -= amount;
    }

}
