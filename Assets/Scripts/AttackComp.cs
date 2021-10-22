using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackComp : MonoBehaviour
{
    public Animator anim;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Image cdBar;

    public Transform attackPos;
    public float attackRange;
    public LayerMask enemy;
    public float damage;
    public bool Attack;


    public void SetAttack(bool a)
    {
      Attack = a;

    }

    void Update()
    {
      cdBar.fillAmount = timeBtwAttack;
      anim.SetBool("Attack",false);
      if(timeBtwAttack <= 0)
      {
        if(Attack)
        {
          anim.SetBool("Attack",true);
          Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
          for(int i = 0 ; i < enemiesToDamage.Length; i++)
          {
            enemiesToDamage[i].GetComponent<Enemy>().GetDamage(damage);
          }
          timeBtwAttack = startTimeBtwAttack;
        }

      }
      else timeBtwAttack -= Time.deltaTime;

    }


    void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(attackPos.position,attackRange);

    }
}
