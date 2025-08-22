using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailScenes : MonoBehaviour
{
    public Image Failbackground = null;
    public GameObject FailButton = null;
    public TargetFollow m_lifeheart = null;

    private bool ISDead = false;

    void Start()
    {
        Failbackground.GetComponent<Image>().enabled = false;
        FailButton.SetActive(false);
        Time.timeScale = 1f;
    }

    //public void Dead()
    //{
    //    if (m_lifeheart.lifeheart.rectTransform.sizeDelta.x <= 0)
    //    {
    //        Failbackground.GetComponent<Image>().enabled = true;
    //        FailButton.SetActive(true);
    //        Time.timeScale = 0f;
    //    }
    //}

    IEnumerator showfailscreen()
    {
        Debug.Log("ShowFailScreen 호출됨");
        Failbackground.GetComponent<Image>().enabled = true;
        FailButton.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        //Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BattleScene");
    }

    void Update()
    {
        if ( m_lifeheart.lifeheart.rectTransform.sizeDelta.x <= 0)
        {
            Debug.Log("현재 체력바 길이: " + m_lifeheart.lifeheart.rectTransform.sizeDelta.x);

            ISDead = true;
            StartCoroutine(showfailscreen());
        }
    }
}
