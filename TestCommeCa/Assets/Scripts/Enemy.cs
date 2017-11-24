using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    
    public float speed = 3;
    public float life = 100;
    private GameObject Player1;
    private GameObject Player2;
    public float Distance;
    private SpriteRenderer _SpriteRend;


    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        _SpriteRend = GetComponent<SpriteRenderer>();
        foreach (var player in players)
        {
            if (player.transform.position.y > -1.88)
                Player1 = player;
            else
                Player2 = player;
        }
    }
    public virtual void Stats(int ChangeSpeed, float ChangeLife)
    {
        speed = ChangeSpeed;
        life = ChangeLife;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<Projectile>())
        {
            Projectile Proj = col.gameObject.GetComponent<Projectile>();
            StartCoroutine(Hit());
        }
    }

    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }

        

        Distance = speed * Time.deltaTime;

        if (transform.position.y > -1.88 && Player1.transform.position.x < transform.position.x)
        {
        
            transform.Translate(new Vector2(-1f, 0f) * speed * Time.deltaTime);
        }
        else if(transform.position.y > -1.88 && Player1.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = Vector3.up * 180;
            transform.Translate(new Vector2(-1f, 0f) * speed * Time.deltaTime);
        }

        if (transform.position.y <  -1.88 && Player2.transform.position.x < transform.position.x)
        {
           
            transform.Translate(new Vector2(-1f, 0f) * speed * Time.deltaTime);
        }

        else if (transform.position.y < -1.88 && Player2.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = Vector3.up * 180;
            transform.Translate(new Vector2(-1f, 0f) * speed * Time.deltaTime);
        }
    }

    IEnumerator Hit()
    {
      
        _SpriteRend.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _SpriteRend.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        _SpriteRend.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _SpriteRend.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        _SpriteRend.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _SpriteRend.color = Color.white;
        yield return new WaitForSeconds(0.05f);


    }


}
