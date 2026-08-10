using System.Collections.Generic;
using System;

namespace Origami;

public static class GlyphLUT {
    public static Dictionary<Tuple<AtomType, AtomType>, AtomType> CompositionLUT = new();
    public static Dictionary<Tuple<AtomType, AtomType, AtomType>, AtomType> HighRegenerationLUT = new();
    public static Dictionary<Tuple<AtomType, AtomType>, AtomType> LowRegenerationLUT = new();
    public static Dictionary<AtomType, AtomType> TranslationLUT = new();

    public static void GenerateLUTs() {
        GenerateCompositionLUT();
        GenerateHighRegenerationLUT();
        GenerateLowRegenerationLUT();
        GenerateTranslationLUT();
    }

    public static void GenerateCompositionLUT() {
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.id),          Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.three),       Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.four),        Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.seven),       Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.eight),       Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.eleven),      Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.twelve),      Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.fifteen),     Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.sixteen),     Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.nineteen),    Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.twenty),      Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.twentythree), Atoms.twentythree);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.id),          Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.three),       Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.four),        Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.seven),       Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.eight),       Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.eleven),      Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.twelve),      Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.fifteen),     Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.sixteen),     Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.nineteen),    Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.twenty),      Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.twentythree), Atoms.twenty);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.id),          Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.three),       Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.four),        Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.seven),       Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.eight),       Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.eleven),      Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.twelve),      Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.fifteen),     Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.sixteen),     Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.nineteen),    Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.twenty),      Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.twentythree), Atoms.nineteen);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.id),          Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.three),       Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.four),        Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.seven),       Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.eight),       Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.eleven),      Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.twelve),      Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.fifteen),     Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.sixteen),     Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.nineteen),    Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.twenty),      Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.seven, Atoms.twentythree), Atoms.sixteen);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.id),          Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.three),       Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.four),        Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.seven),       Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.eight),       Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.eleven),      Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.twelve),      Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.fifteen),     Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.sixteen),     Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.nineteen),    Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.twenty),      Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.twentythree), Atoms.fifteen);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.id),          Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.three),       Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.four),        Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.seven),       Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.eight),       Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.eleven),      Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.twelve),      Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.fifteen),     Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.sixteen),     Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.nineteen),    Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.twenty),      Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.twentythree), Atoms.twelve);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.id),          Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.three),       Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.four),        Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.seven),       Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.eight),       Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.eleven),      Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.twelve),      Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.fifteen),     Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.sixteen),     Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.nineteen),    Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.twenty),      Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.twentythree), Atoms.eleven);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.id),          Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.three),       Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.four),        Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.seven),       Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.eight),       Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.eleven),      Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.twelve),      Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.fifteen),     Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.sixteen),     Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.nineteen),    Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.twenty),      Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.twentythree), Atoms.eight);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.id),          Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.three),       Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.four),        Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.seven),       Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.eight),       Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.eleven),      Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.twelve),      Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.fifteen),     Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.sixteen),     Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.nineteen),    Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.twenty),      Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.sixteen, Atoms.twentythree), Atoms.seven);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.id),          Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.three),       Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.four),        Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.seven),       Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.eight),       Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.eleven),      Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.twelve),      Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.fifteen),     Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.sixteen),     Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.nineteen),    Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.twenty),      Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.twentythree), Atoms.four);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.id),          Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.three),       Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.four),        Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.seven),       Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.eight),       Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.eleven),      Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.twelve),      Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.fifteen),     Atoms.id);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.sixteen),     Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.nineteen),    Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.twenty),      Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.twentythree), Atoms.three);

        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.id),          Atoms.twentythree);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.three),       Atoms.eleven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.four),        Atoms.fifteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.seven),       Atoms.sixteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.eight),       Atoms.nineteen);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.eleven),      Atoms.three);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.twelve),      Atoms.twenty);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.fifteen),     Atoms.four);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.sixteen),     Atoms.seven);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.nineteen),    Atoms.eight);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.twenty),      Atoms.twelve);
        CompositionLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twentythree, Atoms.twentythree), Atoms.id);
    }

    public static void GenerateHighRegenerationLUT() {
        //seven, sixteen, twentythree
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.seven, Atoms.sixteen, Atoms.twentythree), Atoms.id);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.seven, Atoms.twentythree, Atoms.sixteen), Atoms.id);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.sixteen, Atoms.seven, Atoms.twentythree), Atoms.id);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.sixteen, Atoms.twentythree, Atoms.seven), Atoms.id);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.twentythree, Atoms.sixteen, Atoms.seven), Atoms.id);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.twentythree, Atoms.seven, Atoms.sixteen), Atoms.id);

        //id, sixteen, twentythree
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.id, Atoms.sixteen, Atoms.twentythree), Atoms.seven);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.id, Atoms.twentythree, Atoms.sixteen), Atoms.seven);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.sixteen, Atoms.id, Atoms.twentythree), Atoms.seven);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.sixteen, Atoms.twentythree, Atoms.id), Atoms.seven);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.twentythree, Atoms.sixteen, Atoms.id), Atoms.seven);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.twentythree, Atoms.id, Atoms.sixteen), Atoms.seven);

        //id, seven, twentythree
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.id, Atoms.seven, Atoms.twentythree), Atoms.sixteen);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.id, Atoms.twentythree, Atoms.seven), Atoms.sixteen);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.seven, Atoms.id, Atoms.twentythree), Atoms.sixteen);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.seven, Atoms.twentythree, Atoms.id), Atoms.sixteen);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.twentythree, Atoms.seven, Atoms.id), Atoms.sixteen);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.twentythree, Atoms.id, Atoms.seven), Atoms.sixteen);

        //id, sixteen, twentythree
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.id, Atoms.sixteen, Atoms.seven), Atoms.twentythree);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.id, Atoms.seven, Atoms.sixteen), Atoms.twentythree);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.sixteen, Atoms.id, Atoms.seven), Atoms.twentythree);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.sixteen, Atoms.seven, Atoms.id), Atoms.twentythree);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.seven, Atoms.sixteen, Atoms.id), Atoms.twentythree);
        HighRegenerationLUT.Add(new Tuple<AtomType, AtomType, AtomType>(Atoms.seven, Atoms.id, Atoms.sixteen), Atoms.twentythree);
    }

    public static void GenerateLowRegenerationLUT() {
        //id, three, four
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.three), Atoms.four);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.id), Atoms.four);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.four), Atoms.three);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.id), Atoms.three);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.four, Atoms.three), Atoms.id);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.three, Atoms.four), Atoms.id);

        //id, eight, twelve
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.eight), Atoms.twelve);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.id), Atoms.twelve);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.twelve), Atoms.eight);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.id), Atoms.eight);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twelve, Atoms.eight), Atoms.id);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eight, Atoms.twelve), Atoms.id);

        //id, eleven, nineteen
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.eleven), Atoms.nineteen);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.id), Atoms.nineteen);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.nineteen), Atoms.eleven);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.id), Atoms.eleven);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.nineteen, Atoms.eleven), Atoms.id);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.eleven, Atoms.nineteen), Atoms.id);

        //id, fifteen, twenty
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.fifteen), Atoms.twenty);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.id), Atoms.twenty);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.id, Atoms.twenty), Atoms.fifteen);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.id), Atoms.fifteen);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.twenty, Atoms.fifteen), Atoms.id);
        LowRegenerationLUT.Add(new Tuple<AtomType, AtomType>(Atoms.fifteen, Atoms.twenty), Atoms.id);
    }

    public static void GenerateTranslationLUT() {
        if (Origami.NeuvolicsLoaded)
        {
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
