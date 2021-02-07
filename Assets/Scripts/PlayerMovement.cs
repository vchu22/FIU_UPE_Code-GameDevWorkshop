using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed, jumpHeight;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.W)) {
        GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpHeight);
      }
      if (Input.GetKey(KeyCode.A)) {
        // Goes left
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-maxSpeed/4, 0), ForceMode2D.Force);
      }
      if (Input.GetKey(KeyCode.D)) {
        // Goes right
        GetComponent<Rigidbody2D>().AddForce(new Vector2(+maxSpeed/4, 0), ForceMode2D.Force);
      }
    }
}
