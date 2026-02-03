using MelonLoader;

[assembly: MelonInfo(typeof(AutomatedTasksMod.Mod), "AutomatedTasksMod", "1.2.2", "Robert Rioja")]
[assembly: MelonColor(1, 255, 20, 147)]
[assembly: MelonGame("TVGS", "Schedule I")]

namespace AutomatedTasksMod {
	public class Mod : MelonMod {
		public override void OnInitializeMelon() {
			Prefs.SetupPrefs();
		}
	}
}
