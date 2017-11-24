using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    protected int speed;
    protected int Dmg;
    protected int ExploRadius = 0;
    public GameObject ExplosionTrigger;
   

    protected virtual void Start()
    {
        

        if(ExplosionTrigger == null)
        {
            return;
        }

        ExplosionTrigger.SetActive(false);
    }


    // Update is called once per frame
    protected virtual void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);

        
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
            {
                Enemy enemy = col.gameObject.GetComponent<Enemy>();
                enemy.life -= Dmg;
                Destroy(gameObject);
            }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (ExploRadius > 1)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                ExplosionTrigger.SetActive(true);
            }
        }

        else    if (collision.gameObject.tag == "Enemy")
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.life -= Dmg;
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "Death")
            {
            Destroy(gameObject);
           
            }
   
        }

    }

