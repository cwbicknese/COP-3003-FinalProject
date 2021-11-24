using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int amount;
    Gold() // default constructor
    {
        amount = 1;
    }
    Gold(int x) // overloaded constructor
    {
        amount = x;
    }
}
