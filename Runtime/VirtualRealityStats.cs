using TMPro;
using Unity.Profiling;
using UnityEngine;

public class VirtualRealityStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fpsText;
    [SerializeField] TextMeshProUGUI batchText;

    private ProfilerRecorder batchRecorder;

    float fps;
    // variable to not update our frame rate every frame
    float fpsTimerRefreshRate = 0.5f;
    float fpsTimer;

    private void OnEnable()
    {
        batchRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Batches Count");
    }

    private void OnDisable()
    {
        batchRecorder.Dispose();
    }

    void Update()
    {
        // calculate fps
        fpsTimer += Time.unscaledDeltaTime;
        if(fpsTimer >= fpsTimerRefreshRate)
        {
            fps = 1f / Time.unscaledDeltaTime;
            fpsTimer = 0;
        }

        int lastBatches = batchRecorder.Valid ? (int)batchRecorder.LastValue : 0;

        fpsText.SetText("FPS: " + fps.ToString());
        batchText.SetText("Batches: " +  lastBatches.ToString());
    }
}
