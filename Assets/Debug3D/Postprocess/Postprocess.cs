using UnityEngine;

public class Postprocess : MonoBehaviour
{
    public Material mat;
    public Texture Colormap;
    public Texture Depth;

    public Material Sharpenmat;
    public Material Differenmat;

    public RenderTexture SharpenTex;
    public RenderTexture PosprocessTex;

    public ComputeShader Cul_Delta;

    static readonly int
        PosId = Shader.PropertyToID("PosprocessTex"),
        DepthId = Shader.PropertyToID("DepthTexture");
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int groupX, groupY;
    void Start()
    {
        Colormap = GetComponent<RunAI>().InputTexture;
        Depth = GetComponent<RunAI>().outputTexture;
        PosprocessTex= new RenderTexture(Colormap.width, Colormap.height, 0, RenderTextureFormat.ARGBFloat);
        PosprocessTex.enableRandomWrite = true;
        PosprocessTex.Create();
        SharpenTex = new RenderTexture(Colormap.width, Colormap.height, 0, RenderTextureFormat.ARGBFloat);
        SharpenTex.enableRandomWrite = true;
        SharpenTex.Create();

        mat.mainTexture = PosprocessTex;
        groupX = Mathf.CeilToInt(Depth.width / 8f);
        groupY = Mathf.CeilToInt(Depth.height / 8f);
        Cul_Delta.SetTexture(0, DepthId, SharpenTex);
        Cul_Delta.SetTexture(0, PosId, PosprocessTex);
    }

    // Update is called once per frame
    void Update()
    {
        
        Graphics.Blit(Depth, SharpenTex, Sharpenmat);
        Graphics.Blit(SharpenTex, PosprocessTex, Differenmat);
        Cul_Delta.Dispatch(0, groupX, groupY, 1);
    }
}
