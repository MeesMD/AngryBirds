using UnityEngine;
using System.Collections;

public class PullAndRelease : MonoBehaviour {
 
    Vector2 startPos;
    public float force = 1300;

   
    void Start ()
    {
        startPos = transform.position;    
    }

    void OnMouseUp()
    { 
        GetComponent<Rigidbody2D>().isKinematic = false;
       
        Vector2 dir = startPos - (Vector2)transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir * force);
        Destroy(this);
    }

    void OnMouseDrag()
    {        
        
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float radius = 1.8f;
        Vector2 dir = pos - startPos;
        if (dir.sqrMagnitude > radius)
        {
            dir = dir.normalized * radius;
        }
        transform.position = startPos + dir;
    }
}