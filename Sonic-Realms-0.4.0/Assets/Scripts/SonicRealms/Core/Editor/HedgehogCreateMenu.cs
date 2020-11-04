using UnityEditor;
using UnityEngine;

namespace SonicRealms.Core.Editor
{
    public static class HedgehogCreateMenu
    {
        public static void HandleCreateContext(MenuCommand menuCommand, GameObject createdObject)
        {
            GameObjectUtility.SetParentAndAlign(createdObject, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(createdObject, "Create " + createdObject.name);
            Selection.activeObject = createdObject;
        }

        public static void HandleClonePrefab(MenuCommand menuCommand, string path, string name)
        {
            var clonedPrefab = GameObject.Instantiate(
                AssetDatabase.LoadAssetAtPath<GameObject>(path));
            clonedPrefab.name = name;
            HandleCreateContext(menuCommand, clonedPrefab);
        }

        public const string DefaultActorPath = "Assets/Hedgehog/Prefabs/Actors/Default.prefab";
        public const string DefaultActorName = "Hedgehog";
        [MenuItem("GameObject/Hedgehog/Actors/Default", false, 10)]
        public static void CreateDefaultController(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, DefaultActorPath, DefaultActorName);
        }

        public const string PathSwitcherPath = "Assets/Hedgehog/Prefabs/Level/Areas/Path Switcher.prefab";
        public const string PathSwitcherName = "Path Switcher";
        [MenuItem("GameObject/Hedgehog/Areas/Path Switcher", false, 10)]
        public static void CreatePathSwitcher(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, PathSwitcherPath, PathSwitcherName);
        }

        public const string CurrentPath = "Assets/Hedgehog/Prefabs/Level/Areas/Current.prefab";
        public const string CurrentName = "Current";
        [MenuItem("GameObject/Hedgehog/Areas/Current", false, 10)]
        public static void CreateCurrent(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, CurrentPath, CurrentName);
        }

        public const string WaterPath = "Assets/Hedgehog/Prefabs/Level/Areas/Water.prefab";
        public const string WaterName = "Water";
        [MenuItem("GameObject/Hedgehog/Areas/Water", false, 10)]
        public static void CreateWater(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, WaterPath, WaterName);
        }

        public const string BoostPadPath = "Assets/Hedgehog/Prefabs/Level/Objects/Boost Pad.prefab";
        public const string BoostPadName = "Boost Pad";
        [MenuItem("GameObject/Hedgehog/Objects/Boost Pad", false, 10)]
        public static void CreateBoostPad(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, BoostPadPath, BoostPadName);
        }

        public const string BumperPath = "Assets/Hedgehog/Prefabs/Level/Objects/Bumper.prefab";
        public const string BumperName = "Bumper";
        [MenuItem("GameObject/Hedgehog/Objects/Bumper", false, 10)]
        public static void CreateBumper(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, BumperPath, BumperName);
        }

        public const string SpringPath = "Assets/Hedgehog/Prefabs/Level/Objects/Spring.prefab";
        public const string SpringName = "Spring";
        [MenuItem("GameObject/Hedgehog/Objects/Spring", false, 10)]
        public static void CreateSpring(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, SpringPath, SpringName);
        }

        public const string AcceleratorPath = "Assets/Hedgehog/Prefabs/Level/Platforms/Accelerator.prefab";
        public const string AcceleratorName = "Accelerator";
        [MenuItem("GameObject/Hedgehog/Platforms/Accelerator", false, 10)]
        public static void CreateAccelerator(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, AcceleratorPath, AcceleratorName);
        }

        public const string ConveyorBeltPath = "Assets/Hedgehog/Prefabs/Level/Platforms/Conveyor Belt.prefab";
        public const string ConveyorBeltName = "Conveyor Belt";
        [MenuItem("GameObject/Hedgehog/Platforms/Conveyor Belt", false, 10)]
        public static void CreateConveyorBelt(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, ConveyorBeltPath, ConveyorBeltName);
        }

        public const string GravityMagnetPath = "Assets/Hedgehog/Prefabs/Level/Platforms/Gravity Magnet.prefab";
        public const string GravityMagnetName = "Gravity Magnet";
        [MenuItem("GameObject/Hedgehog/Platforms/Gravity Magnet", false, 10)]
        public static void CreateGravityMagnet(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, GravityMagnetPath, GravityMagnetName);
        }

        public const string IcePath = "Assets/Hedgehog/Prefabs/Level/Platforms/Ice.prefab";
        public const string IceName = "Ice";
        [MenuItem("GameObject/Hedgehog/Platforms/Ice", false, 10)]
        public static void CreateIce(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, IcePath, IceName);
        }

        public const string LedgePath = "Assets/Hedgehog/Prefabs/Level/Platforms/Ledge.prefab";
        public const string LedgeName = "Ledge";
        [MenuItem("GameObject/Hedgehog/Platforms/Ledge", false, 10)]
        public static void CreateLedge(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, LedgePath, LedgeName);
        }

        public const string PathPlatformPath = "Assets/Hedgehog/Prefabs/Level/Platforms/Path Platform.prefab";
        public const string PathPlatformName = "Path Platform";
        [MenuItem("GameObject/Hedgehog/Platforms/Path Platform", false, 10)]
        public static void CreatePathPlatform(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, PathPlatformPath, PathPlatformName);
        }

        public const string SwingPlatformPath = "Assets/Hedgehog/Prefabs/Level/Platforms/Swing Platform.prefab";
        public const string SwingPlatformName = "Swing Platform";
        [MenuItem("GameObject/Hedgehog/Platforms/Swing Platform", false, 10)]
        public static void CreateSwingPlatform(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, SwingPlatformPath, SwingPlatformName);
        }

        public const string WeightedPlatformPath = "Assets/Hedgehog/Prefabs/Level/Platforms/Weighted Platform.prefab";
        public const string WeightedPlatformName = "Weighted Platform";
        [MenuItem("GameObject/Hedgehog/Platforms/Weighted Platform", false, 10)]
        public static void CreateWeightedPlatform(MenuCommand menuCommand)
        {
            HandleClonePrefab(menuCommand, WeightedPlatformPath, WeightedPlatformName);
        }
    }
}
