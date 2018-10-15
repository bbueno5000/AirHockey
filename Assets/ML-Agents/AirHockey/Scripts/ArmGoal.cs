using UnityEngine;

public class ArmGoal : MonoBehaviour
{
    public GameObject goalOn;
    public GameObject hand;

    private void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject == hand)
        {
            goalOn.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnTriggerExit (Collider collision)
    {
        if (collision.gameObject == hand)
        {
            goalOn.transform.localScale = new Vector3(0f, 0f, 0f);
        }
    }
}
