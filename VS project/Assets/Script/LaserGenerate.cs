using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGenerate : MonoBehaviour
{
    [SerializeField] public float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer m_LineRenderer;
    Transform m_Transform;

    // Start is called before the first frame update
    void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }
    private void Update()
    {
        ShootLaser();  
    }

    void ShootLaser()
    {
        if(Physics2D.Raycast(m_Transform.position,transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position,transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point);
        }else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay); 
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_LineRenderer.SetPosition(0, startPos);
        m_LineRenderer.SetPosition(1, endPos);
    }
}
