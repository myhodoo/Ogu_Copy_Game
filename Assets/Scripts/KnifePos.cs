using UnityEngine;
using UnityEngine.U2D;

public class KnifePos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        m_Animator = GetComponent<Animator>();

        Knife.SetActive(false);

        
    }

    
    public Animator m_Animator = null;
    public GameObject Knife = null;
    void K_Move()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            //p(0.15, 0, 0.07)
            //r(0, 0, -41)
            Knife.SetActive(true);
            m_Animator.SetBool("RightHit", true);
            Knife.transform.localPosition = new Vector3(0.150000006f, 0, 0.07f);
        }
      
        else
        {
            m_Animator.SetBool("RightHit", false);
        }
    }

 

    // Update is called once per frame
    void Update()
    {
        K_Move();
    }
}
