using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ground_movement : MonoBehaviour
{
    // var for if the player has won.
    public bool player_has_won = false;

    // var for travel distance.
    float travel_distance = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform our position using our current pos += Vector3.left * speed.
        transform.position += Vector3.left * 10.4f * Time.deltaTime;

        // Update the distance traveled by the ground
        travel_distance += 10.4f * Time.deltaTime;

        // we have traveled more than 75 units(about half of the current map length), player wins.
        if (travel_distance > 75f) {

           player_has_won = true;
        }

        if(player_has_won) {

            // reload the scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
