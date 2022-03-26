using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public int hp;
    private float curTime;
    [SerializeField] private AnimationCurve rotation;
    [SerializeField] private GameObject knifeIcon;
    [SerializeField] private GameObject bombochka, knife;

    public Vector3 bombPos, knifePos;
    private Rigidbody2D rb ;

    void Start()
    {
        for(int i = hp; i>=0; i--)
        {
            Instantiate(knifeIcon, new Vector2(-4f,-8f+i),Quaternion.identity);
        }
        Instantiate(knife, knifePos, Quaternion. identity);
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 270 * Time.deltaTime * rotation.Evaluate(curTime)));
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Knife")
        {
            if (hp == 0)
            {
                for (int i = transform.childCount - 1; i >= 0; i--)
                {
                    rb = transform.GetChild(i).GetComponent<Rigidbody2D>();
                    rb.WakeUp();
                    rb.gravityScale = 1;
                    rb.bodyType = RigidbodyType2D.Dynamic;
                    rb.AddForce(new Vector2(Random.Range(-100,100), Random.Range(-100,100)), ForceMode2D.Force);
                    transform.GetChild(i).parent = null;
                }
                Destroy(gameObject);
                Instantiate(bombochka, bombPos, Quaternion.identity);
            }
            else if (hp > 0)
            {
                Instantiate(knife, knifePos, Quaternion.identity);
                hp--;
            }
        }
    }

}
