using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    Checkpoint[] checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = GetComponentsInChildren<Checkpoint>();
    }

    public Checkpoint GetLastCheckpointThatWasPassed()
    {
        return checkpoints.LastOrDefault(t => t.Passed);
    }
}
