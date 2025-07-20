using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailScenes : MonoBehaviour
{
    public Image Failbackground = null;
    public GameObject FailButton = null;
    public TargetFollow m_lifeheart = null;
    void Start()
    {
        Failbackground.GetComponent<Image>().enabled = false;
        FailButton.SetActive(false);
        //FailButton.GetComponent<Button>().enabled = false;
        Time.timeScale = 1f;
    }
    public void Dead()
    {
        if (m_lifeheart.lifeheart.rectTransform.sizeDelta.x <= 0)
        {
            Failbackground.GetComponent<Image>().enabled = true;
            FailButton.SetActive(true);
            //FailButton.GetComponent<Button>().enabled = true;
            Time.timeScale = 0f;
        }
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("BattleScene");
        
    }
    
    void Update()
    {
        
            Dead();
        
    }
}
