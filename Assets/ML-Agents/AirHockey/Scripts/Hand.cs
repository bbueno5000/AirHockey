using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject agent;
    public GameObject goal;

    private void OnTriggerStay (Collider collision)
    {
        if (collision.gameObject == goal)
        {
            agent.GetComponent<ReacherAgent>().AddReward(0.01f);
        }
    }
}
