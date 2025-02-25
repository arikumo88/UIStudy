using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickeringLight : MonoBehaviour
{
    private Light2D spotLight;
    public float minIntensity = 1f;  // 最小の明るさ
    public float maxIntensity = 5f;  // 最大の明るさ
    public float flickerSpeed = 3f;  // 点滅の速さ
    private float flickerTime = 0f;
    private float targetIntensity;
    private float currentIntensity;

    // 光の揺れの範囲と速さ
    public float positionJitterAmount = 0.05f; // 揺れ幅 (小さいほど揺れが小さい)
    public float positionJitterSpeed = 2f; // 揺れの速度

    private Vector3 originalPosition;

    void Start()
    {
        spotLight = GetComponent<Light2D>();
        if (spotLight == null)
        {
            Debug.LogError("Spot Light 2D がアタッチされていません！");
            return;
        }

        currentIntensity = spotLight.intensity;
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        originalPosition = transform.position; // 初期位置を保存
    }

    void Update()
    {
        flickerTime += Time.deltaTime * flickerSpeed;

        // ランダムな強度変化
        if (Mathf.Abs(currentIntensity - targetIntensity) < 0.1f)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }
        currentIntensity = Mathf.Lerp(currentIntensity, targetIntensity, Time.deltaTime * flickerSpeed);
        spotLight.intensity = currentIntensity;

        // 光をランダムに揺らす
        float jitterX = Mathf.PerlinNoise(Time.time * positionJitterSpeed, 0f) * 2 - 1; // -1 ~ 1 の範囲
        float jitterY = Mathf.PerlinNoise(0f, Time.time * positionJitterSpeed) * 2 - 1;
        Vector3 newPos = originalPosition + new Vector3(jitterX, jitterY, 0) * positionJitterAmount;
        transform.position = newPos;

        Debug.Log("Light Position: " + newPos);
    }
}
