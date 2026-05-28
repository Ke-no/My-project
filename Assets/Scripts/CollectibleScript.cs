using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public int collectibleScore = 0;

    AudioSource collectibleAudio;

    void Start()
    {
        collectibleAudio = GetComponent<AudioSource>();
    }

    public void Collect()
    {
        if(collectibleAudio != null)
        {
            collectibleAudio.Play();
            // Solution 1
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

        Destroy(gameObject, collectibleAudio.clip.length);
        }
        // Solution 2
        //AudioSource.PlayClipAtPoint();
    }
}
