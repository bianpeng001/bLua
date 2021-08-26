using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace bLua
{
    public class BundleBuilder
    {

        public const string outputPath = "Bundles";
        public static BuildAssetBundleOptions bundleOptions = BuildAssetBundleOptions.DeterministicAssetBundle;
        
        private static void EnsureDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        [MenuItem("Tools/bLua/Bundle/Test")]
        public static void TestBuild()
        {
            EnsureDirectory(outputPath);

            List<AssetBundleBuild> assetList = new List<AssetBundleBuild>();
            assetList.Add(new AssetBundleBuild()
            {
                assetBundleName = "units.u3d",
                assetNames = new string[]
                {
                    "Assets/bLua/Example/02_War/Prefab/Unit01.prefab",
                    "Assets/bLua/Example/02_War/Prefab/Unit02.prefab",
                }
            });
            assetList.Add(new AssetBundleBuild()
            {
                assetBundleName = "units_res.u3d",
                assetNames = new string[]
                {
                    "Assets/bLua/Example/02_War/Scene/216_8.png",
                    "Assets/bLua/Example/02_War/Player/player.fbx",
                }
            });
            assetList.Add(new AssetBundleBuild()
            {
                assetBundleName = "scene.u3d",
                assetNames = new string[]
                {
                    "Assets/bLua/Example/02_War/WarScene.unity",
                    "Assets/bLua/Example/07_LuanDou/LuanDouScene.unity",
                }
            });

            BuildPipeline.BuildAssetBundles(outputPath,
                assetList.ToArray(), bundleOptions, Builder.activeBuildTarget);

        }
    }
}
