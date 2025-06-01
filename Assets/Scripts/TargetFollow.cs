using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    
    public Transform targetpos;
    public float MoveSpeed = 0.3f;
    public Transform cursorpos;

    void Start()
    {
        
        
    }

    void CursorFollow()
    {
        cursorpos.position = Vector2.MoveTowards(cursorpos.position, targetpos.position, MoveSpeed * Time.deltaTime);
    }

    void Update()
    {
        CursorFollow();
    }
}
