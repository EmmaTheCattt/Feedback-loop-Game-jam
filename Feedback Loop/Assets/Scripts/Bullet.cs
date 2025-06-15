using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Ship;

    public float speed = 1.0f;
    public bool Enemy = false;

    public int num;
    public static int num_cursor = -1;

    public Color[] Ship_colors;
    public Color[] Enemy_colors;
    public SpriteRenderer SR;

    public Vector3 Direction;
    


    // Start is called before the first frame update
    void Start()
    {
        /*
        SR = GetComponent<SpriteRenderer>();
        SR.color = Ship_color;
        */
    }

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        num = Random.Range(0, 2);
        num_cursor = num;
        SR.color = Ship_colors[num];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("SOMETHING hit");

        if (other.CompareTag("Return"))
        {
            Debug.Log("We hit");
            Ship = GameObject.FindGameObjectWithTag("Player");
            transform.up = Ship.transform.position - transform.position;
            
            Enemy = true;
            SR.color = Enemy_colors[num];
        }
    }
}
