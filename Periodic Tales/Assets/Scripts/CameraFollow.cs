using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float speed = 0.15f;

    private Transform target;

    public bool maxMin;
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed) + new Vector3(0, 0, target.position.z);
            if (maxMin)
            {
                transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), 2 * target.position.z);
            }
        }
    }

    //[SerializeField] // serve para poder modificar o parametro privado no inspetor da unity
    // private Vector3 offset;
    //[Range(0,1)]
    //public float suavidade = 0.2f;
    //public Transform jogador;

    // private void FixedUpdate()
    // {
    // transform.position = Vector3.Lerp(transform.position, jogador.position + offset, suavidade);
    //  transform.LookAt(jogador);
    // }

}
