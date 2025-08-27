using UnityEngine;

public class PearlState : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Pearl;
    [SerializeField] GameObject PearlPlaceholder;
    [SerializeField] Timer timerScript;
    public bool isHeld;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Player)
        {
            //timerScript.StartTimer();
            //Destroy(Pearl);
            isHeld = true;
        }
    }

    private void Update()
    {
        if (isHeld)
        {
            Pearl.transform.position = PearlPlaceholder.transform.position;
        }
    }
}
