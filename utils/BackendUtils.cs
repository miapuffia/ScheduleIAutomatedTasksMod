#if IL2CPP
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppScheduleOne.ObjectScripts;
using Il2CppScheduleOne.Packaging;
using Il2CppScheduleOne.PlayerScripts;
using Il2CppScheduleOne.Product;
#elif MONO
using ScheduleOne.ObjectScripts;
using ScheduleOne.Packaging;
using ScheduleOne.PlayerScripts;
using System.Reflection;
using UnityEngine.UI;
#endif
using UnityEngine;

namespace AutomatedTasksMod {
	internal static class BackendUtils {
		internal static int GetPlayerInventoryPriorEquippedSlotIndex(PlayerInventory playerInventory) {
#if IL2CPP
			return playerInventory.PriorEquippedSlotIndex;
#elif MONO
			return (int) playerInventory.GetType().GetField("PriorEquippedSlotIndex", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(playerInventory);
#endif
		}

		internal static void SetStirringRodCurrentStirringSpeed(StirringRod stirringRod, float value) {
#if IL2CPP
			stirringRod.CurrentStirringSpeed = value;
#elif MONO
			stirringRod.GetType().GetProperty("CurrentStirringSpeed").DeclaringType.GetProperty("CurrentStirringSpeed").SetValue(stirringRod, value, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null);
#endif
		}

#if IL2CPP
		internal static Il2CppSystem.Collections.Generic.List<GameObject> GetLabOvenShards(LabOven labOven) {
			return labOven.shards;
		}
#elif MONO
		internal static List<GameObject> GetLabOvenShards(LabOven labOven) {
			return (List<GameObject>) labOven.GetType().GetField("shards", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(labOven);
		}
#endif

#if IL2CPP
		internal static Il2CppSystem.Collections.Generic.List<FunctionalProduct> GetFunctionalPackagingPackedProducts(FunctionalPackaging functionalPackaging) {
			return functionalPackaging.PackedProducts;
		}
#elif MONO
		internal static List<FunctionalProduct> GetFunctionalPackagingPackedProducts(FunctionalPackaging functionalPackaging) {
			return (List<FunctionalProduct>) functionalPackaging.GetType().GetField("PackedProducts", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(functionalPackaging);
		}
#endif

		internal static int GetPackagingToolProductInHopper(PackagingTool packagingTool) {
#if IL2CPP
			return packagingTool.ProductInHopper;
#elif MONO
			return (int) packagingTool.GetType().GetField("ProductInHopper", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(packagingTool);
#endif
		}

#if IL2CPP
		internal static Il2CppSystem.Collections.Generic.List<FunctionalPackaging> GetPackagingToolFinalizedPackaging(PackagingTool packagingTool) {
			return packagingTool.FinalizedPackaging;
		}
#elif MONO
		internal static List<FunctionalPackaging> GetPackagingToolFinalizedPackaging(PackagingTool packagingTool) {
			return (List<FunctionalPackaging>) packagingTool.GetType().GetField("FinalizedPackaging", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(packagingTool);
		}
#endif

		internal static Coroutine GetPackagingToolFinalizeCoroutine(PackagingTool packagingTool) {
#if IL2CPP
			return packagingTool.finalizeCoroutine;
#elif MONO
			return (Coroutine) packagingTool.GetType().GetField("finalizeCoroutine", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(packagingTool);
#endif
		}

		internal static bool GetPackagingStationVisualsLocked(PackagingStation packagingStation) {
#if IL2CPP
			return packagingStation.visualsLocked;
#elif MONO
			if(packagingStation is PackagingStationMk2)
				return (bool) packagingStation.GetType().BaseType.GetField("visualsLocked", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(packagingStation);
			else
				return (bool) packagingStation.GetType().GetField("visualsLocked", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(packagingStation);
#endif
		}

#if IL2CPP
		internal static T BackendCast<T>(this Il2CppObjectBase o) where T : Il2CppObjectBase {
			return o.Cast<T>();
		}
#elif MONO
		internal static T BackendCast<T>(this object o) {
			return (T) o;
		}
#endif

#if IL2CPP
		internal static T BackendTryCast<T>(this Il2CppObjectBase o) where T : Il2CppObjectBase {
			return o.TryCast<T>();
		}
#elif MONO
		internal static T BackendTryCast<T>(this object o) where T : class {
			return o as T;
		}
#endif
	}
}
