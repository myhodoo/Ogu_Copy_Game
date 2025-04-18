using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public float MoveSpeed = 5f;
    public Animator m_Animator = null;

    void Move1()
    {
        float xx = Input.GetAxis("Horizontal");
        float yy = Input.GetAxis("Vertical");

        //if (xx > 0)
        //    xx = 1;

        //if (xx < 0)
        //    xx = -1;

        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            xx = -1;
            m_Animator.SetBool("LeftMove", true);
        }
        else
        {
            m_Animator.SetBool("LeftMove", false);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            xx = 1;
            m_Animator.SetBool("RightMove", true);
        }
        else
        {
            m_Animator.SetBool("RightMove", false);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            yy = 1;
            m_Animator.SetBool("UpMove", true);
        }
        else
        {
            m_Animator.SetBool("UpMove", false);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            yy = -1;
            m_Animator.SetBool("DownMove", true);
        }
        else
        {
            m_Animator.SetBool("DownMove", false);
        }

        if (xx != 0 || yy != 0)
        {
            m_Animator.SetFloat("MoveVal", 1f);
        }
        else
        {
            m_Animator.SetFloat("MoveVal", 0f);
        }


        Vector2 pos = transform.position;
        pos.x += xx * MoveSpeed * Time.deltaTime;
        pos.y += yy * MoveSpeed * Time.deltaTime;
        
        this.transform.position = pos;

        GetComponent<Rigidbody2D>().MovePosition(pos);
    }

    public LayerMask avb;

    void EndLineAttack()
    {
        //if()
        //{
            
        //}
    }


    void Update()
    {
        Move1();
    }
}
