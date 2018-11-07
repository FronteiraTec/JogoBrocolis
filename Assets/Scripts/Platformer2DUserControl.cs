using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace JogoBrocolis.FTec
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Chomp;	 	 


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()	
        {

            if(!m_Chomp)
            {
                m_Chomp = CrossPlatformInputManager.GetButtonDown("Chomp");
            }

            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
			      //in m_Character 1 equals player is always moving forward, false means player cant crouch
            m_Character.Move(1, false, m_Jump, m_Chomp);
            m_Jump = false;
            m_Chomp = false;
        }
    }
}
