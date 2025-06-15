using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float time;
    public Vector2 move;
    public Vector2 direction;
    public Vector3 mouseposition;

    public static int alt = 1;

    public Rigidbody2D RB;

    private float x_move;
    private float y_move;

    [Header("Ship stats")]
    public float speed = 10;
    public int Bullets = 1;
    public float firerate = 0.1f;
    public GameObject[] shot_spots;

    [Header("Ship_modes")]
    public bool Attack_mode = false;
    public bool Shield_mode = false;

    [Header("Bullets")]
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;

    [Header("ANIMATION")]
    public Animator Right_GUN;
    public Animator Left_GUN;
    public bool SHOT = false;

    

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PointTowardsMouse();
        Shot(Bullets);
        Move_Input();

        //animation check always last
        ANIMATIONS();
    }

    private void ANIMATIONS()
    {
        Right_GUN.SetBool("SHOT", SHOT);
        Right_GUN.SetInteger("ALT", alt);

        Left_GUN.SetBool("SHOT", SHOT);
        Left_GUN.SetInteger("ALT", alt);
    }

    private void PointTowardsMouse()
    {
        Vector3 mouseposition = Input.mousePosition;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

        direction = new Vector2(mouseposition.x - transform.position.x, mouseposition.y - transform.position.y);

        transform.up = direction;
    }

    private void Shot(int amount)
    {
        SHOT = false;
        time += Time.deltaTime;
        if (Input.GetMouseButton(0) && firerate < time && Attack_mode == true)
        {
            alt = alt * -1;
            for (int i = 0; i < amount; i++)
            {
                if (alt == 1)
                {
                    GameObject Bullet = Instantiate(Bullet1, shot_spots[0].transform.position, Quaternion.identity);
                    Bullet.transform.rotation = transform.rotation;
                    SHOT = true;
                }

                if (alt == -1)
                {
                    GameObject Bullet2 = Instantiate(Bullet1, shot_spots[1].transform.position, Quaternion.identity);
                    Bullet2.transform.rotation = transform.rotation;
                    SHOT = true;
                }
            }
            time = 0;
        }
    }

    private void Move_Input()
    {
        y_move = Input.GetAxisRaw("Vertical");
        x_move = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(x_move, y_move, 0) * speed * Time.fixedDeltaTime;
    }
}
