using System.Collections.Generic;

namespace Origami;

public static class GlyphLUT {
    public static Dictionary<AtomType, AtomType> TranslationLUT = new();

    public static void GenerateLUTs() {
        GenerateTranslationLUT();
    }

    public static void GenerateTranslationLUT() {
        if (Origami.NeuvolicsLoaded) {
            TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetIridium(), Atoms.AtomType.four);
            TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetMitrum(), Atoms.AtomType.three);
            TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetTaceum(), Atoms.AtomType.twenty);
            TranslationLUT.Add(ImportManager.NeuvolicsAtoms.GetAzulum(), Atoms.AtomType.nineteen);
            TranslationLUT.Add(Atoms.AtomType.four, ImportManager.NeuvolicsAtoms.GetIridium());
            TranslationLUT.Add( Atoms.AtomType.three, ImportManager.NeuvolicsAtoms.GetMitrum());
            TranslationLUT.Add( Atoms.AtomType.twenty, ImportManager.NeuvolicsAtoms.GetTaceum());
            TranslationLUT.Add( Atoms.AtomType.nineteen, ImportManager.NeuvolicsAtoms.GetAzulum());
        }
    }
}
