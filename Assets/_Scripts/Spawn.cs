using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    float timeToSpawn, angulo = 0;
    public float minRandom = 1.8f, maxRandom = 5;
    public GameObject[] carPrefab;

    public bool carFall = false;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(InvokeCar());
    }

    public IEnumerator InvokeCar()
    {
        Debug.Log("Se invoca");
        yield return new WaitForSeconds(0.5f);
        
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            Debug.Log("Pasa condicion");
            timeToSpawn = Random.Range(minRandom, maxRandom);
            yield return new WaitForSeconds(timeToSpawn);

            if (carFall)
            {
                angulo = 180;
            }
            int numeroPrefab = Random.Range(0, carPrefab.Length);
            GameObject car = Instantiate(carPrefab[numeroPrefab], this.transform.position, Quaternion.Euler(0, 0, angulo));
            if (!carFall)
            {
                car.GetComponent<CarEnemy>().speed *= -1;
            }
            StartCoroutine(InvokeCar());
        }
    }
}
