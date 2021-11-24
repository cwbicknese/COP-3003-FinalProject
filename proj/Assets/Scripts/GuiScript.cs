using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //this is needed to use Unity's Text class

//this class writes information on the screen
public class GuiScript : MonoBehaviour
{
    public Text guiText;
    private GameObject playerObj;
    private CharacterStats playerStats;

    private string goldString;
    private string hpString;
    private string mpString;
    private string atkString;
    private string defString;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("obj_player");
        playerStats = playerObj.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //write stats on the screen
        goldString = "Gold: " + playerStats.gold;
        hpString = "HP: " + playerStats.hp + "/" + playerStats.hpMax;
        mpString = "MP: " + playerStats.mp + "/" + playerStats.mpMax;
        atkString = "Atk: " + playerStats.attack.getValue();
        defString = "Def: " + playerStats.defense.getValue();

        guiText.text = goldString + "\n"
            + hpString + "\n"
            + mpString + "\n"
            + atkString + "\n"
            + defString + "\n"
            ;
    }
}
