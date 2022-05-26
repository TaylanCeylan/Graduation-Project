using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] float speed;

    int nextPosIndex;
    Transform nextPos;

    void Start()
    {
        nextPos = positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveBetweenPositions();
    }

    void MoveBetweenPositions()
    {
        if (transform.position == nextPos.position)
        {
            nextPosIndex++;
            if (nextPosIndex >= positions.Length)
            {
                nextPosIndex = 0;
            }
            nextPos = positions[nextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
        }
    }
}
