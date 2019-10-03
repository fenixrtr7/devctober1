using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    // Limites de pantalla
    public float xMin, xMax;
}

public class CarControllerM : MonoBehaviour
{
    [SerializeField] float speed, distanceY;
    public Boundary boundary;
    Rigidbody2D rbd;
    float moveHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movimiento carro
        moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, distanceY);
        rbd.velocity = new Vector2 (movement.x * speed, distanceY);

        // Limites donde se puede mover
        rbd.position = new Vector2(Mathf.Clamp(rbd.position.x, boundary.xMin, boundary.xMax), distanceY);
    }
}