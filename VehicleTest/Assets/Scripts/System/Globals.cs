namespace System
{
	public static class Globals
	{
		public class Components
		{
			public const string ScriptManager = "ScriptManager";
			public const string UiController = "UiController";
		}

		public class SceneGameObjects
		{
			public const string Lanes = "Lanes";
			public const string Player = "Player";
			public const string OppositeLanes = "OppositeLanes";
			public const string Partitions = "Partitions";
			public const string VehicleSpawn = "VehicleSpawn";
			public const string OppositeCar = "OppositeCar";

		}

		public class UiObbjects
		{
			public const string PlayerConstantRateText = "PlayerConstantRateText";
			public const string CarAmountText = "CarAmountText";
			public const string CarSpeedText = "CarSpeedText";
			public const string CarCountText = "CarCountText";
			public const string MayhamMode = "MayhamMode";
		}

		public static class ResourcesPaths
		{
			private static string PrefabsPath = @"Prefabs\";
			public static string OppositeCar = string.Format("{0}{1}", PrefabsPath, "OppositeCar");
			public static string Lanes = string.Format("{0}{1}", PrefabsPath, @"Lanes");
			public static string OppositeLanes = string.Format("{0}{1}", PrefabsPath, "OppositeLanes");
			public static string Partitions = string.Format("{0}{1}", PrefabsPath, "Partitions");
			public static string Car = string.Format("{0}{1}", PrefabsPath, "Car");
			public static string UiControllerPrefab = string.Format("{0}{1}", PrefabsPath, @"Ui\UiController");
		}

		public static class ShaderInformation
		{
			public const string DiffuseShader = "Legacy Shaders/Diffuse";
			public const string ShaderColor = "_Color";
		}
	}
}