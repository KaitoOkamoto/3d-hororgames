using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartManager : MonoBehaviour
{
    //[SerializeField] PlayableDirector m_director = null;
    [SerializeField] GameObject m_startCanvas = null;
    [SerializeField] float m_loadscenetime = 2f;
    [SerializeField] Image m_fadePanel = null;


    // Update is called once per frame
    public void OnPanel()
    {
        m_startCanvas.SetActive(true);
    }

    public void OnClickStartButton()
    {
        StartCoroutine(LoadScene());

        Sequence s = DOTween.Sequence();
        s.Append(DOTween.ToAlpha(
            () => m_fadePanel.color,
            color => m_fadePanel.color = color,
            1f,
            2f));
        s.Play();
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(m_loadscenetime);
        SceneManager.LoadScene("GameScene");
    }

}
