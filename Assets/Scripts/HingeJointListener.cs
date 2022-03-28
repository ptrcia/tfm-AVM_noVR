//Hi guys, hope you enjoyed this video.Here is a little bonus for you.Bellow you will find a script that you can attached to any gameobject with an HingeJoint and that will trigger a particular Event when it reached its min or max limit.You can use it to trigger anything you want with the lever for example !! :)
//-------
using UnityEngine;
using UnityEngine.Events;

public class HingeJointListener : MonoBehaviour
{
    //angle threshold to trigger if we reached limit
    public float angleBetweenThreshold = 1f;
    //State of the hinge joint : either reached min or max or none if in between
    public HingeJointState hingeJointState = HingeJointState.None;

    //Event called on min reached
    public UnityEvent OnMinLimitReached;
    //Event called on max reached
    public UnityEvent OnMaxLimitReached;

    public enum HingeJointState { Min, Max, None }
    private HingeJoint hinge;
    //[SerializeField] private Transform player;
    //[SerializeField] private Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    private void FixedUpdate()
    {
        float angleWithMinLimit = Mathf.Abs(hinge.angle - hinge.limits.min);
        float angleWithMaxLimit = Mathf.Abs(hinge.angle - hinge.limits.max);
        //Debug.Log(angleWithMinLimit);
        //Reached Min
        if (angleWithMinLimit < angleBetweenThreshold)
        {
            if (hingeJointState != HingeJointState.Min)
                OnMinLimitReached.Invoke();

            hingeJointState = HingeJointState.Min;
        }
        //Reached Max
        else if (angleWithMaxLimit < angleBetweenThreshold)
        {
            if (hingeJointState != HingeJointState.Max)
                OnMaxLimitReached.Invoke();

            hingeJointState = HingeJointState.Max;
            //player.transform.position = respawnPoint.transform.position;
        }
        //No Limit reached
        else
        {
            hingeJointState = HingeJointState.None;
        }
    }
}