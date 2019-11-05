using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

using System.Collections;

// A set of icons, for lives and shields
public class IconSet : MonoBehaviour {
    
    public Image iconPrefab;
    public int iconCount;
    public float xOffset = 100;
    public StroidsGame game;
    
    public int Count{ get{return m_visibleCount;} }

    private List<Image> m_icons = new List<Image>();
    private int m_visibleCount;
    
    
    // initialize this behaviour
    public void Start()
    {
        SetCount(iconCount);
        
    }

    public void SetCount(int count)
    {
        foreach(var icon in m_icons)
        {
            GameObject.Destroy(icon.gameObject);
        }
        m_icons.Clear();
        // generate all of the icons
        for (int iconIdx = 0; iconIdx < count; iconIdx++)
        {
            // create the icon
            Image clone = Instantiate(iconPrefab);

            // add it to the hierarchy
            clone.transform.parent = this.transform;

            // position it
            clone.transform.position = new Vector3(xOffset * iconIdx, 0, 0);

            m_icons.Add(clone);
        }

        m_visibleCount = iconCount;
    }
   
    
}
