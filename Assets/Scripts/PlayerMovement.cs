using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public SoundManagerScript manager;
    public float maxSpeed, jumpHeight;

    void Start()
    {
      manager = GetComponent<SoundManagerScript>();
    }
    void Update()
    {
      animator.SetFloat("walkingSpeed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
      if (Input.GetKeyDown(KeyCode.W)) {
        if (Physics2D.IsTouchingLayers(GetComponent<Collider2D>())){
          manager.Play("jump");
          GetComponent<Rigidbody2D>().velocity += new Vector2(0, jumpHeight);
        }
      }
      if (Input.GetKey(KeyCode.A)) {
        // Goes left
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-maxSpeed/4, 0), ForceMode2D.Force);
        GetComponent<Rigidbody2D>().transform.rotation = new Quaternion(0, 180, 0, 9);
      }
      if (Input.GetKey(KeyCode.D)) {
        // Goes right
        GetComponent<Rigidbody2D>().AddForce(new Vector2(+maxSpeed/4, 0), ForceMode2D.Force);
        GetComponent<Rigidbody2D>().transform.rotation = new Quaternion(0, 0, 0, 9);
      }
    }

    void FixedUpdate() 
    {
      Rigidbody2D player = GetComponent<Rigidbody2D>();
      if (player.velocity.x > maxSpeed) {
        // CAP
        player.velocity = new Vector2(maxSpeed, player.velocity.x);
      } else if (player.velocity.x < -maxSpeed) {
        player.velocity = new Vector2(maxSpeed, player.velocity.y);
      }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      Debug.Log("Tag " + other.tag);
      
      if (other.tag == "coin") {
        Destroy(other.gameObject);
        GetComponent<SoundManagerScript>().Play("coin");
      }
    }
}
