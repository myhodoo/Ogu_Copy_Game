using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float MoveSpeed = 5f;

    void Move1()
    {
        float xx = Input.GetAxis("Horizontal");
        float yy = Input.GetAxis("Vertical");

        //if (xx > 0)
        //    xx = 1;

        //if (xx < 0)
        //    xx = -1;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            xx = 1;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            xx = -1;


        Vector2 pos = transform.position;
        pos.x += xx * MoveSpeed * Time.deltaTime;
        pos.y += yy * MoveSpeed * Time.deltaTime;

        this.transform.position = pos;
    }

    void Update()
    {
        Move1();
    }
}
