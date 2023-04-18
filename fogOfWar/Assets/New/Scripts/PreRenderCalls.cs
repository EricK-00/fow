using UnityEngine;
using UnityEngine.Rendering;

public class PreRenderCalls : MonoBehaviour
{
    public bool UsingURP;
    public Fog _Fog;

    private float timer = 0f;

    void Awake()
    {
        if (UsingURP)
        {
            RenderPipelineManager.beginCameraRendering += PreRenderURP;
        }
    }

    void OnDisable()
    {
        if (UsingURP)
        {
            RenderPipelineManager.beginCameraRendering -= PreRenderURP;
        }
    }

    void PreRenderURP(ScriptableRenderContext renderContext, Camera obj)
    {
        Debug.Log("PreRender");
        OnPreRender();
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    void OnPreRender()
    {
        //if (timer < 0.033f)
        //    return;
        //else
        //    timer = 0f;

        Debug.Log("Set");
        // FOG CALL
        _Fog.SetCookie();
    }
}
