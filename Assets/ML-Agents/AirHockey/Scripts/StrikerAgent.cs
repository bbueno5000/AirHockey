using UnityEngine;
using UnityEngine.UI;

public class StrikerAgent : AirHockeyAgent3D
{
    public GameObject puck;
    public Text text;
    public bool invertX;
    private Rigidbody agentRb;
    private float invertMult;
    private Rigidbody puckRb;

    public override void AgentAction (float[] vectorAction, string textAction)
    {
        agentRb.velocity = new Vector3(
            Mathf.Clamp(vectorAction[0], -1f, 1f) * 30f * invertMult,
            0, Mathf.Clamp(vectorAction[1], -1f, 1f) * 30f);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, invertX ? -10f: 1f, invertX ? -1f: 10f),
            0, Mathf.Clamp(transform.position.z, -8f, 8f));
    }

    public override void AgentReset ()
    {
        invertMult = invertX ? -1f: 1f;
        transform.position = new Vector3(invertMult * 3f, 0f, 0f);
        agentRb.velocity = new Vector3(0f, 0f, 0f);
        score = 0;
    }

    public override void CollectObservations ()
    {
        AddVectorObs(transform.position.x);
        AddVectorObs(transform.position.y);
        AddVectorObs(agentRb.velocity.x);
        AddVectorObs(agentRb.velocity.y);
        // puck info
        AddVectorObs(puck.transform.position.x);
        AddVectorObs(puck.transform.position.y);
        AddVectorObs(puckRb.velocity.x);
        AddVectorObs(puckRb.velocity.y);
    }

    public override void InitializeAgent ()
    {
        agentRb = this.GetComponent<Rigidbody>();
        puckRb = puck.GetComponent<Rigidbody>();
    }
}
