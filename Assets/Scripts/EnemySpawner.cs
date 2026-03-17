using NUnit.Framework;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Range = 10f;
    public float SpawnInterval = 2f;
    public bool EnableSpawn = false;
    public float counter;
    void Start()
    {
        GetComponent<SphereCollider>().radius = Range;
    }
    void Update()
    {
        
            if (EnableSpawn)
            {
                counter += Time.deltaTime;
            if (counter > SpawnInterval)
                {
                    SpawnEnemy();
                    counter = 0f;
                }
            }
           
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableSpawn = true;
            print("Player Entered");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableSpawn = false;
            print("Player Exit");
        }
    }
    public void SpawnEnemy()
    {
        if (EnableSpawn)
        {
            counter += Time.deltaTime;
            if (counter > SpawnInterval)
            {
                GameObject obj = Instantiate(EnemyPrefab, transform);
                obj.transform.position = new(0, 0, 0);
                Vector3 origin = transform.position;
                Vector3 dir = new Vector3(Random.Range(1f, -1f), 0, (Random.Range(1f, -1f))).normalized;
                Vector3 FinalPosition = origin + dir * Random.Range(0, Range);
                obj.transform.position = FinalPosition;               
            }
        }
    }
    public void SpawnLimit()
    {

    }
}
