using UnityEngine;

public class ArmAgent : AirHockeyAgent3D
{
    public GameObject upperArm;
    public GameObject lowerArm;
    public GameObject hand;
    public GameObject goal;
    public GameObject puck;
    // hidden
    private AirHockeyAcademy academy;
    protected float goalDegree;
    private float goalSize;
    protected float goalSpeed;
    protected Rigidbody lowerArmRb;
    private Rigidbody puckRb;
    private Rigidbody upperArmRb;

    public override void AgentAction (float[] vectorAction, string textAction)
	{
        goalDegree += goalSpeed;

        lowerArmRb.AddTorque(
            new Vector3(
                Mathf.Clamp(vectorAction[0], -1f, 1f) * 100f,
                0f, Mathf.Clamp(vectorAction[1], -1f, 1f) * 100f));
    }

    /// <summary>
    /// Resets the position and velocity of the agent and the goal.
    /// </summary>
    ///
    public override void AgentReset ()
    {
        // upperArm.transform.position = new Vector3(
        //     0f, -4f, 0f) + this.transform.position;
        // upperArm.transform.rotation = Quaternion.Euler(180f, 0f, 0f);
        // upperArmRb.velocity = new Vector3(0, 0, 0);
        // upperArmRb.angularVelocity = new Vector3(0, 0, 0);
        // // lower arm
        // lowerArm.transform.position = new Vector3(
        //     0f, -10f, 0f) + this.transform.position;
        // lowerArm.transform.rotation = Quaternion.Euler(180f, 0f, 0f);
        // lowerArmRb.velocity = new Vector3(0, 0, 0);
        // lowerArmRb.angularVelocity = new Vector3(0, 0, 0);
        // goal
        goalDegree = Random.Range(0, 360);
        goalSize = academy.goalSize;
        goalSpeed = Random.Range(-1f, 1f) * academy.goalSpeed;
        goal.transform.localScale = new Vector3(goalSize, goalSize, goalSize);
        score = 0;
    }

    /// <summary>
    /// We collect the normalized rotations,
    /// angularal velocities, and velocities of both
    /// limbs of the reacher as well as
    /// the relative position of the target and hand.
    /// </summary>
    ///
    public override void CollectObservations ()
    {
        AddVectorObs(upperArm.transform.localPosition);
        AddVectorObs(upperArm.transform.rotation);
        AddVectorObs(upperArmRb.angularVelocity);
        AddVectorObs(upperArmRb.velocity);
        // lower arm
        AddVectorObs(lowerArm.transform.localPosition);
        AddVectorObs(lowerArm.transform.rotation);
        AddVectorObs(lowerArmRb.angularVelocity);
        AddVectorObs(lowerArmRb.velocity);
        // goal
        AddVectorObs(goal.transform.localPosition);
        AddVectorObs(hand.transform.localPosition);
        AddVectorObs(goalSpeed);
        // puck
        AddVectorObs(puck.transform.position.x);
        AddVectorObs(puck.transform.position.y);
        AddVectorObs(puckRb.velocity.x);
        AddVectorObs(puckRb.velocity.y);
	}

    /// <summary>
    /// Collect the rigidbodies of the reacher
    /// in order to resue them for observations and actions.
    /// </summary>
    ///
    public override void InitializeAgent ()
    {
        academy = GameObject.Find("Academy").GetComponent<AirHockeyAcademy>();
        upperArmRb = upperArm.GetComponent<Rigidbody>();
        lowerArmRb = lowerArm.GetComponent<Rigidbody>();
        puckRb = puck.GetComponent<Rigidbody>();
    }
}
