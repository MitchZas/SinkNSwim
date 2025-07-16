using UnityEngine;

public class BubblePop : MonoBehaviour
{
    public AudioSource bubblePopAudio;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Clam" || other.gameObject.tag == "Bubble")
        {
            bubblePopAudio.Play();
        }
    }
}
