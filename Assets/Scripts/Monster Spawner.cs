using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    //For creating copies of enemies/monsters
    private GameObject[] monsterReference;
    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters(){
        //While loop is used to call coroutine again and again to produce monsters continously
       while(true){
         yield return new WaitForSeconds (Random.Range(1,5));// This function is called after random interval between 1 and 5 seconds
        randomIndex = Random.Range(0,monsterReference.Length); //To spawn monsters but within monsterReference array range
        randomSide = Random.Range(0,2);
        spawnedMonster = Instantiate(monsterReference[randomIndex]); //This will craete copies of monsters
         
        //Running monsters from left side
        if(randomSide==0){
            spawnedMonster.transform.position = leftPos.position;
            spawnedMonster.GetComponent<Monster>().speed = Random.Range(4,10);
        }
        //Running monsters from right side
        else{
            spawnedMonster.transform.position = rightPos.position;
            spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4,10);
            spawnedMonster.transform.localScale = new Vector3(-1f,1f,1f); //For changing monster face direction towrds right
        }
       }
    }
}
