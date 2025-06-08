using System.Collections;
using UnityEditor.Purchasing;
using UnityEngine;

public class TargetFollowManager : MonoBehaviour
{

    public TargetFollow m_OrginalTarget = null;
    [SerializeField]
    protected PlayerMove m_PlayerMove = null;

    public float CreateDelaySec = 2f;


    void Start()
    {
        m_PlayerMove = GameObject.FindFirstObjectByType<PlayerMove>();

        m_OrginalTarget.gameObject.SetActive(false);

        StartCoroutine(CreateTargetFollow_Coroutinue());
    }


    void CreateFollowTarget()
    {
        var cloneobj = GameObject.Instantiate( m_OrginalTarget );
        cloneobj.gameObject.SetActive(true);

        cloneobj.transform.position = m_PlayerMove.transform.position;
        cloneobj.transform.localScale = new Vector3(3, 3, 3);


        //GameObject.Destroy(cloneobj, 20f);
    }
    IEnumerator CreateTargetFollow_Coroutinue()
    {

        while (true)
        {
            yield return new WaitForSecondsRealtime(2f); //�� �ʿ� �ѹ��� ������
            CreateFollowTarget();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
