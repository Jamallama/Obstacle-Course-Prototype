using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spidergram
{

    /*
     * Add this to the camera
     */

    public class ChangeFog : MonoBehaviour
    {
        public Color water = new Color(0.3f, 0.3f, 1f, 0.5f);
        public float hgt = 0f;
        public float density = 0.5f;
        float lastDensity;
        Color lastFog;
        Color currFog;


        // Start is called before the first frame update
        void Start()
        {
            lastFog = RenderSettings.fogColor;
            lastDensity = RenderSettings.fogDensity;
            RenderSettings.fogMode = FogMode.ExponentialSquared;

            // disableFog(lastFog);
        }

        void enableFog(Color fog, float density)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = fog;
            RenderSettings.fogDensity = density;

            Debug.Log("enableFog");
        }
        void disableFog(Color fog)
        {
            RenderSettings.fog = false;
            RenderSettings.fogColor = fog;
            RenderSettings.fogDensity = lastDensity;

            Debug.Log("disableFog");
        }


        // Update is called once per frame
        void Update()
        {
            // Debug.Log("T: " + transform.position.y);
            if (transform.position.y <= hgt)
            {
                Debug.Log("enable it: " + transform.position.y);
                enableFog(water, density);
                Debug.Log("enable");
            }
            if (transform.position.y > hgt)
            {
                enableFog(lastFog, lastDensity);
            }

        }
    }

}