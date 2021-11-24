using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class uses the able variable to determine whether the object is able to perform actions
public class GeneralFunctions : MonoBehaviour
{
    public bool able = true;
    public int ableCounter = 0;

    void Update()
    {
        //any functions that can only be performed while able is true go here
        if (able == true)
        {
            if (Input.GetKeyDown("z")) // this can be to call any function
            {
                //doFunction();
                setAbleFalse(600);
            }
        }

        //when able is false, set it back to true after the delay
        if (able == false)
        {
            if (ableCounter > 0) //checks delay before changing able back to true
            {
                ableCounter--;
            }
            else //player is able to move again, able set back to true
            {
                able = true;
                ableCounter = 0;
            }
        }


    }

    //this function sets able to false for an amount of time determined by the argument given.
    //this will mainly be used to create endlag to certain actions.
    public void setAbleFalse(int delay)
    {
        ableCounter = delay;
        able = false;
    }




}
