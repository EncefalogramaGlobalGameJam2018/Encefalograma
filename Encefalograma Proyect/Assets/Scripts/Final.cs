using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {

    public Player m_player;
    private GameObject m_pepe_exito;
    private GameObject m_pepe_iddle_eye;
    public float umbral;

    private float m_points;

    private void Start()
    {
        m_pepe_exito = GameObject.FindGameObjectWithTag("AnimaExito");
        m_pepe_iddle_eye = GameObject.FindGameObjectWithTag("AnimaFracaso");
        m_pepe_exito.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_points = m_player.getCurrentPoints();

        if (m_points >= umbral)
        {
            //Animacion bien
            m_pepe_iddle_eye.SetActive(false);
            m_pepe_exito.SetActive(true);
            m_pepe_exito.GetComponent<UnityArmatureComponent>().animation.FadeIn("animtion0",-1f,-1);
        }
        else
        {
            //Animacion mal
            m_pepe_iddle_eye.GetComponent<UnityArmatureComponent>().animation.FadeIn("ojito",-1f,-1);
        }
        Invoke("final", 3);
    }

    private void final()
    {
        m_player.setCeroPoints();
        SceneManager.LoadScene(0);
    }
}
