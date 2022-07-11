using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolThenFollowTarget2D1 : MonoBehaviour
{
    public Transform patrollerTR;
    [SerializeField]
    Transform target1;
    [SerializeField]
    Transform target2;
    [SerializeField] Transform targetPplayer;
    [SerializeField]
    float speed;
    Transform currentTarget;
    public bool toLeft = true;
    [SerializeField]
    private float distanceThreshold = 1f;
    public float direction;
    // Start is called before the first frame update
    void Start()
    {
        targetPplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (!target1)
        {
            target1 = targetPplayer;
        }
        currentTarget = target1;

    }

    // Update is called once per frame
    void Update()
    {
        direction= (patrollerTR.position.x - currentTarget.position.x);
        if (direction < 0)
        {
            patrollerTR.eulerAngles = Vector3.up * 180;
        }
        else
        {
            patrollerTR.eulerAngles = Vector3.down * 0;
        }

        var step = speed * Time.deltaTime;
        patrollerTR.position = Vector3.MoveTowards(patrollerTR.position, currentTarget.position, step);

        if (Vector2.Distance(patrollerTR.position,targetPplayer.position) < distanceThreshold)
        {
            currentTarget = targetPplayer;
        }
    }
}
