using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;

    public BoxCollider2D boxCollider;
    public CircleCollider2D circleCollider;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y); // movimentando o inimigo

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer); // o physics desenha um colisor invisivel em dois pontos da cena

        if (colliding)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;

        }
    }

    bool playerDestroyed = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        //método chamado quando tocar em alguma coisa
        if (collision.gameObject.tag == "Player") //o layer foi criado no ground e ticado no mesmo o layer criado "8"
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;
            Debug.Log(height);
            if(height > 0 && !playerDestroyed)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");
                boxCollider.enabled = false;
                circleCollider.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.2f);
            }
            else
            {
                playerDestroyed = true;
                GameControler.instance.ShowGameOver();
                Destroy(collision.gameObject);
            }
        }

    }
}
