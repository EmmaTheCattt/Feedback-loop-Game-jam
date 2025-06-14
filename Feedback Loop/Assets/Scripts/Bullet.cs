using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Ship;

    public float speed = 1.0f;
    public bool works = true;

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
        int num = Random.Range(0, 2);
        SR.color = Ship_colors[num];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Return"))
        {
            Debug.Log("We hit");
            Ship = GameObject.FindGameObjectWithTag("Player");
            transform.up = Ship.transform.position - transform.position;
        }
    }
}
