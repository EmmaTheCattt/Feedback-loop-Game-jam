using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_script : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor_placement();
    }

    private void Cursor_placement()
    {
        Vector2 mouseposition = Input.mousePosition;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
        Cursor.visible = false;
        transform.position = mouseposition;
    }
}
