using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    /// <summary>ゲームオーバー時に表示するパネル</summary>
    Animator m_gameoverPanel = null;
    [SerializeField] PlayerController m_player;
    [SerializeField] float m_loadscenetime = 2f;
    [SerializeField] Image m_fadePanel = null;

    // Start is called before the first frame update

    /// <summary>
    /// ゲームをやり直す
    /// </summary>
    public void Restart()
    {
        Debug.Log("Restart");
        Start();
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    void Gameover()
    {
        Debug.Log("Gameover");
        // ゲームオーバーになったことを表示する
        m_gameoverPanel.gameObject.SetActive(true);
        m_gameoverPanel.Play("Show");
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

    //ゴール時に表示するテキスト
    public GameObject GoalText;

    void Start()
    {
        GoalText.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GoalText.SetActive(true);
            m_player.isPlayerOperation = false;
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(m_loadscenetime);
        SceneManager.LoadScene("GameScene");
    }
}
