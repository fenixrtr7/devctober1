using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemy : MonoBehaviour
{
    public float speed, distanceX;

    Rigidbody2D rbd;

    float moveVertical = 1;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(distanceX, moveVertical);
        rbd.velocity =  new Vector2(distanceX, movement.y * speed);
    }
    // public void MoreDificult()
    // {
    //     speed += 0.1f;
    // }
}
