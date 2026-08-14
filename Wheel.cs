using MonoMod.Utils;
using Quintessential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PartType = class_139;

namespace Origami;

// Borrowed from Neuvolics
public static class Wheel
{
    const string orimetalStateString = "Origami_FlemmingWheelAtoms";
    const float sixtyDegrees = (float)Math.PI / 3f;

    static Molecule FlemmingMolecule()
    {
        Molecule molecule = new();
        molecule.method_1105(new(Atoms.id), new HexIndex(0, 1));
        molecule.method_1105(new(Atoms.eleven), new HexIndex(1, 0));
        molecule.method_1105(new(Atoms.twelve), new HexIndex(1, -1));
        molecule.method_1105(new(Atoms.id), new HexIndex(0, -1));
        molecule.method_1105(new(Atoms.eleven), new HexIndex(-1, 0));
        molecule.method_1105(new(Atoms.twelve), new HexIndex(-1, 1));
        return molecule;
    }

    public static PartType Flemming;

    public static void LoadWheel()
    {
        Flemming = new()
        {
            /*ID*/
            field_1528 = "Origami-Flemming",
            /*Name*/
            field_1529 = class_134.method_253("Flemming's Wheel", string.Empty),
            /*Desc*/
            field_1530 = class_134.method_253("By using Flemming's wheel with the glyphs of regeneration, one can construct all known orimetals.", string.Empty),
            /*Cost*/
            field_1531 = 25,
            /*Type*/
            field_1532 = (enum_2)1,
            /*Programmable?*/
            field_1533 = true,
            /*Force-rotatable*/
            field_1536 = true,
            /*Berlo Atoms*/
            field_1544 = new Dictionary<HexIndex, AtomType>(),
            /*Icon*/
            field_1547 = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/flemming_icon"),
            /*Hover Icon*/
            field_1548 = Brimstone.API.GetTexture("textures/parts/Hi30MC/Origami/flemming_icon"),
            /*Only One Allowed?*/
            field_1552 = true,
            CustomPermissionCheck = perms => perms.Contains(Origami.FlemmingPermission)
        };
        foreach (HexIndex hex in HexIndex.AdjacentOffsets)
            Flemming.field_1544.Add(hex, Brimstone.API.VanillaAtoms.quicksilver);


        QApi.AddPartTypeToPanel(Flemming, class_191.field_1771);
        QApi.AddPartType(Flemming, DrawFlemmingWheel);
    }

    private static void SetFlemmingWheelData<T>(PartSimState state, string field, T data) => new DynamicData(state).Set(field, data);
    private static T GetFlemmingWheelData<T>(PartSimState state, string field, T initial)
    {
        var data = new DynamicData(state).Get(field);
        if (data == null)
        {
            SetFlemmingWheelData(state, field, initial);
            return initial;
        }
        else
        {
            return (T)data;
        }
    }

    public static void DrawSelectionGlow(SolutionEditorBase seb_self, Part part, Vector2 pos, float alpha)
    {
        var cageSelectGlowTexture = class_238.field_1989.field_97.field_367;
        int armLength = 1; // part.method_1165()
        class_236 class236 = seb_self.method_1989(part, pos);
        Color color = Color.White.WithAlpha(alpha);

        typeof(SolutionEditorBase).GetMethod("method_2006", BindingFlags.NonPublic | BindingFlags.Static).Invoke(seb_self, new object[] { armLength, class_191.field_1767.field_1534, class236, color });
        for (int index = 0; index < 6; ++index)
        {
            float num = index * sixtyDegrees;
            typeof(SolutionEditorBase).GetMethod("method_2016", BindingFlags.NonPublic | BindingFlags.Static).Invoke(seb_self, new object[] { cageSelectGlowTexture, color, class236.field_1984, class236.field_1985 + num });
        }
    }

    public static void DrawFlemmingAtoms(SolutionEditorBase seb_self, Part part, Vector2 pos, bool active = false)
    {
        if (part.method_1159() != Flemming)
            return;
        PartSimState partSimState = seb_self.method_507().method_481(part);

        class_236 class236 = seb_self.method_1989(part, pos);
        Molecule molecule = GetFlemmingWheelAtoms(partSimState);
        Editor.method_925(molecule, class236.field_1984, new HexIndex(0, 0), class236.field_1985, 1f, 1f, 1f, false, seb_self);
    }

    public static void DrawFlemmingFlash(SolutionEditorBase seb, Part part, HexIndex hex)
    {
        DrawFlemmingFlash(seb, part.method_1184(hex));
    }

    public static void DrawFlemmingFlash(SolutionEditorBase seb, HexIndex hex)
    {
        // todo,
        //seb.field_3935.Add(new class_228(seb, (enum_7)1, class_187.field_1742.method_492(hex), Textures.Soria.Flash, 30f, Vector2.Zero, 0f));
    }

    private static Molecule GetFlemmingWheelAtoms(PartSimState state) => GetFlemmingWheelData(state, orimetalStateString, FlemmingMolecule());

    static void DrawFlemmingWheel(Part part, Vector2 pos, SolutionEditorBase editor, class_195 renderer)
    {
        // draw atoms, if the simulation is stopped - otherwise, the running simulation will draw them
        if (editor.method_503() == enum_128.Stopped)
        {
            DrawFlemmingAtoms(editor, part, pos);
        }

        // draw arm stubs
        class_236 class236 = editor.method_1989(part, pos);
        typeof(SolutionEditorBase).GetMethod("method_2005", BindingFlags.NonPublic | BindingFlags.Static).Invoke(editor, new object[] { part.method_1165(), class_191.field_1767.field_1534, class236 });

        // draw cages
        for (int i = 0; i < 6; i++)
        {
            float radians = renderer.field_1798 + (i * sixtyDegrees);
            Vector2 vector2_9 = renderer.field_1797 + class_187.field_1742.method_492(new HexIndex(1, 0)).Rotated(radians);
            typeof(SolutionEditorBase).GetMethod("method_2003", BindingFlags.NonPublic | BindingFlags.Static).Invoke(editor, new object[] { class_238.field_1989.field_90.field_232, vector2_9, new Vector2(39f, 33f), radians });
        }
    }

    public static Maybe<AtomReference> MaybeFindFlemmingWheelAtom(Sim sim_self, Part part, HexIndex offset) => MaybeFindFlemmingWheelAtom(sim_self, part.method_1184(offset));

    public static Maybe<AtomReference> MaybeFindFlemmingWheelAtom(Sim sim_self, HexIndex hex)
    {
        var SEB = sim_self.field_3818;
        var solution = SEB.method_502();
        var partList = solution.field_3919;
        var partSimStates = sim_self.field_3821;

        foreach (var Flemming in partList.Where(x => x.method_1159() == Flemming))
        {
            var partSimState = partSimStates[Flemming];
            Molecule FlemmingAtoms = GetFlemmingWheelAtoms(partSimState);
            var hexIndex = partSimState.field_2724;
            var rotation = partSimState.field_2726;
            var hexKey = (hex - hexIndex).Rotated(rotation.Negative());

            if (FlemmingAtoms.method_1100().TryGetValue(hexKey, out Atom atom))
            {
                return new AtomReference(FlemmingAtoms, hexKey, atom.field_2275, atom, true);
            }
        }
        return struct_18.field_1431;
    }
}
