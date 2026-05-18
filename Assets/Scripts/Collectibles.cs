using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int score = 1;
    void OnCollisionEnter(Collision collision)
    {
        print("Player collided with " + collision.gameObject.name);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
