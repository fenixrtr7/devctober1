using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    // Limites de pantalla
    public float xMin, xMax, yMin, yMax;
}

public class CarControllerM : MonoBehaviour
{
    [SerializeField] float speed/* , distanceY*/;
    public Boundary boundary;
    Rigidbody2D rbd;
    float moveHorizontal, moveVertical;
    public UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            // Movimiento carro
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");


            //Vector2 movement = new Vector2(moveHorizontal, distanceY);
            rbd.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);

            // Limites donde se puede mover
            rbd.position = new Vector2(Mathf.Clamp(rbd.position.x, boundary.xMin, boundary.xMax),
                                        Mathf.Clamp(rbd.position.y, boundary.yMin, boundary.yMax));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("CarEnemy"))
        {
            uIManager.panelGameOver.SetActive(true);
            GameManager.sharedInstance.GameOver();
            this.gameObject.SetActive(false);
        }
    }

    // private void OnTriggerEnter2D(Collider2D other) {

    // }
}