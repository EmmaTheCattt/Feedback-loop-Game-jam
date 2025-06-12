using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lock_to_ship : MonoBehaviour
{

    public GameObject ship;


    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ship.transform.position;
    }
}
