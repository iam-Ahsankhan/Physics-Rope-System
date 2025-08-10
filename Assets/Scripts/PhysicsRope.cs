using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PhysicsRope : MonoBehaviour
{
    [Header("Rope Settings")]
    public Transform startPoint; // Rope anchor
    public Transform endPoint;   // Rope end object
    public int segmentCount = 10;
    public float segmentLength = 0.5f;
    public float ropeWidth = 0.05f;

    [Header("Physics")]
    public float massPerSegment = 0.1f;
    public float spring = 1000f;
    public float damper = 5f;

    private LineRenderer lineRenderer;
    private Rigidbody[] segments;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;
        CreateRope();
    }

    void CreateRope()
    {
        segments = new Rigidbody[segmentCount];
        Vector3 ropeDir = (endPoint.position - startPoint.position).normalized;

        Transform prevSegment = startPoint;

        for (int i = 0; i < segmentCount; i++)
        {
            GameObject seg = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            seg.name = "RopeSegment_" + i;
            seg.transform.localScale = new Vector3(ropeWidth, segmentLength / 2f, ropeWidth);
            seg.transform.position = startPoint.position + ropeDir * segmentLength * (i + 1);

            Rigidbody rb = seg.AddComponent<Rigidbody>();
            rb.mass = massPerSegment;

            HingeJoint joint = seg.AddComponent<HingeJoint>();
            joint.connectedBody = prevSegment.GetComponent<Rigidbody>();
            joint.axis = Vector3.right;
            joint.useSpring = true;
            JointSpring js = new JointSpring();
            js.spring = spring;
            js.damper = damper;
            joint.spring = js;

            segments[i] = rb;
            prevSegment = seg.transform;
        }

        // Attach last segment to endPoint object
        HingeJoint endJoint = segments[segmentCount - 1].gameObject.AddComponent<HingeJoint>();
        endJoint.connectedBody = endPoint.GetComponent<Rigidbody>();
        endJoint.axis = Vector3.right;
    }

    void Update()
    {
        if (segments == null) return;

        lineRenderer.positionCount = segmentCount + 2;
        lineRenderer.SetPosition(0, startPoint.position);

        for (int i = 0; i < segmentCount; i++)
        {
            lineRenderer.SetPosition(i + 1, segments[i].position);
        }

        lineRenderer.SetPosition(segmentCount + 1, endPoint.position);
    }
}
