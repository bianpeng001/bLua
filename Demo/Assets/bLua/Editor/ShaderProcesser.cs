using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Rendering;
using UnityEngine;

namespace bLua
{
    public class ShaderProcesser : IPreprocessShaders
    {
        public int callbackOrder => throw new System.NotImplementedException();

        public void OnProcessShader(Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data)
        {
            if (shader.name.StartsWith("Hidden"))
                return ;
            Debug.Log($"{shader} {data.Count}");
        }
    }
}
