// NX 2412
// Journal created by Alfa on Mon Aug  3 09:01:58 2026 Mitteleuropäische Sommerzeit

//
using System;
using NXOpen;

public class NXJournal
{
  // --------------------------------------------------
  // Function to return current date as "dd.MM.yyyy"
  // --------------------------------------------------
  public static string GetCurrentDate()
  {
    return DateTime.Now.ToString("dd.MM.yyyy");
  }

  public static void Main(string[] args)
  {
    NXOpen.Session theSession = NXOpen.Session.GetSession();
    NXOpen.Part workPart = theSession.Parts.Work;
    NXOpen.Part displayPart = theSession.Parts.Display;
    // ----------------------------------------------
    //  Menü: Werkzeuge->Zeichnungsformat->Ränder und Zonen...
    // ----------------------------------------------
    NXOpen.Session.UndoMarkId markId1;
    markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");

    NXOpen.Drawings.BordersAndZones bordersAndZones1 = ((NXOpen.Drawings.BordersAndZones)workPart.Drafting.BordersAndZonesObjects.FindObject("Sheet 1"));
    NXOpen.Drawings.BordersAndZonesBuilder bordersAndZonesBuilder1;
    bordersAndZonesBuilder1 = workPart.Drafting.BordersAndZonesObjects.CreateBordersAndZonesBuilder(bordersAndZones1);

    theSession.SetUndoMarkName(markId1, "Ränder und Zonen-Dialogfenster");

    bordersAndZonesBuilder1.BorderAndZoneStyle.SheetBorderSettingsStyle.CenteringMarksHorizontal = NXOpen.Drawings.HorizontalCenteringMarkType.None;
    bordersAndZonesBuilder1.BorderAndZoneStyle.SheetBorderSettingsStyle.CenteringMarksVertical = NXOpen.Drawings.VerticalCenteringMarkType.None;

    bordersAndZonesBuilder1.BorderAndZoneStyle.SheetBorderSettingsStyle.CreateTrimmingMarks = false;

    NXOpen.Session.UndoMarkId markId2;
    markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Ränder und Zonen");

    NXOpen.NXObject nXObject1;
    nXObject1 = bordersAndZonesBuilder1.Commit();

    theSession.DeleteUndoMark(markId2, null);

    theSession.SetUndoMarkName(markId1, "Ränder und Zonen");

    bordersAndZonesBuilder1.Destroy();

    NXOpen.Session.UndoMarkId markId3;
    markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");

    NXOpen.Drawings.BordersAndZones bordersAndZones2 = ((NXOpen.Drawings.BordersAndZones)nXObject1);
    NXOpen.Drawings.BordersAndZonesBuilder bordersAndZonesBuilder2;
    bordersAndZonesBuilder2 = workPart.Drafting.BordersAndZonesObjects.CreateBordersAndZonesBuilder(bordersAndZones2);

    theSession.SetUndoMarkName(markId3, "Ränder und Zonen-Dialogfenster");

    // ----------------------------------------------
    //  Dialogfenster Anfang Ränder und Zonen
    // ----------------------------------------------
    NXOpen.Session.UndoMarkId markId4;
    markId4 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Ränder und Zonen");

    theSession.DeleteUndoMark(markId4, null);

    NXOpen.Session.UndoMarkId markId5;
    markId5 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Ränder und Zonen");

    NXOpen.NXObject nXObject2;
    nXObject2 = bordersAndZonesBuilder2.Commit();

    theSession.DeleteUndoMark(markId5, null);

    theSession.SetUndoMarkName(markId3, "Ränder und Zonen");

    bordersAndZonesBuilder2.Destroy();

    // ----------------------------------------------
    //  Menü: Werkzeuge->Zeichnungsformat->Titelfeld ausfüllen...
    // ----------------------------------------------
    NXOpen.Session.UndoMarkId markId6;
    markId6 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");

    NXOpen.Annotations.TitleBlock[] titleblocks1 = new NXOpen.Annotations.TitleBlock[1];

    // --------------------------------------------------
    // KORREKTUR:
    // Titelfeld suchen, ohne "HANDLE R-715" zu verwenden.
    // Der aufgezeichnete Handle verweist in dieser Datei
    // auf eine DatumAxis und verursacht InvalidCastException.
    // --------------------------------------------------
    NXOpen.Annotations.TitleBlock titleBlock1 = null;

    foreach (NXOpen.Annotations.TitleBlock currentTitleBlock
             in workPart.DraftingManager.TitleBlocks)
    {
      titleBlock1 = currentTitleBlock;
      break;
    }

    if (titleBlock1 == null)
    {
      throw new InvalidOperationException(
        "Im aktuellen Arbeitsteil wurde kein NX-Titelfeld gefunden.");
    }

    titleblocks1[0] = titleBlock1;

    NXOpen.Annotations.EditTitleBlockBuilder editTitleBlockBuilder1;
    editTitleBlockBuilder1 = workPart.DraftingManager.TitleBlocks.CreateEditTitleBlockBuilder(titleblocks1);

    NXOpen.Annotations.TitleBlockCellBuilderList titleBlockCellBuilderList1;
    titleBlockCellBuilderList1 = editTitleBlockBuilder1.Cells;

    theSession.SetUndoMarkName(markId6, "Titelfeld ausfüllen-Dialogfenster");

    NXOpen.TaggedObject taggedObject1;
    taggedObject1 = titleBlockCellBuilderList1.FindItem(0);

    NXOpen.Annotations.TitleBlockCellBuilder titleBlockCellBuilder1 = ((NXOpen.Annotations.TitleBlockCellBuilder)taggedObject1);
    NXOpen.TaggedObject taggedObject2;
    taggedObject2 = titleBlockCellBuilderList1.FindItem(1);

    NXOpen.Annotations.TitleBlockCellBuilder titleBlockCellBuilder2 = ((NXOpen.Annotations.TitleBlockCellBuilder)taggedObject2);
    NXOpen.TaggedObject taggedObject3;
    taggedObject3 = titleBlockCellBuilderList1.FindItem(2);

    NXOpen.Annotations.TitleBlockCellBuilder titleBlockCellBuilder3 = ((NXOpen.Annotations.TitleBlockCellBuilder)taggedObject3);
    NXOpen.TaggedObject taggedObject4;
    taggedObject4 = titleBlockCellBuilderList1.FindItem(3);

    NXOpen.Annotations.TitleBlockCellBuilder titleBlockCellBuilder4 = ((NXOpen.Annotations.TitleBlockCellBuilder)taggedObject4);
    NXOpen.Session.UndoMarkId markId7;
    markId7 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    theSession.DeleteUndoMark(markId7, null);

    NXOpen.Session.UndoMarkId markId8;
    markId8 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    // ----------------------------------------------
    //  First Issued -> aktuelles Datum (automatisch)
    // ----------------------------------------------
    string currentDate = GetCurrentDate();
    titleBlockCellBuilder1.EditableText = currentDate;

    editTitleBlockBuilder1.SetCellValueForLabel("First Issued", currentDate);

    theSession.SetUndoMarkName(markId8, "Titelfeld ausfüllen - First Issued");

    theSession.SetUndoMarkVisibility(markId8, null, NXOpen.Session.MarkVisibility.Visible);

    theSession.SetUndoMarkVisibility(markId6, null, NXOpen.Session.MarkVisibility.Invisible);

    NXOpen.Session.UndoMarkId markId9;
    markId9 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    theSession.DeleteUndoMark(markId9, null);

    NXOpen.Session.UndoMarkId markId10;
    markId10 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    titleBlockCellBuilder2.EditableText = "O.Mohite";

    editTitleBlockBuilder1.SetCellValueForLabel("Drawn By", "O.Mohite");

    theSession.SetUndoMarkName(markId10, "Titelfeld ausfüllen - Drawn By");

    theSession.SetUndoMarkVisibility(markId10, null, NXOpen.Session.MarkVisibility.Visible);

    theSession.SetUndoMarkVisibility(markId6, null, NXOpen.Session.MarkVisibility.Invisible);

    NXOpen.Session.UndoMarkId markId11;
    markId11 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    theSession.DeleteUndoMark(markId11, null);

    NXOpen.Session.UndoMarkId markId12;
    markId12 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    titleBlockCellBuilder3.EditableText = "Dozent";

    editTitleBlockBuilder1.SetCellValueForLabel("Checked By", "Dozent");

    theSession.SetUndoMarkName(markId12, "Titelfeld ausfüllen - Checked By");

    theSession.SetUndoMarkVisibility(markId12, null, NXOpen.Session.MarkVisibility.Visible);

    theSession.SetUndoMarkVisibility(markId6, null, NXOpen.Session.MarkVisibility.Invisible);

    NXOpen.Session.UndoMarkId markId13;
    markId13 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    theSession.DeleteUndoMark(markId13, null);

    NXOpen.Session.UndoMarkId markId14;
    markId14 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    titleBlockCellBuilder4.EditableText = "alfatraining";

    editTitleBlockBuilder1.SetCellValueForLabel("Approved By", "alfatraining");

    theSession.SetUndoMarkName(markId14, "Titelfeld ausfüllen - Approved By");

    theSession.SetUndoMarkVisibility(markId14, null, NXOpen.Session.MarkVisibility.Visible);

    theSession.SetUndoMarkVisibility(markId6, null, NXOpen.Session.MarkVisibility.Invisible);

    NXOpen.Session.UndoMarkId markId15;
    markId15 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    theSession.DeleteUndoMark(markId15, null);

    NXOpen.Session.UndoMarkId markId16;
    markId16 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    NXOpen.Session.UndoMarkId markId17;
    markId17 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Titelfeld ausfüllen");

    NXOpen.NXObject nXObject3;
    nXObject3 = editTitleBlockBuilder1.Commit();

    NXOpen.NXObject[] objects1;
    objects1 = editTitleBlockBuilder1.GetCommittedObjects();

    theSession.DeleteUndoMark(markId17, null);

    theSession.SetUndoMarkName(markId6, "Titelfeld ausfüllen");

    editTitleBlockBuilder1.Destroy();

    theSession.DeleteUndoMark(markId16, null);

    theSession.SetUndoMarkVisibility(markId6, null, NXOpen.Session.MarkVisibility.Visible);

    theSession.DeleteUndoMark(markId14, null);

    theSession.DeleteUndoMark(markId12, null);

    theSession.DeleteUndoMark(markId10, null);

    theSession.DeleteUndoMark(markId8, null);

    NXOpen.Session.UndoMarkId markId18;
    markId18 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");

    NXOpen.Drawings.DraftingDrawingSheet draftingDrawingSheet1 = ((NXOpen.Drawings.DraftingDrawingSheet)workPart.DraftingDrawingSheets.FindObject("Sheet 1"));
    NXOpen.Drawings.DraftingDrawingSheetBuilder draftingDrawingSheetBuilder1;
    draftingDrawingSheetBuilder1 = workPart.DraftingDrawingSheets.CreateDraftingDrawingSheetBuilder(draftingDrawingSheet1);

    draftingDrawingSheetBuilder1.MetricSheetTemplateLocation = "C:\\Program Files\\Siemens\\NX2412\\DRAFTING\\templates\\Drawing-A0-Size2D-template.prt";
    draftingDrawingSheetBuilder1.EnglishSheetTemplateLocation = "C:\\Program Files\\Siemens\\NX2412\\DRAFTING\\templates\\Drawing-A-Size2D-template.prt";

    // draftingDrawingSheetBuilder1.Height = 420.0;

    // draftingDrawingSheetBuilder1.Length = 594.0;

    draftingDrawingSheetBuilder1.StandardMetricScale = NXOpen.Drawings.DrawingSheetBuilder.SheetStandardMetricScale.S11;

    draftingDrawingSheetBuilder1.StandardEnglishScale = NXOpen.Drawings.DrawingSheetBuilder.SheetStandardEnglishScale.S11;

    draftingDrawingSheetBuilder1.ScaleNumerator = 1.0;

    draftingDrawingSheetBuilder1.ScaleDenominator = 1.0;

    draftingDrawingSheetBuilder1.Units = NXOpen.Drawings.DrawingSheetBuilder.SheetUnits.Metric;

    draftingDrawingSheetBuilder1.ProjectionAngle = NXOpen.Drawings.DrawingSheetBuilder.SheetProjectionAngle.Third;

    draftingDrawingSheetBuilder1.Number = "1";

    draftingDrawingSheetBuilder1.SecondaryNumber = "";

    draftingDrawingSheetBuilder1.Revision = "A";

    theSession.SetUndoMarkName(markId18, "Zeichnungsblatt-Dialogfenster");

    draftingDrawingSheetBuilder1.MetricSheetTemplateLocation = "C:\\Program Files\\Siemens\\NX2412\\DRAFTING\\templates\\Drawing-A0-Size2D-template.prt";

    // ----------------------------------------------
    //  Dialogfenster Anfang Zeichnungsblatt
    // ----------------------------------------------
    draftingDrawingSheetBuilder1.ProjectionAngle = NXOpen.Drawings.DrawingSheetBuilder.SheetProjectionAngle.First;

    NXOpen.Session.UndoMarkId markId19;
    markId19 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Zeichnungsblatt");

    theSession.DeleteUndoMark(markId19, null);

    NXOpen.Session.UndoMarkId markId20;
    markId20 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Zeichnungsblatt");

    NXOpen.NXObject nXObject4;
    nXObject4 = draftingDrawingSheetBuilder1.Commit();

    theSession.DeleteUndoMark(markId20, null);

    theSession.SetUndoMarkName(markId18, "Zeichnungsblatt");

    draftingDrawingSheetBuilder1.Destroy();

    // ----------------------------------------------
    //  Menü: Werkzeuge->Automatisierung->Journal->Aufzeichnung stoppen
    // ----------------------------------------------

  }

  public static int GetUnloadOption(string dummy)
  {
    return (int)NXOpen.Session.LibraryUnloadOption.Immediately;
  }
}