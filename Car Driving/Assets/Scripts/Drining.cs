using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drining : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.01f;
    private bool isPackeg = false;

    [SerializeField] private Color32 hasPackeheColor= new Color32(1, 0, 0, 1);
    [SerializeField] private Color32 noPackeheColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Boom!");
        //Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pack" && !isPackeg)
        {
            Debug.Log("Pack");
            isPackeg = true;
            Destroy(collision.gameObject, 0.5f);
            spriteRenderer.color = hasPackeheColor;
        }

        if (collision.tag == "Deliver" && isPackeg)
        {
            Debug.Log("Deliver");
            isPackeg = false;
            spriteRenderer.color = noPackeheColor;
        }


        if (collision.tag == "Speeds")
        {
            moveSpeed *= 4;
            Destroy(collision.gameObject);
        }


    }
}
