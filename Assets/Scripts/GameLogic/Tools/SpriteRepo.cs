using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Resources.Code.Tools
{
    public class SpriteRepo:MonoBehaviour
    {
        private static SpriteRepo m_instance;
        public Sprite m_monkeySprite;
        public Sprite m_giraffeSprite;
      
 
   
        public static SpriteRepo Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = SceneObjectFinder<SpriteRepo>.FindGameObjectReturnT("SpriteRepo");
                    DontDestroyOnLoad(m_instance.gameObject);
                }
                return m_instance;
            }
            set { m_instance = value; }
        }

        public Sprite MMonkeySprite
        {
            get
            {
                if (m_monkeySprite == null)
                {
                    m_monkeySprite = UnityEngine.Resources.Load<Sprite>("Art/Sprites/Heads/MonkeyHead") ;
                }
                return m_monkeySprite;
            }
            set { m_monkeySprite = value; }
        }

        public Sprite MGiraffeSprite
        {
            get
            {
                if (m_giraffeSprite == null)
                {
                    m_giraffeSprite = UnityEngine.Resources.Load<Sprite>("Art/Sprites/Heads/GiraffeHead") ;
                }
                return m_giraffeSprite;
            }
            set { m_giraffeSprite = value; }
        }
    }
}
