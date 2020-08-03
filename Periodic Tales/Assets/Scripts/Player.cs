using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJumping;

    private Animator anim;

    private Rigidbody2D rig;  //rigidbody tem classe e método pronto pra fazer o pulo

    bool isBlowing;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>(); //criar a variável e informa que vai receber o componente que tiver anexado ao objeto que esta com esse script
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {

        //transform position só aceita o vector3
        //Input já possui controle pré determinado e por isso se usa o horizontal, vertical ou qualquer outro
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);//só passa o parametro inteiro do eixo y para que o mesmo não tenha alteração
        //move o personagem sem usar física
        //transform.position += movement * Time.deltaTime * Speed;

        if (movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (movement == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isBlowing) //jump por padrão configurado na tecla space
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); //addforce é um método que adiciona uma força a um objeto em alguma direção
                doubleJumping = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJumping)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); //addforce é um método que adiciona uma força a um objeto em alguma direção
                    doubleJumping = false;
                }
            }
        }

    }

    //método padrão na unity para checar quando toca no chão

    void OnCollisionEnter2D(Collision2D collision)
    {
        //método chamado quando tocar em alguma coisa
        if(collision.gameObject.layer == 8) //o layer foi criado no ground e ticado no mesmo o layer criado "8"
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.tag == "Spike") //o layer foi criado no ground e ticado no mesmo o layer criado "8"
        {
            GameControler.instance.ShowGameOver();

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Saw") //o layer foi criado no ground e ticado no mesmo o layer criado "8"
        {
            GameControler.instance.ShowGameOver();

            Destroy(gameObject);
        }


    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //método chamado quando para de tocar em alguma coisa
        if (collision.gameObject.layer == 8) //o layer foi criado no ground e ticado no mesmo o layer criado "8"
        {
            isJumping = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        //vai usar triger por a maça estar com in trigger ticado
        if (collision.gameObject.layer == 11)
        {
            isBlowing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            isBlowing = false;
        }
    }
}
