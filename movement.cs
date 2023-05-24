using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class movement : MonoBehaviour {

    // player speed.
    public float speed = 10.4f;
    
    // vars.
    bool can_jump_again = false;

    bool died = false;

    // rigidbody.
    public Rigidbody2D rigid_body;

    // sprite we will be transforming.
    public Transform rotation_sprite;

    // Start is called before the first frame update
    void Start() {
        rigid_body = GetComponent<Rigidbody2D>();
    }

     void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            can_jump_again = true;
        }
        else if(collision.gameObject.tag == "spike") {

            died = true;
        }
        else if( collision.gameObject.tag == "box") {

            // store player pos, box pos, and box width as well as height.
            Vector2 player_position = transform.position;
            Vector2 box_position = collision.transform.position;
            float box_width = collision.collider.bounds.size.x;
            float box_height = collision.collider.bounds.size.y;

            // calc left edge and center of box.
            float left_edge = box_position.x - box_width / 2f;
            float box_center = box_position.y;
            
            // check if the player collides with the center of the left side of the box.
            if (player_position.x < left_edge && player_position.y <= box_center + box_height / 2f && player_position.y >= box_center - box_height / 2f)
            {
                died = true;
            }
            else
            {
                can_jump_again = true;
            }
        }
    }

    // Update is called once per frame
    void Update() {

        // player died, do some stuff.
        if(died) {
            
            // indicate that we are alive again.
            died = false;

            // reset the scene.
            // find other way to respawn player.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // clamp y velocity
        if(rigid_body.velocity.y < -24.2f) 
            rigid_body.velocity = new Vector2 (rigid_body.velocity.x, -24.2f);

            if(can_jump_again) {

                // store current rotation angle.
                Vector3 current_angle = rotation_sprite.rotation.eulerAngles;

                // round the z angle to the nearest 90 degrees.
                current_angle.z = Mathf.Round(current_angle.z / 90) * 90;

                // set the rotation angle.
                rotation_sprite.rotation = Quaternion.Euler(current_angle);

                // jump on spacebar.
                if(Input.GetKey(KeyCode.Space)) {

                    rigid_body.velocity = Vector2.zero;
                    rigid_body.AddForce(Vector2.up * 26.6581f, ForceMode2D.Impulse);
                    can_jump_again = false;    
            }
        }
        else { 
            // rotate sprite.
            rotation_sprite.Rotate(Vector3.back * 450f * Time.deltaTime );
        }
    }
}