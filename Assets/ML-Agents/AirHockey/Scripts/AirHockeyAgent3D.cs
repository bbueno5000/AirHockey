using MLAgents;
using UnityEngine;

public class AirHockeyAgent3D : Agent
{
    public int score;

    public void GoalScored ()
    {
        score += 1;
    }

    public int Score ()
    {
        return score;
    }
}
