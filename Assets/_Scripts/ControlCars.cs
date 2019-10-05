using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCars : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("CarEnemy"))
        {
            Destroy(other.gameObject);
            Debug.Log("Carro destruido");
        }
    }
}
