using Quintessential;
namespace Origami;

public class Origami: QuintessentialMod {
    public const string CompositionPermission = "Origami:Composition";
    public const string AugmentedCompPermission = "Origami:AugmentedComp";
    public const string HighRegenerationPermission = "Origami:HighRegeneration";
    public const string LowRegenerationPermission = "Origami:LowRegeneration";
    public const string TranslationPermission = "Origami:Translation";
    public const string FlemmingPermission = "Origami:Flemming";
    public const string SacrificePermission = "Origami:Sacrifice";

    public static bool NeuvolicsLoaded = Brimstone.API.IsModLoaded("Neuvolics");
    public static bool SennmetalsLoaded = Brimstone.API.IsModLoaded("Sennmetals");
    public static bool FTSIGCTULoaded = Brimstone.API.IsModLoaded("FTSIGCTU");

    public override void Load () {
        Logger.Log("Origami: Paper ready to fold!");
    }

    public override void PostLoad()
    {
        LoadMirrorRules();
    }

    public override void Unload() {
        Glyphs.RemoveHooks();
    }

    public override void LoadPuzzleContent()
    {
        Atoms.LoadAtoms();
        Wheel.LoadWheel();
        Glyphs.AddHooks();
        Glyphs.LoadParts();

        QApi.AddPuzzlePermission(CompositionPermission, "Glyph of Composition", "Origami");
        QApi.AddPuzzlePermission(AugmentedCompPermission, "Glyph of Aug. Comp.", "Origami");
        QApi.AddPuzzlePermission(HighRegenerationPermission, "Glyph of High Regen.", "Origami");
        QApi.AddPuzzlePermission(LowRegenerationPermission, "Glyph of Low Regen.", "Origami");
        QApi.AddPuzzlePermission(FlemmingPermission, "Flemming's Wheel", "Origami");
        QApi.AddPuzzlePermission(SacrificePermission, "Glyph of Sacrifice", "Origami");

        if (NeuvolicsLoaded) ImportManager.ImportNeuvolics();
        if (SennmetalsLoaded) { ImportManager.ImportSennmetals(); Logger.Log("loaded sennmetals"); }
        if (NeuvolicsLoaded || SennmetalsLoaded) QApi.AddPuzzlePermission(TranslationPermission, "Glyph of Translation", "Origami");

        if (FTSIGCTULoaded)
        {
            LoadMapRules();
        }

        GlyphLUT.GenerateLUTs();
        Logger.Log("Origami: Assets loaded :3c");
    }

    private static void LoadMapRules()
    {
        FTSIGCTU.Navigation.PartsMap.addPartHexRule(Glyphs.Composition, FTSIGCTU.Navigation.PartsMap.glyphRule);
        FTSIGCTU.Navigation.PartsMap.addPartHexRule(Glyphs.AugmentedComp, FTSIGCTU.Navigation.PartsMap.glyphRule);
        FTSIGCTU.Navigation.PartsMap.addPartHexRule(Glyphs.HighRegeneration, FTSIGCTU.Navigation.PartsMap.glyphRule);
        FTSIGCTU.Navigation.PartsMap.addPartHexRule(Glyphs.LowRegeneration, FTSIGCTU.Navigation.PartsMap.glyphRule);
        FTSIGCTU.Navigation.PartsMap.addPartHexRule(Glyphs.Translation, FTSIGCTU.Navigation.PartsMap.glyphRule);
        // the glyph that does not exist does not appear on the map.
    }

    private static void LoadMirrorRules() {
        FTSIGCTU.MirrorTool.addRule(Glyphs.LowRegeneration, FTSIGCTU.MirrorTool.mirrorSimplePart);
        FTSIGCTU.MirrorTool.addRule(Glyphs.Translation, FTSIGCTU.MirrorTool.mirrorSimplePart);
        FTSIGCTU.MirrorTool.addRule(Glyphs.Sacrifice, FTSIGCTU.MirrorTool.mirrorSimplePart);
    }
}
