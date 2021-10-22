using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public Image healthBar;
    public Image healthBarBG;

    public bool Boss;
    public string BossName;
    public float bossHealth;
    public Text BossNameT;
    public GameObject BossUI;
    public Image BossUIImg;
    public Sprite BossIMG;

    public LayerMask player;
    public bool Attacking;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public float damage;
    private float damagedTime = 0;
    private float afterDeath = 0;

    Rigidbody2D rb;
    Animator anim;
    AIPath aiPath;

    void Start()
    {
      if(Boss)
      {
        BossNameT.GetComponent<Text>().text = BossName;
        health = bossHealth;
        BossUIImg.sprite = BossIMG;
      }
      aiPath = GetComponent<AIPath>();
      anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();

    }

    public void GetDamage(float d)
    {
      damagedTime = 0;
      GetComponent<SpriteRenderer>().color = Color.red;
      health -= d;

    }

    void Update()
    {
      if(!Boss)
        healthBar.fillAmount = health/100;
      else healthBar.fillAmount = health/bossHealth;

      if(health <= 0)
      {
        if (!Boss)
          healthBarBG.enabled = false;
        else BossUI.SetActive(false);

        anim.SetBool("isDead",true);
        aiPath.enabled = false;
        rb.simulated = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<AIDestinationSetter>().enabled = false;
        GetComponent<Patrol>().enabled = false;
        afterDeath += Time.deltaTime;
        if(afterDeath > 5)
          Destroy(gameObject);
      }


      damagedTime +=Time.deltaTime;
      if(damagedTime > 0.3f)
        GetComponent<SpriteRenderer>().color = Color.white;

      if(aiPath.desiredVelocity.x >= 0.01f)
        transform.localScale = new Vector3(1.5f,1.5f,1);
      if(aiPath.desiredVelocity.x <= 0.01f)
        transform.localScale = new Vector3(-1.5f,1.5f,1);

      if(Attacking)
      {
        if(Boss)
          BossUI.SetActive(true);
        else anim.SetBool("Attack",true);
        Attack();
      }
      else if(!Boss)anim.SetBool("Attack",false);
    }

    public void Attack()
    {
      if(timeBtwAttack <= 0)
      {
        Collider2D[] PlayerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, player);
        for(int i = 0 ; i < PlayerToDamage.Length; i++)
          PlayerToDamage[i].GetComponent<heroBehavior>().GetDamage(damage);
        timeBtwAttack = startTimeBtwAttack;
      }
      else timeBtwAttack -= Time.deltaTime;

    }


    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag == "Player")
      {
        Attacking = true;
        GetComponent<Patrol>().enabled = false;
        GetComponent<AIDestinationSetter>().enabled = true;
      }
    }
    void OnTriggerExit2D(Collider2D col)
    {
      if(!Boss)
      {
        if(col.gameObject.tag == "Player")
        {
          Attacking = false;
          GetComponent<Patrol>().enabled = true;
          GetComponent<AIDestinationSetter>().enabled = false;
        }
      }
    }



    void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }
}
