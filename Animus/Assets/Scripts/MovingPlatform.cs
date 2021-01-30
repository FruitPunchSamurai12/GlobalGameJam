using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform start;
    [SerializeField]
    private Transform end;
    [SerializeField]
    private Transform platformSprite;
    [SerializeField]
    private float speed = 6f;

    float positionPercent;
    int direction = 1;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(start.position, end.position);
        float speedForDistance = speed / distance;

        positionPercent += Time.deltaTime * direction * speedForDistance;
        platformSprite.position = Vector3.Lerp(start.position, end.position, positionPercent);
        if (positionPercent >= 1 && direction == 1)
        {
            direction = -1;
        }
        else if (positionPercent <= 0 && direction == -1)
        {
            direction = 1;
        }
    }

}
