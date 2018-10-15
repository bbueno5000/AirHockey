using MLAgents;
using UnityEngine;
using UnityEngine.UI;

public class AirHockeyAgent2D : Agent
{
    public bool invertX;
    public Rigidbody2D agentRB;
    public GameObject puck;
    public Rigidbody2D puckRB;
    public Text textComponent;
    public int score;
    private float invertMult;

    public override void AgentAction (float[] vectorAction, string textAction)
    {
        var moveX = Mathf.Clamp(vectorAction[0], -1f, 1f) * invertMult;
        var moveY = Mathf.Clamp(vectorAction[1], -1f, 1f);

        agentRB.velocity = new Vector3(moveX * 30f, moveY * 30f, 0f);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, invertX ? -4f: 1f, invertX ? -1f: 4f),
            Mathf.Clamp(transform.position.y, -2, 2),
            transform.position.z);

        textComponent.text = score.ToString();
    }

    public override void AgentReset ()
    {
        invertMult = invertX ? -1f: 1f;
        transform.position = new Vector3(invertMult * 3f, 0f, 0f);
        agentRB.velocity = new Vector3(0f, 0f, 0f);
    }

    public override void CollectObservations ()
    {
        AddVectorObs(transform.position.x);
        AddVectorObs(transform.position.y);
        AddVectorObs(agentRB.velocity.x);
        AddVectorObs(agentRB.velocity.y);
        // puck info
        AddVectorObs(puck.transform.position.x);
        AddVectorObs(puck.transform.position.y);
        AddVectorObs(puckRB.velocity.x);
        AddVectorObs(puckRB.velocity.y);
    }
}
