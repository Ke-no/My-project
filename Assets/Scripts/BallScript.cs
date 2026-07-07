using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private float kickForce = 10f;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Interact(Transform player)
    {
        rb.AddForce(player.forward*kickForce, ForceMode.Impulse);
    }
}

