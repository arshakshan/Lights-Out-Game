using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Light flickerLight;
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    public float flickerSpeed = 0.1f;

    void Start()
    {
        flickerLight = GetComponent<Light>();
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f);
        flickerLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
