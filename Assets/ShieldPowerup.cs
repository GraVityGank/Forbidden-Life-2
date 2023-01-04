using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour
{
    public float ArmorBuff = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Armored");
            Pickup(other);
        }
        if (other.CompareTag("Player F"))
        {
            FindObjectOfType<AudioManager>().Play("Regeneration");
            Pickup(other);
        }
        if (other.CompareTag("Player B"))
        {
            FindObjectOfType<AudioManager>().Play("Regeneration");
            Pickup(other);
        }
    }
    void Pickup(Collider2D Player)
    {
        WorldDamage stats = Player.GetComponent<WorldDamage>();
        if (stats.CurrentArmor < stats.maxArmor)
        {
            stats.CurrentArmor += ArmorBuff;
            stats.armorBar.SetArmor(stats.CurrentArmor);
        }
        else if (stats.CurrentArmor >= stats.maxArmor)
        {
            ArmorBuff = 0;
            stats.CurrentArmor += ArmorBuff;
            stats.armorBar.SetArmor(stats.CurrentArmor);
        }
        Destroy(gameObject);
        //Debug.Log("Power Uped!");
    }
}


