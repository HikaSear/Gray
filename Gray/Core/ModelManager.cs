using Raylib_cs;

namespace Gray.Core
{
    internal static class ModelManager
    {
        private static readonly List<Model> loadedModels = new List<Model>();
        private static readonly List<Texture2D> loadedTextures = new List<Texture2D>();

        public static unsafe Model LoadModel(string modelName)
        {
            Model model = Raylib.LoadModel("res/models/" + modelName + ".glb");
            Texture2D texture = Raylib.LoadTexture("res/textures/" + modelName + ".png");

            Raylib.SetMaterialTexture(ref model, 0, MaterialMapIndex.Diffuse, ref texture);
            model.Materials[0].Shader = Shaders.GetShader();

            loadedModels.Add(model);
            loadedTextures.Add(texture);

            return model;
        }

        public static void UnloadAll()
        {
            foreach (var model in loadedModels) Raylib.UnloadModel(model);
            foreach (var texture in loadedTextures) Raylib.UnloadTexture(texture);

            loadedModels.Clear();
            loadedTextures.Clear();
        }
    }
}
