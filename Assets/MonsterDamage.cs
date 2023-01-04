using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public float Attack;
    public Animator animator;
    private float nextDamage;
    public float DamDelay;

    void Start()
    {
        nextDamage = Time.time + DamDelay;
    }
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Hurt");
            Damage(other);
            nextDamage = Time.time + DamDelay;
        }
        if (other.gameObject.tag == "Player F")
        {
            FindObjectOfType<AudioManager>().Play("Female Hurt");
            Damage(other);
            nextDamage = Time.time + DamDelay;
        }
        if (other.gameObject.tag == "Player B")
        {
            FindObjectOfType<AudioManager>().Play("Blockboy Hurt");
            Damage(other);
            nextDamage = Time.time + DamDelay;
        }
        else if (other.gameObject.tag == "Monster")
        {
            Destroy(other.gameObject);
        }
    }
    void Damage(Collider2D Player)
    {
        WorldDamage stats = Player.gameObject.GetComponent<WorldDamage>();

        //if (stats.CurrentHealth < stats.maxHealth)
        //
        //og code
            Attack = Attack;
            stats.CurrentArmor -= Attack;
            stats.armorBar.SetArmor(stats.CurrentArmor);
        
        if (stats.CurrentArmor <= 0)
        {
            stats.CurrentHealth -= Attack;
            stats.healthBar.SetHealth(stats.CurrentHealth);
        }
        //end of og code

        //else if (stats.CurrentHealth > stats.maxHealth)
        //{
        //    Attack = 0;
        //    stats.CurrentHealth += Attack;
        //    stats.healthBar.SetHealth(stats.CurrentHealth);
        //}
    }
}
    