using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Networking;

public class PLayerController : NetworkBehaviour {

    public int speed;
    public float life;
    public float jump;
    private Rigidbody2D rb;
    public int _JumpCount;
    public string ReloadScene;
    private float _FireCountdown = 0;
    public  float Knockback;    
    public bool _IsRight = true;
    public GameObject Respawn;
    public GameObject Respawn2;
    protected MainMenu Menu;
    protected SpriteRenderer _SpriteRend;
    protected Life lifeRespawn;

    // Use this for initialization
    protected virtual void Start() {

        _SpriteRend = GetComponent<SpriteRenderer>();
        Menu = GameObject.FindObjectOfType<MainMenu>();
        lifeRespawn = GameObject.FindObjectOfType<Life>();
        Respawn = GameObject.FindGameObjectWithTag("Respawn");
        Respawn2 = GameObject.FindGameObjectWithTag("Respawn2");

        if (Menu.isMulti)
        {
            if (!isLocalPlayer)
            {
                enabled = false;

            }
        }

       
        rb = GetComponent<Rigidbody2D>();
        Stats(5, 100f);

        if (gameObject.transform.position.y <= -1.88f)
        {
            Debug.Log("Inverse");
            rb.gravityScale *= -1;
            jump *= -1;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

       // float Xmove = Input.GetAxis("Horizontal");


        if (Input.GetKey(KeyCode.D))
        {
            if (!_IsRight)
            {
               // transform.Rotate(Vector3.up * 180);
                transform.eulerAngles = Vector3.up * 360;
                _IsRight = true;
            }

            transform.Translate(new Vector2(1, 0f) * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (_IsRight)
            {
                transform.eulerAngles = Vector3.up * 180;
                _IsRight = false;
            }
            transform.Translate(new Vector2(1, 0f) * speed * Time.deltaTime);

        }
       

        if (Input.GetKeyDown("space") && _JumpCount < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            _JumpCount++;
        }

        if (Input.GetMouseButton(0))
        {
            if (_FireCountdown <= 0)
            {
                Shoot(1);
            }

          
            
        }
        _FireCountdown -= Time.deltaTime;
    }

    public virtual void Effect()
    {

    }

    protected virtual void Shoot(float FireRate)
    {
        Effect();
        _FireCountdown = 1 / FireRate;
    }

    public virtual void Stats(int ChangeSpeed, float ChangeLife)
    {
        speed = ChangeSpeed;
        life = ChangeLife;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("JumpResert");
        _JumpCount = 0;

        if (collision.gameObject.tag == "Floor")
        {
            _JumpCount = 0;
        }

        if (collision.gameObject.GetComponent<Enemy>())
        {
            lifeRespawn.LifeNb--;
            StartCoroutine(Hit());


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            if (transform.position.y > -1.88)
            {
                transform.position = Respawn.transform.position;
                rb.velocity = new Vector2(0, 0);
                lifeRespawn.LifeNb--;
            }

            else if (transform.position.y < -1.88)
            {
                transform.position = Respawn2.transform.position;
                rb.velocity = new Vector2(0, 0);
                lifeRespawn.LifeNb--;
            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());

        }

        if (collision.gameObject.tag == "Death2")
        {
            if (transform.position.y > -1.88)
            {
                transform.position = Respawn2.transform.position;
                rb.velocity = new Vector2(0, 0);
                lifeRespawn.LifeNb--;
            }

            else if (transform.position.y < -1.88)
            {
                transform.position = Respawn.transform.position;
                rb.velocity = new Vector2(0, 0);
                lifeRespawn.LifeNb--;
            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name.ToString());

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
