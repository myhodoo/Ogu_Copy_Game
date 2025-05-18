using UnityEngine;

public class KnifePos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Knife.SetActive(false);
    }

    public Animator m_Animator = null;
    public GameObject Knife = null;
    void K_Move()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            //p(0.15, 0, -0.15)
            //r(0, 0, -41)
            Knife.SetActive(true);
            m_Animator.SetBool("RightHit", true);
            Knife.transform.position = new Vector3(0.15f, 0f, -0.15f);
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
