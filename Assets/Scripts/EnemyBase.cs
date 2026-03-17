using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int Range=10;
    public bool VerifyArea = false;
    public Transform Player;
    
    void Start()
    {       
        GetComponent<SphereCollider>().radius = Range;
        GetComponent<Player>();

    }

    
    void Update()
    {       
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
}
