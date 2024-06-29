using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private ColorHandler m_ColorHandler;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_ColorHandler= GetComponent<ColorHandler>();
        switch (SettingsManager.Instance.BallColor)
        {
            case SettingsUIHandler.BallColor.RED:
                m_ColorHandler.SetColor(Color.red);
                break;
            case SettingsUIHandler.BallColor.GREEN:
                m_ColorHandler.SetColor(Color.green);
                break;
            case SettingsUIHandler.BallColor.BLUE:
                m_ColorHandler.SetColor(Color.blue);
                break;

        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        float speed = MainManager.GetSpeedByDifficulty();
        var velocity = m_Rigidbody.velocity;
        
        //after a collision we accelerate a bit
        velocity += velocity.normalized * 0.01f;
        
        //check if we are not going totally vertically as this would lead to being stuck, we add a little vertical force
        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.4f)
        {
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        }

        //max velocity
        if (velocity.magnitude > 3.0f * speed)
        {
            velocity = velocity.normalized * 3.0f * speed;
        }

        m_Rigidbody.velocity = velocity;    
    }
}
