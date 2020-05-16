using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCoroutines : MonoBehaviour
{
    public GameObject EnemyPrefub;
    void Start()
    {
        StartCoroutine(CloneEnemyPrefub());
    }

    IEnumerator CloneEnemyPrefub()
    {
        while (true)
        {
            Instantiate(EnemyPrefub, new Vector3(Random.Range(-7.88f, 8.01f), 6.38f, 0), Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
        }
    }
}
