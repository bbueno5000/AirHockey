using MLAgents;
using System.Collections.Generic;
using UnityEngine;

public class StrikerDecision : MonoBehaviour, Decision
{
    public Rigidbody agentRb;
    public Rigidbody puckRb;

    public float[] Decide(
        List<float> vectorObs, List<Texture2D> visualObs,
        float reward, bool done, List<float> memory) {

        return new float[2] {
            puckRb.transform.position.x - agentRb.transform.position.x,
            puckRb.transform.position.z - agentRb.transform.position.z
        };
    }

    public List<float> MakeMemory(
        List<float> vectorObs, List<Texture2D> visualObs,
        float reward, bool done, List<float> memory) {

        return new List<float>();
    }
}
