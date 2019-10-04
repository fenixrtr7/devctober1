using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisoCar : MonoBehaviour
{
    public GameObject imageAviso;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("CarEnemy"))
        {
            imageAviso.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("CarEnemy"))
        {
            imageAviso.SetActive(false);
        }
    }
}
