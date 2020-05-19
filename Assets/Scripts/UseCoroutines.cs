using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCoroutines : MonoBehaviour
{
    public GameObject EnemyPrefub;
    public GameObject Asteroid;
    void Start()
    {
        StartCoroutine(CloneEnemyPrefub());
        StartCoroutine(CloneAsteroidPrefub());
    }

    IEnumerator CloneEnemyPrefub()
    {
        while (true)
        {
            Instantiate(EnemyPrefub, new Vector3(Random.Range(-7.88f, 8.01f), 6.38f, 0), Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
        }
    }
    IEnumerator CloneAsteroidPrefub()
    {
        while (true)
        {
            Instantiate(Asteroid, new Vector3(9.2f, Random.Range(-4.08f, 3.82f), 0), Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
        }
    }
}
