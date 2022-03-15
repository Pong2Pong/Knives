using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private bool used = false;
    public GameObject wood;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(0.6f, 0.6f, 1);
        wood = GameObject.Find("Wood");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !used)
        {
            rb.AddForce(new Vector3(0, 2500, 0), ForceMode2D.Force);
            used = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Knife")
        {
            print("loose");
        }
        else if (collider.name == "Wood")
        {
            print("Collided with wood");
            transform.parent = wood.transform;
            rb.Sleep();
        }
    }
}








