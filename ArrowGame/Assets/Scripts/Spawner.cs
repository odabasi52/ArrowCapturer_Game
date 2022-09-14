using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] SpawnPoints;
    [SerializeField] GameObject Arrow;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            int chance = Random.Range(0, SpawnPoints.Length);

            switch(chance)
            {
                case 0:
                    Instantiate(Arrow, SpawnPoints[0].transform.position, Quaternion.Euler(0,0,0));
                    break;

                case 1:
                    Instantiate(Arrow, SpawnPoints[1].transform.position, Quaternion.Euler(0, 0, 90));
                    break;

                case 2:
                    Instantiate(Arrow, SpawnPoints[2].transform.position, Quaternion.Euler(0, 0, 180));
                    break;

                case 3:
                    Instantiate(Arrow, SpawnPoints[3].transform.position, Quaternion.Euler(0, 0, -90));
                    break;
            }
            yield return new WaitForSeconds(Random.Range(.5f, 2));
        }
    }
}
