using UnityEngine;

public class PearlState : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Pearl;
    [SerializeField] Timer timerScript;
    public bool isDestroyed;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Player)
        {
            //timerScript.StartTimer();
            Destroy(Pearl);
            isDestroyed = true;
        }
    }
}
