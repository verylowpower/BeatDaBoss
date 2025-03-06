using UnityEngine;

public class RangeDectector : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] public float detectionRadius = 10.0f;
    [SerializeField] private LayerMask detectionMark;
    [SerializeField] private bool showDebugVisual = true;

    public GameObject DectectedTarget
    {
        get;
        set;
    }

    public GameObject UpdateDetector()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, detectionRadius, detectionMark);

        if (collider2Ds.Length > 0)
        {
            DectectedTarget = collider2Ds[0].gameObject;
        }
        else
        {
            DectectedTarget = null;
        }

        return DectectedTarget;
    }

    public void OnDrawGizmos()
    {
        if (!showDebugVisual || this.enabled == false) return;

        Gizmos.color = DectectedTarget ? Color.green : Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }


}
