using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    // this class allows the creation of the fireball and ice spells

    public GameObject projectile;
    public GameObject ice;
    public Transform ShotPoint;

    public void shootProjectile(float projectileDamage, float force, int endlag)
    {
        // https://www.youtube.com/watch?v=RnEO3MRPr5Y
        if (gameObject.GetComponent<GeneralFunctions>().able)
        {
            gameObject.GetComponent<GeneralFunctions>().setAbleFalse(endlag);   //toggles able off
            GameObject createdProjectile = Instantiate(projectile, ShotPoint.position, ShotPoint.rotation); //creates the projectile
            createdProjectile.GetComponent<Fireball>().dmg = projectileDamage; //sets damage
            createdProjectile.GetComponent<Rigidbody>().velocity = ShotPoint.transform.forward * force; //applies force to make it move
        }

    }

    public void castIce(float iceDmg, int endlag)
    {
        // https://www.youtube.com/watch?v=RnEO3MRPr5Y
        if (gameObject.GetComponent<GeneralFunctions>().able)
        {
            gameObject.GetComponent<GeneralFunctions>().setAbleFalse(endlag); //toggles able off
            GameObject createdIce = Instantiate(ice, ShotPoint.position, ShotPoint.rotation); //creates ice object
            createdIce.GetComponent<IceSpell>().dmg = iceDmg; //sets damage
        }

    }

}
