using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public int knives;
    [SerializeField] private float speed;

    [SerializeField] private GameObject bombochka, knife;

    public Vector3 bombPos, knifePos;
    public GameObject[] parts = new GameObject[3];
    Rigidbody2D[] rb = new Rigidbody2D[3];

    void Start()
    {
        Instantiate(knife, knifePos, Quaternion. identity);
        for (int i = 0; i < 3; i++)
        {
            rb[i] = parts[i].GetComponent<Rigidbody2D>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 270 * Time.deltaTime * speed));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        print("Collision with");
        print(collider.name);
        if(collider.tag == "Knife")
        {
            if (knives == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    rb[i].bodyType = RigidbodyType2D.Dynamic;
                    parts[i].transform.parent = null;
                }
                Destroy(gameObject);
                Instantiate(bombochka, bombPos, Quaternion.identity);
            }
            else if (knives > 0)
            {
                Instantiate(knife, knifePos, Quaternion.identity);
                knives--;
            }
        }
    }

}
