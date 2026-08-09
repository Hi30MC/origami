using System.Collections.Generic;

namespace Origami;

public static class GlyphLUT {
    public static Dictionary<AtomType, AtomType> TranslationLUT = new();

    public static void GenerateLUTs() {
        GenerateTranslationLUT();
    }

    public static void GenerateTranslationLUT() {
        if (Origami.NeuvolicsLoaded) {
            TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetIridium(), Atoms.four);
            TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetMitrum(), Atoms.three);
            TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetTaceum(), Atoms.twenty);
            TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetAzulum(), Atoms.nineteen);
            TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetZephiron(), Atoms.id);
            TranslationLUT.Add(Atoms.four, ImportManager.NeuvolicsAtoms.GetIridium());
            TranslationLUT.Add(Atoms.three, ImportManager.NeuvolicsAtoms.GetMitrum());
            TranslationLUT.Add(Atoms.twenty, ImportManager.NeuvolicsAtoms.GetTaceum());
            TranslationLUT.Add(Atoms.nineteen, ImportManager.NeuvolicsAtoms.GetAzulum());
            TranslationLUT.Add(Atoms.id, ImportManager.NeuvolicsAtoms.GetZephiron());
        }
    }
}
