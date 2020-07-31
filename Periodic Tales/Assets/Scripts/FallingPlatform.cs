using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public float fallingTime;

    private TargetJoint2D target;
    private BoxCollider2D boxColl;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //método chamado quando tocar em alguma coisa
        if (collision.gameObject.tag == "Player") 
        {
            Invoke("Falling", fallingTime);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        target.enabled = false;
        boxColl.isTrigger = true;
        //esse metodo desabilita o joint e seleciona o trigger no boxcollider, serve para cair a plataforma e sumir da tela
    }
}

