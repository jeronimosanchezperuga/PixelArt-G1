using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndSwitchTargets : MonoBehaviour
{
    public Transform followerTR;
    [SerializeField]
    Transform target1;
    [SerializeField]
    Transform target2;
    [SerializeField]
    float speed;
    Transform currentTarget;
    public bool followTarget1 = true;
    public bool targetIsLeft = false;
    [SerializeField]
    private float distanceThreshold = 1f;

    void Start()
    {
        
    }

    void Update()
    {

        bool targetIsLeftLastValue = targetIsLeft;
        targetIsLeft = target1.transform.position.x < transform.position.x ?  true : false;
        currentTarget = followTarget1 ? target1 : target2;   

        var step = speed * Time.deltaTime;
        followerTR.position = Vector3.MoveTowards(followerTR.position, currentTarget.position, step);

        if (targetIsLeft != targetIsLeftLastValue)
        {
            int direction = targetIsLeft ? 1 : -1;
            followTarget1 = false;
            target2.position = new Vector2(transform.position.x + Random.Range(1,1) * direction, transform.position.y + Random.Range(-1, 1));
        }
        if (!followTarget1 && Vector2.Distance(followerTR.position, currentTarget.position) < distanceThreshold )
        {
            followTarget1 = true;
            //flip the sprite to face the other side
            followerTR.Rotate(0, 180, 0); 
        }
    }
}
