using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    public float speed;
    public float moveTime;

    private bool dirRight = true;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (dirRight) // se esse booleano verdadeiro a serra vai pra direita
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else // se falso vai pra esquerda
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if(timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
