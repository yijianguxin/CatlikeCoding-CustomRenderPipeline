using UnityEngine;
using UnityEngine.Rendering;

public class CameraRenderer
{
    private const string bufferName = "Render Camera";
    private CommandBuffer buffer = new CommandBuffer
    {
        name = bufferName
    };

    private ScriptableRenderContext context;
    private Camera camera;

    public void Render(ScriptableRenderContext context, Camera camera)
    {
        this.context = context;
        this.camera = camera;

        this.Setup();
        this.DrawVisibleGeometry();
        this.Submit();
    }

    private void Setup()
    {
        context.SetupCameraProperties(camera);
        buffer.ClearRenderTarget(true, true, Color.clear);
        buffer.BeginSample(bufferName);
        this.ExecuteBuffer();
    }

    private void Submit()
    {
        buffer.EndSample(bufferName);
        this.ExecuteBuffer();
        context.Submit();
    }

    private void ExecuteBuffer()
    {
        context.ExecuteCommandBuffer(buffer);
        buffer.Clear();
    }

    private void DrawVisibleGeometry()
    {
        context.DrawSkybox(camera);
    }
}