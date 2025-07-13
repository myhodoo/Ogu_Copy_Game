using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        float zplayer = transform.position.z;
        zplayer = -2.0f;
        transform.position = new Vector3(transform.position.x, transform.position.y, zplayer);

    }

    public float MoveSpeed = 5f;
    public Animator m_Animator = null;
    public GameObject Character;


    void Move1()
    {
        float xx = Input.GetAxis("Horizontal");
        float yy = Input.GetAxis("Vertical");

        
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




    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"tta : {this.gameObject.tag}, {collision.gameObject.tag}");
        
    }


    void Update()
    {
        Move1();
       
    }
}
