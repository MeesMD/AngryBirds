using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour {

    public float forceNeeded;

    float collisionForce(Collision2D collider)
    {
        // Estimate a collision's force (speed * mass)
        float speed = collider.relativeVelocity.sqrMagnitude;
        if (collider.collider.GetComponent<Rigidbody2D>())
        {
            return speed * collider.collider.GetComponent<Rigidbody2D>().mass;
        } 
        return speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionForce(collision) > forceNeeded)
            Destroy(gameObject);
    }
}
