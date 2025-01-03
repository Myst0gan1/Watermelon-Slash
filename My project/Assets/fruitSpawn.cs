using System.Collections;
using UnityEngine;

public class fruitSpawn : MonoBehaviour
{
    public GameObject fruit;
    public Transform[] spawnPoints;
    public float minDelay=.1f;
    public float maxDelay=1f;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnF());
    }

    IEnumerator spawnF(){
        while(true){
            float delay= Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex=Random.Range(0, spawnPoints.Length);
            Transform spawnP=spawnPoints[spawnIndex];

           GameObject spawnedFruit= Instantiate(fruit, spawnP.position, spawnP.rotation);
           Destroy(spawnedFruit, 3f);
        }
    }
}
