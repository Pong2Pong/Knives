using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public int hp;
    private float curTime;
    [SerializeField] private AnimationCurve rotation;
    [SerializeField] private GameObject knifeIcon;
    [SerializeField] private GameObject hitParticles;
    [SerializeField] private GameObject bombochka, knife;

    public Vector3 bombPos, knifePos;
    private Rigidbody2D rb ;

    void Start()
    {
        for(int i = hp; i>=0; i--)
        {
            GameObject icon = Instantiate(knifeIcon, new Vector2(-4f,-8f+i),Quaternion.identity);
            icon.transform.parent = knifeIcon.transform;
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
                LevelCompleted();
            }
            else if (hp > 0)
            {
                Instantiate(hitParticles, collider.transform.position, Quaternion.identity);
                Instantiate(knife, knifePos, Quaternion.identity);
                hp--;
            }
        }
    }
    private void LevelCompleted()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
            {
                rb = transform.GetChild(i).GetComponent<Rigidbody2D>();
                transform.GetChild(i).parent = null;
                rb.WakeUp();
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 1;
                
            }
            Destroy(gameObject);
            Instantiate(bombochka, bombPos, Quaternion.identity);
    }
}
