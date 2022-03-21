using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
    private bool used = false;
    private int difficultyLevel;
    public GameObject wood;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            Level_Generator.GenerateLevel();
        }
        else if (collider.name == "Wood")
        {
            transform.parent = wood.transform;
            rb.Sleep();
        }
    }
}








