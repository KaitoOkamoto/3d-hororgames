using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField] float m_amplitude = 1f;
    Vector3 m_intialPos;
    [SerializeField] float m_timeSpeed = 1f;
    

    void Start()
    {
        m_intialPos = this.transform.position;
    }

    void Update()
    {
        //this.transform.position = m_intialPos + m_amplitude * Mathf.Sin(Time.time) * Vector3.right+ m_amplitude * Mathf.Cos(Time.time) * Vector3.up; //回転床
        this.transform.position = m_intialPos + m_amplitude * Mathf.Sin(Time.time) * Vector3.forward; //　Z軸の正方向に移動
    }
}