using UnityEngine;

public class BenchmarkFPS : MonoBehaviour
{
    private float elapsedTime = 0f;
    private int frameCount = 0;

    public float delayStart = 7f;
    public float benchmarkDuration = 20f;

    public bool startBenchmark = false;

    private void Start()
    {
        elapsedTime = 0f;
    }

    void Update()
    {


        if (!startBenchmark)
        {
            elapsedTime += Time.unscaledDeltaTime;
            Debug.Log(elapsedTime);
            if (elapsedTime > delayStart)
            {
                startBenchmark = true;
                elapsedTime = 0f;
                Debug.Log("Warm-up complete. Starting 30-second FPS benchmark...");
            }
        }
        else 
        {
            elapsedTime += Time.unscaledDeltaTime;
            frameCount++;

            if (elapsedTime >= benchmarkDuration) // Logs average after the specified duration
            {
                float avgFPS = frameCount / elapsedTime;
                float avgFrameTime = (elapsedTime / frameCount) * 1000f;
                Debug.Log($"Benchmark -> Avg FPS: {avgFPS:F2} | Avg Frame Time: {avgFrameTime:F2} ms");
                enabled = false; // Stops logging
            }
        }
    }
}