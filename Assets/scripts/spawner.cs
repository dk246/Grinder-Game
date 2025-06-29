using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject[] boxPrefabs;
    [SerializeField]private Transform spawnLocation;

    private int spawnIndex;
    private float timeToSpawn = 5;
    private int amount;

    private void Start()
    {
        amount = PlayerPrefs.GetInt("AmountNow");
        timeToSpawn = PlayerPrefs.GetFloat("spawn");

        if (amount == 0)
        {
            amount = 1;
        }
        if (timeToSpawn == 0)
        {
            timeToSpawn = 5;
        }

        StartCoroutine("spawning");


    }
    IEnumerator spawning()
    {

        amount = PlayerPrefs.GetInt("AmountNow");
        timeToSpawn = PlayerPrefs.GetInt("spawn");

        if (amount == 0)
        {
            amount = 1;
        }
        if(timeToSpawn == 0)
        {
            timeToSpawn = 5;
        }
        while (true)
        {
            spawnIndex = Random.Range(0, boxPrefabs.Length);
            for(int x=0; x< amount; x++)
            {
                GameObject.Instantiate(boxPrefabs[spawnIndex], spawnLocation);
            }
            
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
