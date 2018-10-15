using MLAgents;
using UnityEngine;

public class AirHockeyAcademy : Academy
{
    public float goalSize;
    public float goalSpeed;
    public Rigidbody puckRb;

    public override void AcademyReset ()
    {
        goalSize = (float) resetParameters["goal_size"];
        goalSpeed = (float) resetParameters["goal_speed"];
        puckRb.position = new Vector3(-4, 0, 0);
        puckRb.velocity = new Vector3(0, 0, 0);
    }

    public override void AcademyStep ()
    {

    }
}
