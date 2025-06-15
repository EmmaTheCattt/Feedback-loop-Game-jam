using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_script : MonoBehaviour
{
    public SpriteRenderer SR;
    public Color[] Cursor_colors;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor_placement();
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (Bullet.num_cursor != -1)
        {
            SR.color = Cursor_colors[Bullet.num_cursor];
        }
    }

    private void Cursor_placement()
    {
        Vector2 mouseposition = Input.mousePosition;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
        Cursor.visible = false;
        transform.position = mouseposition;
    }
}
