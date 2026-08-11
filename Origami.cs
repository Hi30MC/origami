using Quintessential;
namespace Origami;

public class Origami: QuintessentialMod {
    public const string CompositionPermission = "Origami:Composition";
    public const string AugmentationPermission = "Origami:Augmentation";
    public const string HighRegenerationPermission = "Origami:HighRegeneration";
    public const string LowRegenerationPermission = "Origami:LowRegeneration";
    public const string TranslationPermission = "Origami:Translation";
    public const string FlemmingPermission = "Origami:Flemming";
    public const string SacrificePermission = "Origami:Sacrifice";

    public static bool NeuvolicsLoaded = Brimstone.API.IsModLoaded("Neuvolics");

    public override void Load () {
        Logger.Log("Origami: Paper ready to fold!");
    }

    public override void PostLoad() {}

    public override void Unload() {
        Glyphs.RemoveHooks();
    }

    public override void LoadPuzzleContent() {
        Atoms.LoadAtoms();
        Wheel.LoadWheel();
        Glyphs.AddHooks();
        Glyphs.LoadParts();

        QApi.AddPuzzlePermission(CompositionPermission, "Glyph of Composition", "Origami");
        QApi.AddPuzzlePermission(AugmentationPermission, "Glyph of Aug. Comp.", "Origami");
        QApi.AddPuzzlePermission(HighRegenerationPermission, "Glyph of High Regen.", "Origami");
        QApi.AddPuzzlePermission(LowRegenerationPermission, "Glyph of Low Regen.", "Origami");
        QApi.AddPuzzlePermission(FlemmingPermission, "Flemming's Wheel", "Origami");
        QApi.AddPuzzlePermission(SacrificePermission, "Glyph of Sacrifice", "Origami");

        if (NeuvolicsLoaded) {
            ImportManager.ImportNeuvolics();
            QApi.AddPuzzlePermission(TranslationPermission, "Glyph of Translation", "Origami");
        }

        GlyphLUT.GenerateLUTs();
        Logger.Log("Origami: Assets loaded :3c");
    }
}
