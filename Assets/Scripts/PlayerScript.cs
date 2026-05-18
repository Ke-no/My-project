using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    GameObject currentCollectible;
    
    int collCount = 0;

    public float collectDistance = 3.0f;

    void Update()
    {
        FindNearbyCollectible();
    }

    void FindNearbyCollectible()
    {
        currentCollectible = null;

        Collider[] nearby = Physics.OverlapSphere(transform.position, collectDistance);

        float closestDistance = Mathf.Infinity;
        
        foreach (Collider col in nearby)
        {
            if (col.CompareTag("Collectible"))
            {
                Vector3 directionToObject = (col.transform.position - transform.position).normalized;

                float dot = Vector3.Dot(transform.forward, directionToObject);
                
                if (dot > 0.5f)
                {
                    float distance = Vector3.Distance(transform.position, col.transform.position);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        currentCollectible = col.gameObject;
                    }
                }
            }
        }
    }

    void OnInteract()
    {
        if(currentCollectible != null)
        {
            Collectibles collectibleScript =
                currentCollectible.GetComponent<Collectibles>();
                
            if (currentCollectible != null)
            {
                collCount += collectibleScript.score;

                print("Player get " + collectibleScript.score + " point");
                print("Player now has " + collCount + " point");
                }
            //collCount++;
            //print("Player has collected " + collCount + " collectibles");
                Destroy(currentCollectible);
                currentCollectible = null;
        }
    }
    
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "GoalArea" && collCount >= 7)
    {
        print("Player entered trigger zone with " + collCount + " point");
    }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, collectDistance);
    }
}


