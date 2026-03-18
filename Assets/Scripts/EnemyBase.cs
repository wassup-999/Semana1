using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int Range=10;
    public bool VerifyArea = false;
    public Transform Player;
    public float speed = 2.5f;
    void Start()
    {       
        GetComponent<SphereCollider>().radius = Range;
        GetComponent<Player>();

    }

    
    void Update()
    {
        FollowPlayer();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {        
            VerifyArea = true;
            Player =  other.gameObject.transform;          
            print("Detected");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VerifyArea = false;
            Player = null;
            print("not Detected");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            print("Enemy Destroyed");
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
        Gizmos.color = Color.green;
        if (VerifyArea)
        {
            Gizmos.DrawLine(transform.position, Player.transform.position);
        }       
    }
    public void FollowPlayer()
    {
        if (VerifyArea)
        {     
            Vector3 dir = (Player.transform.position - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;          
        }
    }

}
