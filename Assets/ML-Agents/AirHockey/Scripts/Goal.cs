using MLAgents;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public AirHockeyAgent3D airHockeyAgent;
    public Rigidbody puckRb;
    public Text text;

    private void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "puck")
        {
            airHockeyAgent.GoalScored();
            text.text = airHockeyAgent.Score().ToString();
            airHockeyAgent.AddReward(1f);
            puckRb.position = new Vector3(-4, 0, 0);
            puckRb.velocity = new Vector3(0, 0, 0);
        }
    }
}
