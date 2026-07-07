using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gray.Core
{
    internal static class Shaders
    {
        public static Shader GetShader()
        {
            string vertShaderText = ResManager.GetFileText("res/shaders/shader.vert");
            string fragShaderText = ResManager.GetFileText("res/shaders/shader.frag");
            Shader shader = Raylib.LoadShaderFromMemory(vertShaderText, fragShaderText);
            return shader;
        }
    }
}
