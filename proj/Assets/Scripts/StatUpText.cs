using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //this is needed to use Unity's Text class

public class StatUpText : MonoBehaviour
{
    public Text statText;
    public string whichStat;
    public float statAmount = 0f;
    public int statCounter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        statText.text = whichStat + statAmount + "!";
        //dmgText.transform.position = transform.position;

        // timer for how long damage is shown
        if (statCounter > 0)
        {
            statCounter--;
        }
        else
        {
            enabled = false;
        }
    }
}
