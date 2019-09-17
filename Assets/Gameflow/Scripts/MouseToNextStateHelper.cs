using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameflow
{
    public class MouseToNextStateHelper : MonoBehaviour
    {
        public bool isDoubleClickToNext;
        public float doubleClickTime = .5f;
        float prevLClickTime, prevRClickTime;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isDoubleClickToNext)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Time.time - prevLClickTime <= doubleClickTime)
                    {
                        Gameflow.NextState();
                    }
                    prevLClickTime = Time.time;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    if (Time.time - prevRClickTime <= doubleClickTime)
                    {
                        Gameflow.PrevState();
                    }
                    prevRClickTime = Time.time;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Gameflow.NextState();
                }
                if (Input.GetMouseButtonDown(0))
                {
                    Gameflow.PrevState();
                }                
            }
        }
    }

}