.. -*- coding: UTF-8 -*-

:Subtitle: All you wanted to know and much, much more...

.. _changelog:

Change Log
==========

Version Index
-------------
* `v2.4 - 18 April 2010`_
* `v2.3 - 14 October 2009`_
* `v2.2.1 - 08 August 2009`_
* `v2.2 - 08 June 2009`_
* `v2.2 beta - 15 May 2009`_
* `v2.1 - 26 February 2009`_
* `v2.1a - 07 February 2009`_
* `v2.0.1 - 10 January 2009`_
* `v2.0 - 30 November 2008`_
* `v1.13 - 24 July 2008`_
* `v1.12 - 10 May 2008`_
* `v1.11 - 11 April 2008`_
* `v1.10 - 19 March 2008`_
* `v1.9.1 - 02 February 2008`_
* `v1.9 - 16 January 2008`_
* `v1.8 - 30 November 2007`_
* `v1.6 - 30 September 2007`_
* `v1.5 - 03 August 2007`_
* `v1.4 - 30 April 2007`_
* `Previous versions - 04 April 2007`_


v2.4 - 18 April 2010
--------------------

2010-04-11 22:29 (#959) - ObjectListView/GlassPanelForm.cs, ObjectListView/ObjectListView.cs, ObjectListView/VirtualObjectListView.cs, ObjectListView/Properties/AssemblyInfo.cs, ObjectListView/ToolTipControl.cs
  - Prevent hyperlink processing from triggering spurious MouseUp events
  - Space filling columns correctly resize upon initial display
  - ShowHeaderInAllViews is better but still not working reliably.
  - Changed version to v2.4
  - Removed some Trace.WriteLines
  - Updated some comments

2010-04-11 22:08 (#958) - docs/whatsnew.rst, docs/animations.rst, docs/download.rst
  - Updated ready for v2.4
  - Added link to Sparkle project

2010-04-03 20:51 (#956) - docs/features.rst, docs/whatsnew.rst, docs/animations.rst, docs/changelog.rst, docs/index.rst, docs/recipes.rst
  - Added more v2.4 documentation, esp animations

2010-03-24 18:20 (#954) - docs/faq.rst, docs/recipes.rst
  - Updates recipes with new header formatting scheme
  - Explained how to hide a primary column

2010-03-24 18:19 (#953) - ObjectListView/ObjectListView.cs, Demo/MainForm.Designer.cs, Demo/MainForm.cs, ObjectListView/Styles.cs, ObjectListView/HeaderControl.cs, Demo/MainForm.resx
  - Tweaked header styles. Now work flawlessly (famous last words)

2010-03-23 07:41 (#952) - ObjectListView/ObjectListView.cs, Demo/MainForm.Designer.cs, Demo/ObjectListViewDemo2008.csproj, Demo/MainForm.cs, ObjectListView/Styles.cs, ObjectListView/HeaderControl.cs, Demo/MainForm.resx
  - Added headerFormatStyle and supporting code

2010-03-17 20:32 (#948) - ObjectListView/ObjectListView.cs, ObjectListView/TreeListView.cs, ObjectListView/Renderers.cs
  - Changed object checking so that objects can be pre-checked before they are added to the list.
  - Made all Tree related class public so they can subclassed
  - TreeRenderers are now HighlightTextRenderers so they can do text highlighting

2010-03-16 16:56 (#947) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - TreeListView now shows filtering
  - Made naming of lists consistent

2010-03-16 16:55 (#946) - docs/recipes.rst
  - Added section about filtering and virtual lists

2010-03-16 16:53 (#945) - ObjectListView/ObjectListView.cs, ObjectListView/FastObjectListView.cs
  - Hide "Groups" property so it is not visible within the IDE properties grid

2010-03-16 16:52 (#944) - ObjectListView/TreeListView.cs
  - TreeListView now supports filtering

2010-03-16 16:50 (#943) - Tests/TestFilters.cs
  - Removed ListFilter tests from TreeListView

2010-03-13 20:48 (#942) - ObjectListView/ObjectListView.cs, Demo/MainForm.Designer.cs, docs/animations.rst, docs/conf.py, docs/faq.rst, docs/index.rst, docs/recipes.rst, Demo/MainForm.resx
  - Ctrl-A now selects all if SelectAllOnControlA is true
  - Updated docs
  - F2 is no longer swallowed

2010-03-11 20:30 (#941) - ObjectListView/GlassPanelForm.cs, ObjectListView/ObjectListView.cs, Demo/MainForm.Designer.cs, , Demo/MainForm.resx
  - Overylays work correctly in MDI applications (more or less)

2010-03-11 17:15 (#940) - ObjectListView/GlassPanelForm.cs, ObjectListView/ObjectListView.cs, ObjectListView/VirtualListDataSource.cs, ObjectListView/ObjectListView2008.csproj, ObjectListView/Events.cs, ObjectListView/VirtualObjectListView.cs, ObjectListView/TreeListView.cs, ObjectListView/VirtualGroups.cs, ObjectListView/Filters.cs, ObjectListView/DropSink.cs, ObjectListView/Renderers.cs, ObjectListView/Adornments.cs, ObjectListView/FastObjectListView.cs
  - Added filtering, and HighlightTextRenderer
  - Overlays now work with MDI

2010-03-11 17:13 (#939) - ListViewPrinter/ListViewPrinter.cs
  - Fixed bug with cell values using special renderers

2010-03-11 17:12 (#938) - docs/animations.rst, docs/faq.rst, docs/recipes.rst, docs/images/text-filter-highlighting.png
  - Added animation docs
  - Added filter docs

2010-03-11 17:12 (#937) - Demo/MainForm.Designer.cs, Demo/ObjectListViewDemo2008.csproj, Demo/Resource1.Designer.cs, Demo/MainForm.cs, Demo/OlvDecorationAdapter.cs, Demo/Resources/goldstart-32.png, Demo/MainForm.resx, Demo/Resource1.resx
  - Added filtering demos
  - Add animations

2010-03-11 17:11 (#936) - ObjectListView2008.sln
  - Added Sparkle library for animations

2010-03-11 17:11 (#935) - Tests/Tests2008.csproj, Tests/TestFilters.cs
  - Added tests for filters

2010-01-19 23:10 (#922) - ObjectListView/ObjectListView.cs
  - Overlays can be turned off. They also only work on 32-bit displays

2009-10-31 07:03 (#919) - ObjectListView/ObjectListView.cs, ObjectListView/Renderers.cs
  - Plugged possible resource leak by using using() with CreateGraphics()

2009-10-31 07:01 (#918) - ObjectListView/HeaderControl.cs
  - Plugged GDI resource leak, where font handles were created during custom drawing, but never destroyed

2009-10-30 00:56 (#917) - ObjectListView/ObjectListView.cs
  - Fix bug when right clicking in the empty area of the header

2009-10-30 00:55 (#916) - ObjectListView/GlassPanelForm.cs
  - Use FindForm() rather than TopMostControl, since the latter doesn't work as I expected when the OLV is part of an MDI child window.

2009-10-28 09:35 (#915) - ObjectListView/ObjectListView.cs
  - Redraw the control after setting EmptyListMsg property
  - Added Dispose() method to properly release resources

2009-10-28 09:34 (#914) - ObjectListView/VirtualListDataSource.cs, ObjectListView/Munger.cs, ObjectListView/DragSource.cs, ObjectListView/DataListView.cs, ObjectListView/TypedObjectListView.cs, ObjectListView/Events.cs, ObjectListView/Overlays.cs, ObjectListView/VirtualObjectListView.cs, ObjectListView/CellEditors.cs, ObjectListView/NativeMethods.cs, ObjectListView/Decorations.cs, ObjectListView/Adornments.cs, ObjectListView/FastObjectListView.cs, ObjectListView/GlassPanelForm.cs, ObjectListView/Groups.cs, ObjectListView/Styles.cs, ObjectListView/ObjectListView.DesignTime.cs, ObjectListView/VirtualGroups.cs, ObjectListView/TreeListView.cs, ObjectListView/Attributes.cs, ObjectListView/Generator.cs, ObjectListView/Renderers.cs, ObjectListView/DropSink.cs, ObjectListView/HeaderControl.cs, ObjectListView/ToolTipControl.cs, ObjectListView/Comparers.cs
  - Added v2.3 marker

2009-10-18 23:27 (#913) - ObjectListView/ObjectListView.cs
  - Redraw the control after changing the empty msg



v2.3 - 14 October 2009
----------------------

2009-10-14 07:28 (#910) - docs/images/fancy-screenshot2.png, docs/samples.rst, docs/.templates/layout.html, docs/changelog.rst, docs/index.rst
  - v2.3 release

2009-10-04 05:51 (#905) - ObjectListView/ObjectListView.cs
  - Explain why we need ApplyExtendedStyles() instead of using CreateParams

2009-10-04 05:50 (#904) - ObjectListView/HeaderControl.cs
  - Handle when ListView.HeaderStyle is None

2009-10-04 05:50 (#903) - ObjectListView/Adornments.cs
  - Update some DefaultValues so that code generation is better

2009-09-29 04:49 (#900) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Use DescribedTaskRenderer to show that it works

2009-09-29 04:48 (#899) - ObjectListView/Renderers.cs
  - Added DescribedTaskRenderer

2009-09-29 04:48 (#898) - docs/samples.rst, docs/.templates/layout.html, docs/.static/samples-icon.png
  - Updates samples
  - Put Samples into main menu

2009-09-23 08:20 (#888) - ObjectListView/ToolTipControl.cs
  - Removed debug print

2009-09-23 08:20 (#887) - ObjectListView/Decorations.cs
  - Added LeftColumn and RightColumn to RowBorderDecoration

2009-09-23 08:19 (#886) - ObjectListView/Adornments.cs
  - Added Wrap property to TextAdornment, to allow text wrapping to be disabled
  - Added ShrinkToWidth property to ImageAdornment

2009-09-22 20:16 (#885) - ObjectListView/ObjectListView.csproj
  - Renamed OLVGroup.cs to Groups.cs

2009-09-22 19:45 (#884) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Added hyperlink to Fast tab

2009-09-17 08:57 (#876) - ObjectListView/ObjectListView.cs
  - Added OwnerDrawnHeader. Set this to true if you want to owner draw the header yourself.

2009-09-17 06:33 (#874) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Allow for Vista style selection

2009-09-16 06:29 (#873) - ObjectListView/ObjectListView.cs, ObjectListView/NativeMethods.cs
  - Added UseExplorerTheme

2009-09-16 03:28 (#872) - Tests/MainForm.Designer.cs, Tests/Program.cs, Tests/MainForm.cs, Tests/SetupTestSuite.cs, Tests/TestAdornments.cs, Tests/TestFormatting.cs, Tests/TestTreeView.cs, Tests/TestColumn.cs, Tests/TestCheckBoxes.cs, Tests/TestBasics.cs, Tests/TestSelection.cs, Tests/TestSorting.cs
  - Cleaned up using statements

2009-09-16 03:24 (#870) - ObjectListView/Groups.cs
  - Changed file name from OLVGroup.cs to Groups.cs

2009-09-15 18:12 (#866) - ObjectListView/OLVGroup.cs
  - Updated docs

2009-09-15 18:12 (#865) - ObjectListView/NativeMethods.cs
  - Added SetExtendedStyle()

2009-09-15 18:11 (#864) - ObjectListView/ObjectListView.cs
  - Added ShowHeaderInAllViews. To make this work, Columns are no longer changed when switching to/from Tile view.

2009-09-12 19:39 (#860) - ObjectListView/ObjectListView.DesignTime.cs
  - ObjectListViewDesigner now removes tooltips since they cause problems when set in the IDE.
  - ObjectListViewDesigner is NOT enabled by default because of the problems of trying to duplicate the functionality of .NET's internal ListViewDesigner

2009-09-12 06:44 (#856) - ObjectListView/ObjectListView.cs
  - Added OLVColumn.AutoCompleteEditor to allow the autocomplete of cell editors to be disabled.

2009-09-11 07:44 (#855) - ObjectListView/ObjectListView.cs
  - Cleaned up code a little

2009-09-11 07:43 (#854) - ObjectListView/Renderers.cs
  - Cleaned up code a little

2009-09-11 07:42 (#852) - ObjectListView/Generator.cs
  - Allow for an attribute having a null Title

2009-09-11 07:41 (#851) - ObjectListView/Attributes.cs
  - Added default constructor

2009-09-11 07:40 (#850) - ObjectListView/OLVGroup.cs
  - Added Collapsed and Collapsible properties

2009-09-03 08:18 (#846) - ObjectListView/TreeListView.cs
  - Fixed off-by-one error that was messing up hit detection

2009-09-03 00:43 (#845) - ObjectListView/ObjectListView.cs
  - Correct incorrect attribute on SelectedRowDecoration

2009-09-03 00:42 (#844) - ObjectListView/DropSink.cs
  - Correctly handle case where RefreshObjects() is called for objects that were children but are now roots.

2009-09-02 23:25 (#843) - ObjectListView/OLVGroup.cs
  - Cleaned up code, added more docs
  - Works under VS2005 again

2009-09-02 23:25 (#842) - ObjectListView/GlassPanelForm.cs, ObjectListView/ObjectListView.cs, ObjectListView/HeaderControl.cs, ObjectListView/Renderers.cs
  - Changed to use ObjectListView.TextRendereringHint rather than hardcoding a hint

2009-09-02 23:23 (#841) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Select All button on virtual tab works again

2009-09-02 23:22 (#840) - docs/download.rst
  - Added info about 2.3 SVN branch

2009-09-01 05:58 (#839) - docs/whatsnew.rst, docs/download.rst
  - Added docs for v2.3a release

2009-09-01 05:58 (#838) - ObjectListView/OLVGroup.cs, Demo/ObjectListViewDemo.csproj, ObjectListView/ObjectListView.csproj
  - Made compatible with VS2005 again

2009-09-01 00:31 (#837) - ObjectListView/ObjectListView.cs
  - Added group formatting to supercharge what is possible with groups
  - Virtual groups now work
  - Extended MakeGroupies() to handle more aspects of group creation

2009-08-31 07:26 (#831) - Demo/MainForm.Designer.cs, Demo/ObjectListViewDemo2008.csproj, Demo/MainForm.cs, Demo/MainForm.resx
  - File explorer tab can now show various style of hot row highlighting

2009-08-31 07:25 (#830) - ObjectListView/GroupingStrategy.cs, ObjectListView/GlassPanelForm.cs, ObjectListView/ObjectListView.cs, ObjectListView/ObjectListView2008.csproj, ObjectListView/VirtualObjectListView.cs, ObjectListView/VirtualGroups.cs, ObjectListView/TreeListView.cs, ObjectListView/Decorations.cs
  - Reworked virtual groups. Only virtual lists need a grouping strategy now
  - Tweaked some decorations

2009-08-30 08:02 (#829) - ObjectListView/ObjectListView.cs, ObjectListView/VirtualObjectListView.cs
  - Menu commands are now localizable
  - Virtual lists don't get any grouping strategy by default

2009-08-30 01:00 (#825) - ObjectListView/VirtualObjectListView.cs
  - BIG CHANGE. Virtual lists can now have groups!

2009-08-30 00:59 (#823) - ObjectListView/Renderers.cs
  - Fixed bug where some of a cell's background was not erased.

2009-08-30 00:58 (#821) - ObjectListView/ObjectListView.cs
  - Added new grouping properties and capabilities: OLVGroup, GroupImageList, GroupingStrategy, SpaceBetweenGroups, OLVColumn.GroupFormatter
  - Enhanced MakeGroupies() to be capable of handling new groups
  - Fixed problem where grid lines would become confused when the listview was scrolled using the mouse.

2009-08-30 00:50 (#819) - ObjectListView/NativeMethods.cs
  - Added structures to help with new group operations

2009-08-30 00:50 (#818) - ObjectListView/HeaderControl.cs
  - Handle the header being destroyed

2009-08-30 00:48 (#817) - ObjectListView/FastObjectListView.cs
  - Added GroupingStrategy
  - Added optimized Objects property

2009-08-30 00:48 (#816) - ObjectListView/Events.cs
  - Added group events

2009-08-30 00:46 (#814) - ObjectListView/Comparers.cs
  - Added OLVGroupComparer

2009-08-30 00:45 (#813) - ObjectListView/Adornments.cs
  - Made clear which 'ContentAlignment' I wanted

2009-08-30 00:44 (#812) - ObjectListView/GroupingStrategy.cs, ObjectListView/OLVGroup.cs, ObjectListView/VirtualListDataSource.cs
  - Initial checkin

2009-08-28 06:51 (#805) - ObjectListView/TreeListView.cs, ObjectListView/DropSink.cs
  - Fixed bug when dragging a node from one place to another in the tree
  - Added ModelDropEventArgs.RefreshObjects() to simplify updating after a drag-drop operation

2009-08-25 00:24 (#799) - ObjectListView/ObjectListView.cs
  - Added ability to show basic column commands when header is right clicked
  - Added SelectedRowDecoration, UseTranslucentSelection and UseTranslucentHotItem.
  - Added PrimarySortColumn and PrimarySortOrder
  - Correct problems with standard hit test and subitems
  - Support Decorations
  - Added header formatting capabilities: font, color, word wrap
  - Gave ObjectListView its own designer to hide unwanted properties
  - Separated design time stuff into separate file
  - Added FormatRow and FormatCell events
  - Get around bug in HitTest when not FullRowSelect
  - Added OLVListItem.GetSubItemBounds() method which works correctly for all columns including column 0
  - Added HotItemChanged event

2009-08-25 00:22 (#797) - ObjectListView/Styles.cs
  - Added Decoration and Overlay properties to HotItemStyle

2009-08-25 00:20 (#796) - ObjectListView/Renderers.cs
  - Correctly MeasureText() using the appropriate graphic context
  - Handle translucent selection setting

2009-08-25 00:18 (#795) - ObjectListView/Overlays.cs
  - Overlays now use Adornments
  - Added ITransparentOverlay interface. Overlays can now have separate transparency levels
  - Moved decoration related code to new file

2009-08-25 00:16 (#794) - ObjectListView/ObjectListView.csproj
  - Added new files to project

2009-08-25 00:15 (#793) - ObjectListView/ObjectListView2008.csproj
  - Added new files to project

2009-08-25 00:15 (#792) - ObjectListView/NativeMethods.cs
  - Added new stuff

2009-08-25 00:14 (#791) - ObjectListView/HeaderControl.cs
  - Added formatting capabilities: font, color, word wrap
  - Correctly handle header themes

2009-08-25 00:13 (#790) - ObjectListView/GlassPanelForm.cs
  - Each glass panel now only draws one overlays
  - Only hide the glass pane on resize, not on move

2009-08-25 00:12 (#789) - ObjectListView/Events.cs
  - Added HotItem event

2009-08-25 00:10 (#788) - ObjectListView/DropSink.cs
  - Changed to use OlvHitTest()

2009-08-25 00:09 (#787) - ObjectListView/Decorations.cs
  - Initial version

2009-08-25 00:09 (#786) - ObjectListView/CellEditors.cs
  - Standardized code formatting

2009-08-25 00:08 (#785) - ObjectListView/ObjectListView.DesignTime.cs, ObjectListView/Attributes.cs, ObjectListView/Generator.cs, ObjectListView/Adornments.cs
  - Initial version

2009-08-25 00:04 (#784) - ListViewPrinter/ListViewPrinter.cs
  - Removed all references of MONO symbol

2009-08-25 00:04 (#783) - docs/whatsnew.rst
  - First take of v2.3 documentation

2009-08-25 00:03 (#782) - Demo/Photos/jr.png, Demo/ObjectListViewDemo2008.csproj, Demo/MainForm.Designer.cs, Demo/Photos/sj.png, Demo/Resource1.Designer.cs, Demo/MainForm.cs, Demo/Photos/ns.png, Demo/Photos/sp.png, Demo/Resource1.resx, Demo/MainForm.resx, Demo/Photos/gab.png, Demo/Photos/ak.png, Demo/Photos/mb.png, Demo/ObjectListViewDemo.csproj, Demo/Photos/cp.png, Demo/Photos/Thumbs.db, Demo/Photos/cr.png, Demo/Photos/gp.png, Demo/Photos/es.png, Demo/Photos/jp.png
  - Changed to show off many v2.3 features
  - Made BusinessCardOverlay
  - Removed all references to MONO symbol
  - Use Segoe font under Vista
  - Reduced size of photos

2009-08-24 23:59 (#781) - Tests/MainForm.Designer.cs, Tests/Tests2008.csproj, Tests/TestAdornments.cs, Tests/Tests.csproj, Tests/TestGenerator.cs
  - Added new tests: adornments, formatting, generator



v2.2.1 - 08 August 2009
-----------------------

2009-08-08 17:43 (#741) - ObjectListView/ObjectListView.cs
  - Added hyperlinks
  - Use new scheme for formatting rows/cells
  - Added Hot* properties that track where the mouse is
  - Overrode TextAlign on columns so that column 0 can have something other than just left alignment.
  - Redraw EmptyListMsg when the list is horizontally scrolled

2009-08-08 17:37 (#740) - ObjectListView/VirtualObjectListView.cs
  - Use new scheme for formatting rows/cells

2009-08-08 17:36 (#739) - ObjectListView/Renderers.cs
  - Use OLVListSubItem instead of ListViewItem.ListViewSubItem

2009-08-08 17:34 (#736) - ObjectListView/Events.cs
  - Added Hyperlink events
  - Added Formatting events
  - Use OLVListSubItem instead of ListViewItem.ListViewSubItem

2009-08-08 17:31 (#735) - Tests/Tests2008.csproj, Tests/TestFormatting.cs, Tests/TestColumn.cs, Tests/TestCheckBoxes.cs, Tests/TestBasics.cs
  - Added test for formatting events
  - Reformatted code

2009-08-06 21:47 (#727) - docs/download.rst
  - Tweaked sizes of downloads for v2.2.1

2009-08-06 21:29 (#725) - Demo/ObjectListViewDemo2008.csproj, Demo/AssemblyInfo.cs, ObjectListView/ObjectListView2008.csproj, ObjectListView/Properties/AssemblyInfo.cs
  - Update version info to 2.2.1

2009-08-06 21:01 (#724) - docs/.templates/layout.html, docs/blog3.rst, docs/changelog.rst, docs/download.rst
  - Prepare docs for v2.2.1 release

2009-08-05 17:28 (#722) - ObjectListView/ObjectListView.cs, ObjectListView/Overlays.cs
  - Add Bounds property to OLVListItem, which handles the case of the list item belonging to a collapsed group

2009-08-05 02:12 (#718) - ObjectListView/ObjectListView.cs
  - Subitem edit rectangles always allowed for an image in the cell, even if there was none. Now they only allow for an image when there actually is one.
  - Update documentation in several places

2009-08-05 02:10 (#716) - ObjectListView/TreeListView.cs
  - Ignore events left of the expand button, even for rows that don't have an expand button

2009-08-05 02:06 (#714) - docs/features.rst, docs/whatsnew.rst, docs/blog.rst, docs/conf.py, docs/changelog.rst, docs/recipes.rst
  - Documented cell events
  - Updated for v2.2.1 release

2009-08-03 06:53 (#713) - docs/.templates/layout.html
  - Removed Donate link

2009-08-03 06:52 (#712) - docs/images/blog3-listview3.png, docs/images/blog3-listview4.png, docs/blog.rst, docs/blog3.rst, docs/index.rst, docs/images/blog3-listview1.png, docs/.static/blog3-icon.png, docs/images/blog3-listview1a.png, docs/images/blog3-listview2.png
  - Added blog entry to ListViewSubItem.Bounds bug

2009-07-27 08:22 (#703) - ObjectListView/ObjectListView.cs
  - The cell edit rectangle is now correctly calculated when the listview is scrolled horizontally.

2009-07-27 08:20 (#702) - ObjectListView/Renderers.cs
  - Try to honour CanWrap setting when GDI rendering text.

2009-07-27 08:19 (#701) - ObjectListView/VirtualObjectListView.cs
  - Added specialised version of RefreshSelectedObjects() which works efficiently with virtual lists

2009-07-27 07:23 (#700) - ObjectListView/Overlays.cs
  - TintedColumnDecoration now works when last item is a member of a collapsed group (well, it no longer crashes).

2009-07-27 07:16 (#699) - ObjectListView/NativeMethods.cs
  - Added GetScrolledColumnSides()

2009-07-27 07:16 (#698) - ObjectListView/ObjectListView.cs
  - Avoided bug in .NET framework involving column 0 of owner drawn listviews not being redrawn when the listview was scrolled horizontally.

2009-07-15 06:55 (#690) - ObjectListView/TreeListView.cs
  - Clicks to the left of the expander in tree cells are now ignored.

2009-07-15 06:54 (#689) - ObjectListView/ObjectListView.cs
  - If the user clicks/double clicks on a tree list cell, an edit operation will not begin if the click was to the left of the expander. This is implemented in such a way that other renderers can have similar "dead" zones.

2009-07-13 04:46 (#685) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Added code to test CellOver events

2009-07-12 22:36 (#683) - ObjectListView/ObjectListView.cs
  - Added CellOver event

2009-07-12 07:43 (#681) - ObjectListView/ObjectListView.cs
  - CalculateCellBounds() messed with the FullRowSelect property, which confused the tooltip handling on the underlying control. It no longer does this.
  - If the user clicks/double clicks on a cell, an edit operation will begin only if the clicks were on the image or text.
  - The cell edit rectangle is now correctly calculated for owner-drawn, non-Details views.

2009-07-12 07:42 (#680) - ObjectListView/Events.cs
  - Added HitTest property to CellEventArgs

2009-07-11 20:36 (#679) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/ShellUtilities.cs, Demo/MainForm.resx
  - Added Cell events
  - Demo drag and drop in tree list view
  - SysImageHelper no longer caches images

2009-07-11 20:35 (#678) - ObjectListView/ObjectListView.cs
  - Added Cell events
  - Made BuildList(), AddObject() and RemoveObject() thread-safe
  - AfterSearchingEventArgs events can now be Handled

2009-07-11 20:31 (#677) - ObjectListView/ToolTipControl.cs
  - Moved ToolTipShowingEventArgs to Events.cs

2009-07-11 20:30 (#676) - ObjectListView/Renderers.cs
  - Correctly calculate edit rectangle for subitems of a tree view (previously subitems were indented in the same way as the primary column)

2009-07-11 20:30 (#675) - ObjectListView/Events.cs
  - Added Cell events
  - Moved all event parameter blocks to this file.
  - Added Handled property to AfterSearchEventArgs

2009-07-11 18:49 (#669) - docs/recipes.rst
  - Updated description of how to use a RowFormatter

2009-07-07 06:37 (#656) - ObjectListView/VirtualObjectListView.cs
  - Don't try to fetch objects in GetModelObject when the index is negative

2009-07-07 06:36 (#655) - ObjectListView/DropSink.cs
  - Added StandardDropActionFromKeys property to OlvDropEventArgs

2009-07-07 06:36 (#654) - ObjectListView/DragSource.cs
  - Make sure Link is acceptable as an drop effect by default

2009-07-07 06:36 (#653) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Give example of using simple drag and drop in tree list view

2009-07-04 20:15 (#652) - ObjectListView/NativeMethods.cs
  - Added SetTooltipControl()

2009-07-04 20:12 (#651) - ObjectListView/ObjectListView.cs
  - Space bar now properly toggles checkedness of selected rows

2009-07-04 20:09 (#650) - ObjectListView/VirtualObjectListView.cs
  - Standardized code format

2009-07-03 22:36 (#649) - docs/download.rst, docs/ownerDraw.rst
  - Update version info on downloads page
  - Rewrote some parts of owner drawn

2009-07-03 21:33 (#648) - docs/.templates/layout.html
  - Added tracer template

2009-07-03 16:25 (#647) - ObjectListView/ObjectListView.cs
  - Fixed bug with tooltips when the underlying Windows control was destroyed.
  - CellToolTipShowing events are now triggered in all views.



v2.2 - 08 June 2009
-------------------

2009-06-08 23:57 (#643) - ObjectListView/NativeMethods.cs
  - Fixed bug in GetWindowLong/SetWindowLong that appears on 64-bit OSes

2009-06-08 07:29 (#640) - docs/changelog.rst
  - Update change log for v2.2 release

2009-06-07 23:58 (#638) - docs/recipes.rst
  - Added two new recipes

2009-06-07 23:58 (#637) - docs/features.rst, docs/blog2.rst, docs/index.rst
  - Added information about collapsible groups and blogs

2009-06-07 20:10 (#636) - docs/blog2.rst, docs/faq.rst, docs/recipes.rst
  - Updated tooltips docs to reflect vista situation

2009-06-07 20:09 (#635) - Demo/MainForm.cs
  - Don't use balloon tooltips under Vista

2009-06-07 20:08 (#634) - ObjectListView/ObjectListView2008.csproj
  - Undefined TRACE constant from project

2009-06-07 20:07 (#633) - ObjectListView/ToolTipControl.cs
  - Added change log entry

2009-06-07 22:40 (#631) - ObjectListView/NativeMethods.cs
  - Renamed TOOLTIPTEXT to NMTTDISPINFO

2009-06-07 22:39 (#630) - ObjectListView/ObjectListView.cs
  - Fixed rare bug in UnapplyHotItemStyle()

2009-06-07 22:38 (#629) - ObjectListView/Renderers.cs
  - Tweaked text rendering so that column 0 isn't ellipsed unnecessarily.

2009-06-07 22:37 (#628) - ObjectListView/ToolTipControl.cs
  - Fixed some vista specific problems

2009-06-06 00:55 (#627) - ObjectListView/GlassPanelForm.cs, ObjectListView/ObjectListView.cs, ObjectListView/NativeMethods.cs
  - Overlays and tooltips now work on TopMost forms

2009-06-04 00:30 (#626) - docs/whatsnew.rst, docs/.templates/layout.html, docs/blog2.rst, docs/conf.py, docs/changelog.rst, docs/recipes.rst
  - v2.2 documentation complete

2009-06-03 20:44 (#625) - ObjectListView/VirtualObjectListView.cs
  - BuildList() now also updates the Virtual list size

2009-06-03 19:43 (#623) - ObjectListView/Events.cs
  - BeforeSortingEventArgs now has a Handled property to let event handlers do the item sorting themselves.

2009-06-03 19:42 (#622) - ObjectListView/ObjectListView.cs
  - BeforeSortingEventArgs now has a Handled property to let event handlers do the item sorting themselves.
  - AlwaysGroupByColumn works again, as does SortGroupItemsByPrimaryColumn and all their various permutations.
  - SecondarySortOrder and SecondarySortColumn are now "null" by default

2009-06-03 19:08 (#621) - ObjectListView/Events.cs
  - Added ColumnToGroupBy and GroupByOrder to sorting events

2009-06-03 19:07 (#620) - ObjectListView/Comparers.cs
  - Fixed bug where ModelObjectComparer would crash if secondary sort column was null.

2009-06-01 20:24 (#619) - ObjectListView/ObjectListView.cs, ObjectListView/Overlays.cs
  - Added GetLastItemInDisplayOrder()
  - TintedColumnDecoration now uses GetLastItemInDisplayOrder()

2009-06-01 20:24 (#618) - ObjectListView/ObjectListView.csproj
  - Added ToolTipControl.cs

2009-06-01 19:41 (#617) - Demo/MainForm.Designer.cs, Demo/MainForm.resx
  - Simple tab now uses tristate checkbox
  - Resized to be 800x600

2009-06-01 19:39 (#616) - ObjectListView/Renderers.cs
  - Removed FlagRenderer<T>

2009-06-01 19:39 (#615) - ObjectListView/Overlays.cs
  - Make sure that TintedColumnDecoration reaches to the last item in group view

2009-06-01 19:38 (#614) - ObjectListView/NativeMethods.cs
  - Updated docs

2009-06-01 19:38 (#613) - ObjectListView/HeaderControl.cs
  - Updated docs

2009-06-01 19:38 (#612) - ObjectListView/Events.cs
  - Updated docs

2009-06-01 19:38 (#611) - ObjectListView/DropSink.cs
  - Updated docs

2009-05-30 20:07 (#608) - docs/features.rst, docs/whatsnew.rst, docs/blog.rst, docs/blog1.rst, docs/overlays.rst, docs/blog2.rst, docs/.templates/layout.html, docs/index.rst, docs/Sitemap.xml, docs/recipes.rst, docs/.static/blog1-icon.png, docs/.static/overlays-icon.png, docs/images/blog2-balloon1.png, docs/.static/blog2-icon.png, docs/images/blog2-balloon2.png
  - Added docs about tooltip customisation
  - Added blog
  - Update features

2009-05-21 17:11 (#602) - Demo/MainForm.Designer.cs, Demo/MainForm.cs
  - KeyPress testing

2009-05-21 17:09 (#600) - ObjectListView/ObjectListView.csproj
  - Removed GlassPanelForm dependants

2009-05-21 17:08 (#599) - ObjectListView/ObjectListView.cs
  - Fixed bug so that KeyPress events are again fired
  - Made overlay methods virtual

2009-05-21 07:20 (#597) - ObjectListView/DropSink.cs
  - Added a Handled flag to OlvDropEventArgs
  - Tweaked the appearance of the drop-on-background feedback



v2.2 beta - 15 May 2009
-----------------------

2009-05-15 22:36 (#592) - ObjectListView/GlassPanelForm.Designer.cs, ObjectListView/GlassPanelForm.cs, ObjectListView/ObjectListView.cs, ObjectListView/ObjectListView2008.csproj, ObjectListView/GlassPanelForm.resx
  - Simplified GlassPanelForm
  - Added subitem stuff to custom draw

2009-05-13 06:08 (#590) - docs/whatsnew.rst
  - Added new TreeListView features

2009-05-13 06:08 (#589) - Tests/Program.cs, Tests/TestTreeView.cs
  - Added tests for tree traversal operations
  - Use DiscardAllState() between tests

2009-05-13 06:07 (#588) - ObjectListView/TreeListView.cs
  - Added tree traverse operations: GetParent and GetChildren.
  - Added DiscardAllState() to completely reset the TreeListView.

2009-05-12 22:47 (#587) - Demo/MainForm.Designer.cs, Demo/MainForm.cs
  - "Remove" on Simple tab removes all selected objects

2009-05-12 22:46 (#586) - docs/.static/download-icon.png, docs/whatsnew.rst, docs/blog.rst, docs/overlays.rst, docs/.templates/layout.html, docs/download.rst, docs/changelog.rst, docs/index.rst
  - Added download page
  - Added Google analytics code
  - Refined whatsnew.rst for v2.2 release

2009-05-11 06:40 (#582) - ObjectListView/ObjectListView.cs, ObjectListView/ObjectListView2008.csproj, ObjectListView/TreeListView.cs, ObjectListView/HeaderControl.cs
  - Removed all unsafe code. The project no longer requires unsafe code

2009-05-09 19:40 (#580) - ObjectListView/ObjectListView.cs, ObjectListView/Overlays.cs
  - Minor refactorings and docs

2009-05-09 19:11 (#579) - docs/features.rst, docs/dragdrop.rst, docs/blog.rst, docs/changelog.rst, docs/index.rst, docs/gettingStarted.rst, docs/recipes.rst
  - v2.2 docs - Take II

2009-05-09 19:10 (#578) - Demo/MainForm.Designer.cs, Demo/MainForm.cs
  - Added "Refresh" button to TreeList tab

2009-05-09 19:10 (#577) - Tests/Program.cs, Tests/TestTreeView.cs, Tests/Person.cs
  - Added more tests for TreeListView

2009-05-09 19:10 (#576) - ObjectListView/TreeListView.cs
  - Fixed bug where any command (Expand/Collapse/Refresh) on a model object that was once visible but that is currently in a collapsed branch would cause the control to crash.

2009-05-09 09:02 (#575) - ObjectListView/ObjectListView.cs, ObjectListView/Overlays.cs
  - Added SelectedColumnTintColor property
  - Changed SelectedColumnOverlay to be TintedColumnDecoration

2009-05-09 06:58 (#574) - ObjectListView/TreeListView.cs
  - Fixed bug where RefreshObjects() would fail when none of the given objects were present/visible.

2009-05-09 06:58 (#573) - ObjectListView/ObjectListView.cs
  - Use SmallImageSize property whenever possible

2009-05-09 06:56 (#572) - ObjectListView/Renderers.cs
  - Use SmallImageSize property whenever possible

2009-05-09 06:55 (#571) - ObjectListView/DropSink.cs
  - Use SmallImageSize property whenever possible
  - Updated docs

2009-05-08 07:06 (#569) - ObjectListView/GlassPanelForm.cs, ObjectListView/ObjectListView.cs, ObjectListView/HeaderControl.cs, ObjectListView/NativeMethods.cs
  - Don't show glass panel in design mode

2009-05-06 23:45 (#568) - ObjectListView/GlassPanelForm.cs, ObjectListView/Overlays.cs
  - Unified BillboardOverlay text rendering with that of TextOverlay
  - Improved docs

2009-05-06 21:31 (#567) - ObjectListView/ObjectListView.cs, ObjectListView/Events.cs, ObjectListView/Renderers.cs, ObjectListView/NativeMethods.cs
  - Added Scroll event
  - Added Unfocused foreground and background colors (thanks to Christophe Hosten)

2009-05-06 21:25 (#565) - docs/images/dragdrop-dropbetween.png, docs/whatsnew.rst, docs/dragdrop.rst, docs/images/dragdrop-feedbackcolor.png, docs/conf.py, docs/images/blog-badscroll.png, docs/index.rst, docs/.static/dragdrop-icon.png, docs/images/emptylistmsg-example.png, docs/images/blog-setbkimage.png, docs/images/dragdrop-dropsubitem.png, docs/images/dragdrop-infomsg.png, docs/blog.rst, docs/.static/Thumbs.db, docs/images/dragdrop-dropbackground.png, docs/images/blog-overlayimage.png, docs/recipes.rst, docs/.static/blog-icon.png, docs/images/dragdrop-example1.png
  - First take at v2.2 documentation

2009-05-05 17:25 (#564) - ObjectListView/ObjectListView.cs, ObjectListView/Overlays.cs, ObjectListView/DropSink.cs
  - Removed transparency parameter from IOverlay interface
  - Correctly translate the graphic for decorations

2009-05-05 08:48 (#562) - ObjectListView/GlassPanelForm.cs, ObjectListView/ObjectListView.cs, Demo/MainForm.cs, ObjectListView/NativeMethods.cs
  - Changed to always use glass overlay

2009-05-01 23:51 (#558) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/ObjectListViewDemo.csproj, Demo/MainForm.resx
  - Added Nag level drop down to Virtual List tab

2009-05-01 23:49 (#556) - ObjectListView/Overlays.cs
  - Added Rotation to Overlays
  - Added SelectedColumnOverlay

2009-05-01 23:48 (#555) - ObjectListView/NativeMethods.cs
  - Added SetSelectedColumn() method

2009-05-01 23:47 (#554) - ObjectListView/GlassPanelForm.cs
  - Do our drawing with antialiased text

2009-05-01 23:47 (#553) - ObjectListView/ObjectListView.cs
  - Added Decorations (scrolling overlays)
  - Added SelectedColumn property, which puts a slight tint on that column. Combine this with TintSortColumn property and the sort column is automatically tinted.
  - Consistently use LastSortColumn and LastSortOrder properties instead of using the private fields.

2009-04-30 06:55 (#552) - ObjectListView/ObjectListView.cs
  - Use an overlay to implement "empty list" msg. Default empty list msg is now prettier.

2009-04-30 06:54 (#551) - ObjectListView/Overlays.cs
  - TextOverlay can now have round cornered BorderColor
  - Added attributes to more properties of TextOverlay

2009-04-30 06:53 (#550) - ObjectListView/GlassPanelForm.cs, ObjectListView/NativeMethods.cs
  - Added file header docs

2009-04-29 08:18 (#546) - ObjectListView/ObjectListView.cs
  - Use GlassPanelForm to show overlays when scrolling
  - Correctly refresh overlays when marque selecting
  - Fixed bug where DoubleClick events were not triggered when CheckBoxes was true

2009-04-29 08:15 (#545) - ObjectListView/Overlays.cs
  - Overlays can no longer have individual transparency
  - Moved bordering and backgrounding from BillboardOverylay to TextOverlay

2009-04-29 08:12 (#544) - ObjectListView/NativeMethods.cs
  - Added  ShowWithoutActivate() and ChangeZOrder()

2009-04-29 08:12 (#543) - ObjectListView/Events.cs
  - Renamed DropEventArgs to OlvDropEventArgs to prevent naming confusion

2009-04-29 08:11 (#542) - ObjectListView/DropSink.cs
  - Allow CanDrop event handlers to change DropTarget*

2009-04-24 05:05 (#529) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Removed show groups checkboxes from Drag and drop tab

2009-04-24 05:04 (#528) - ObjectListView/Events.cs
  - Added some documentation strings

2009-04-23 23:42 (#527) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Updated demo for v2.2

2009-04-23 23:41 (#526) - ObjectListView/ObjectListView.cs
  - Fixed various bugs under Vista.
  - Made groups collapsible - Vista only. Thanks to Crustyapplesniffer.
  - Forward events from DropSink to the control itself. This allows handlers to be defined within the IDE for drop events
  - Added ObjectListView.IsVista

2009-04-23 23:33 (#525) - ObjectListView/NativeMethods.cs
  - Added GROUP structures

2009-04-23 23:32 (#524) - ObjectListView/Events.cs
  - Added drag drop events

2009-04-23 23:32 (#523) - ObjectListView/DropSink.cs
  - Simplified RearrangingDropSink

2009-04-23 18:55 (#522) - ObjectListView/ObjectListView.cs, ObjectListView/DropSink.cs
  - Added IsSimpleDragSource and IsSimpleDropSink
  - Changed to use "Appearance - ObjectListView" category

2009-04-23 18:53 (#521) - ObjectListView/Overlays.cs, ObjectListView/Renderers.cs
  - Changed to use "Appearance - ObjectListView" category

2009-04-23 18:51 (#520) - ObjectListView/DragSource.cs
  - Renamed *DataSource to *DragSource, as it always should have been

2009-04-22 00:17 (#519) - ObjectListView/Properties/AssemblyInfo.cs
  - Updated version to 2.2a

2009-04-22 00:14 (#518) - ObjectListView/ObjectListView.cs
  - Reorganized code ready for v2.2alpha release
  - Added MoveObjects()
  - More tweaking custom draw, this time for problems for grouped views
  - Update row colors after RemoveObject()

2009-04-22 00:11 (#516) - ObjectListView/DropSink.cs
  - Added RearrangingDropSink

2009-04-22 00:10 (#515) - ObjectListView/Renderers.cs
  - Fixed off-by-1 error when calculating text widths. This caused middle and right aligned columns to always wrap one character when printed using ListViewPrinter (SF#2776634).

2009-04-22 00:10 (#514) - Demo/Resources/redback1.png, Demo/MainForm.Designer.cs, Demo/ObjectListViewDemo2008.csproj, Demo/Resource1.Designer.cs, Demo/Properties, Demo/MainForm.cs, Demo/Photos/Thumbs.db, Demo/Resources/redbull.png, Demo/MainForm.resx, Demo/Resource1.resx
  - Prepare for v2.2 alpha

2009-04-20 19:23 (#513) - Demo/Resources/limeleaf.png, Demo/MainForm.Designer.cs, Demo/ObjectListViewDemo2008.csproj, Demo/Resource1.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx, Demo/Resource1.resx
  - Changed to show new drag drop features and overlays

2009-04-20 19:23 (#512) - ListViewPrinter/ListViewPrinter.cs
  - Changed to use RowHeightEffective

2009-04-20 19:22 (#510) - ObjectListView/ObjectListView2008.csproj
  - Added Overlays.cs, DropSink.cs and DragSource.cs

2009-04-20 19:21 (#509) - ObjectListView/ObjectListView.cs
  - Implemented overlay architecture, based on CustomDraw scheme. This unified drag drop feedback, empty list msgs and overlay images.
  - Added OverlayImage and OverlayText to allow transparent images and text over the listview from within the IDE
  - Fixed long-standing annoying flicker on owner drawn virtual lists! This means, amongst other things, that grid lines no longer get confused, and drag-select no longer flickers.
  - Made several properties localizable.
  - Correctly renderer checkboxes when RowHeight is non-standard
  - Added RowHeightEffective property

2009-04-20 19:16 (#508) - ObjectListView/Renderers.cs
  - Correctly renderer checkboxes when RowHeight is non-standard

2009-04-20 19:15 (#507) - ObjectListView/NativeMethods.cs
  - Added structure and methods to put image under ListView (no longer used)
  - Added custom draw structures

2009-04-20 19:14 (#506) - ObjectListView/DragSource.cs, ObjectListView/Overlays.cs, ObjectListView/DropSink.cs
  - Initial checking

2009-04-20 18:18 (#505) - ObjectListView/TreeListView.cs
  - Fixed SF#2499313 - Calling Expand() on an already expand branch causes a confused display of the branches children

2009-04-07 08:00 (#485) - ObjectListView/DragDrop.cs
  - Initial checkin

2009-04-07 08:00 (#484) - ObjectListView/TypedObjectListView.cs
  - Added Objects property

2009-04-07 07:59 (#483) - ObjectListView/ObjectListView.cs
  - Calculate edit rectangles more accurately

2009-04-07 07:58 (#482) - ObjectListView/VirtualObjectListView.cs
  - ClearObjects() now works again

2009-04-07 07:57 (#481) - ObjectListView/TreeListView.cs
  - Calculate edit rectangle on column 0 more accurately

2009-04-07 07:56 (#480) - ObjectListView/Renderers.cs
  - Allow for item indent when calculating edit rectangle

2009-04-07 06:31 (#479) - ObjectListView/ObjectListView.cs
  - Double-clicking no longer toggles the checkbox
  - Double-clicking on a checkbox no longer confuses the checkbox

2009-03-17 01:12 (#478) - ObjectListView/ObjectListView.cs
  - Optimized the build of autocomplete lists

2009-02-27 06:31 (#474) - docs/whatsnew.rst, docs/.templates/layout.html
  - Complete v2.1 documentation



v2.1 - 26 February 2009
-----------------------

2009-02-26 04:45 (#471) - ObjectListView/ObjectListView.cs, ObjectListView/TreeListView.cs
  - Maintain focused item when rebuilding list (SF #2547060)

2009-02-25 10:01 (#470) - docs/faq.rst
  - Added class diagrams to docs

2009-02-25 09:40 (#469) - docs/features.rst, docs/ClassDiagram-VirtualList.dia, docs/ClassDiagram.dia, docs/whatsnew.rst, docs/cellEditing.rst, docs/changelog.rst, docs/gettingStarted.rst, docs/images/ClassDiagram-VirtualList.png, docs/images/ClassDiagram.png
  - Updated feature list
  - Added clas diagrams

2009-02-25 09:36 (#468) - ObjectListView/TreeListView.cs, ObjectListView/Renderers.cs
  - All TreeListView commands now work when the list is empty
  - Renderers now work properly with ListViewPrinter
  - TreeListViews can now be printed

2009-02-25 09:35 (#467) - ObjectListView/ObjectListView.cs
  - Fix bug where double-clicking VERY quickly on two different cells could give two editors
  - Removed HitTestDelegate and co since that was only ever an experiment

2009-02-25 09:33 (#466) - ObjectListView/VirtualObjectListView.cs, ObjectListView/FastObjectListView.cs
  - Removed redundant OnMouseDown() since checkbox handling is now handled in the base class

2009-02-25 09:30 (#464) - ListViewPrinter/ListViewPrinter.cs
  - Correctly use new renderer scheme :)

2009-02-24 07:07 (#461) - Tests/Program.cs, Tests/TestCheckBoxes.cs
  - Allow tests for check events for virtual lists

2009-02-24 07:07 (#460) - docs/index.rst
  - Added some more nice references

2009-02-24 07:05 (#459) - ObjectListView/ObjectListView.cs, ObjectListView/TreeListView.cs
  - Reworked checkboxes so that events are triggered for virtual lists
  - ToggleCheckObject() now handle TriStateCheckBoxes
  - Removed some commented out code

2009-02-24 05:15 (#458) - Demo/MainForm.Designer.cs, Demo/MainForm.cs
  - ItemCheck and ItemChecked events

2009-02-24 05:14 (#457) - ObjectListView/ObjectListView.cs, ObjectListView/VirtualObjectListView.cs
  - Try to get ItemCheck and ItemChecked events to work on virtual lists

2009-02-24 00:13 (#456) - ObjectListView/ObjectListView.cs
  - Added ObjectListView.ConfigureAutoComplete utility method
  - Added RowsPerPage property
  - Optimized native windows message handling

2009-02-24 00:10 (#455) - ObjectListView/Munger.cs
  - Made Munger a public class

2009-02-24 00:08 (#453) - ObjectListView/ObjectListView.cs, ObjectListView/ObjectListView2008.csproj, ObjectListView/VirtualObjectListView.cs, ObjectListView/Properties/AssemblyInfo.cs
  - Checked items with virtual lists now works again

2009-02-10 02:15 (#452) - ObjectListView/ObjectListView.cs
  - Added IsSelected()



v2.1a - 07 February 2009
------------------------

2009-02-03 09:23 (#449) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Simple tab "Lock group" now locks sort order too

2009-02-03 09:22 (#448) - docs/whatsnew.rst, docs/.templates/layout.html, docs/changelog.rst, docs/faq.rst
  - Updated fixed bug descriptions
  - Generated change log
  - Fixed links to download and discussion in template

2009-02-03 09:20 (#447) - ObjectListView/ObjectListView.cs
  - Fixed bug with AlwaysGroupByColumn where column header clicks would not resort groups.

2009-02-02 08:53 (#444) - ObjectListView/ObjectListView.cs
  - Added UseSubItemCheckBoxes to initialize checkbox images
  - OLVColumn.CheckBoxes and TriStateCheckBoxes now work.

2009-02-02 08:50 (#443) - ObjectListView/Renderers.cs
  - Use slightly changed subitem checkbox scheme
  - Tweaked CheckStateRenderer

2009-02-02 08:50 (#442) - ObjectListView/DataListView.cs
  - Use slightly changed subitem checkbox scheme

2009-02-02 08:49 (#441) - Tests/TestCheckBoxes.cs
  - Changed subitem checkbox tests for new scheme

2009-02-02 08:49 (#440) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Polish for v2.1 alpha release

2009-02-02 08:48 (#439) - docs/recipes.rst
  - Added subitem checkbox documentation

2009-02-02 08:47 (#438) - docs/.static/structure.css
  - Remove left padding on images in cookbook

2009-02-01 17:52 (#437) - ObjectListView/ObjectListView.cs
  - Changed CalculateCellBounds to correctly calculate bounds of column 0 cells

2009-02-01 17:50 (#436) - Demo/MainForm.Designer.cs, ObjectListView/DataListView.cs, ObjectListView/Renderers.cs, Demo/MainForm.resx
  - Added CheckStateRenderer
  - Added BaseRenderer.DrawImages()
  - Reorganized methods in Renderers.cs

2009-01-31 23:01 (#435) - ObjectListView/ObjectListView.cs, ObjectListView/Renderers.cs
  - Use renderer to calculate cell editor bounds
  - Correctly calculate the bounds of cell (x, 0)

2009-01-31 23:00 (#434) - Tests/TestCheckBoxes.cs
  - Added sub item checkbox test

2009-01-31 21:32 (#433) - docs/.static/ownerDraw-icon.png, docs/.static/Thumbs.db, docs/.static/structure.css, docs/ownerDraw.rst
  - new styles docs almost complete

2009-01-31 10:12 (#431) - docs/features.rst, docs/whatsnew.rst, docs/.static/structure.css, docs/.templates/layout.html, docs/faq.rst, docs/recipes.rst
  - New style docs mostly complete

2009-01-29 04:58 (#426) - docs/images/mappedimage-renderer.png, docs/.static/gettingStarted-icon.png, docs/images/orange-800x1600.png, docs/.static/orange-800x1600.png, docs/whatsnew.rst, docs/images/coffee.jpg, docs/listCtrlPrinter.rst, docs/.static/reset.css, docs/.static/listCtrlPrinter-icon.png, docs/features.rst, docs/.static/faq-icon.png, docs/images/printpreview.png, docs/images/ownerdrawn-example1.png, docs/groupListView.rst, docs/.static/global.css, docs/gettingStarted.rst, docs/images/bar-renderer.png, docs/images/limeleaf.jpg, docs/.static/recipes-icon.png, docs/.static/whatsnew-icon.png, docs/faq.rst, docs/.static/search-icon.png, docs/.static/initial.css, docs/images/flags-renderer.png, docs/images/gettingstarted-example1.png, docs/images/gettingstarted-example2.png, docs/.static/dialog.css, docs/.static/Thumbs.db, docs/images/gettingstarted-example3.png, docs/.static/structure.css, docs/.templates/layout.html, docs/images/gettingstarted-example4.png, docs/images/gettingstarted-example5.png, docs/changelog.rst, docs/images/gettingstarted-example6.png, docs/.static/groupListView-icon.png, docs/.static/cellEditing-icon.png, docs/images/fancy-screenshot.png, docs/.static/majorClasses-icon.png, docs/images, docs/.static, docs/images/tileview-example.png, docs/.templates, docs/conf.py, docs/images/redbull.jpg, docs/images/image-renderer.png, docs/index.rst, docs/images/dialog2-blue.gif, docs/images/ReportModernExample.jpg, docs/images/ModelToScreenProcess.png, docs/cellEditing.rst, docs/images/right-arrow.png, docs/majorClasses.rst, docs, docs/images/images-renderer.png, docs/recipes.rst, docs/images/dialog2-blue-800x1600.png, docs/.static/dialog2-blue-800x1600.png, docs/images/tileview-ownerdrawn.png, docs/.static/changelog-icon.png, docs/.static/icon.ico, docs/images/right-arrow.gif, docs/images/treelistview.png, docs/images/icecream3.jpg, docs/images/ObjectListView.jpg, docs/.static/index-icon.png, docs/.static/master.css, docs/images/light-blue-800x1600.png, docs/.static/light-blue-800x1600.png, docs/images/multiimage-renderer.png, docs/.static/features-icon.png, docs/images/smoothie2.jpg, docs/images/dark-blue-800x1600.png, docs/.static/dark-blue-800x1600.png
  - New style docs

2009-01-28 08:49 (#425) - Demo/MainForm.cs
  - Use ItemRenderer on complex list view

2009-01-28 08:47 (#423) - ObjectListView/TreeListView.cs
  - Changed to use new Renderer and HitTest scheme

2009-01-28 08:47 (#422) - ObjectListView/ObjectListView.cs
  - Finished HitTest portion of new renderer scheme
  - Added ObjectListView.ItemRenderer to draw whole items (rather than double dutying the renderer of column 0)
  - Handle owner drawn of non-Details views

2009-01-28 08:44 (#421) - ObjectListView/Renderers.cs
  - Finished HitTest portion of new renderer scheme
  - Updated docs on new methods
  - Reorganized properties and methods on BaseRenderer
  - Made all methods virtual

2009-01-26 08:58 (#417) - ObjectListView/ObjectListView.cs, ObjectListView/ObjectListView2008.csproj, ObjectListView/Renderers.cs
  - First take at making Renderers into Components

2009-01-25 03:39 (#416) - ObjectListView/ObjectListView.cs, ObjectListView/Renderers.cs
  - New hit test scheme

2009-01-24 19:37 (#415) - ObjectListView/ObjectListView.cs, ObjectListView/Renderers.cs
  - Change hit test processing

2009-01-24 06:04 (#414) - ObjectListView/Renderers.cs, ObjectListView/NativeMethods.cs
  - Align image and text in accord with column alignment

2009-01-23 22:27 (#413) - ObjectListView/ObjectListView.cs
  - Simple Checkboxes now work properly
  - Added TriStateCheckBoxes property to control whether the user can set the row checkbox to have the Indeterminate value
  - CheckState property is now just a wrapper around the StateImageIndex property

2009-01-23 07:53 (#412) - ObjectListView/NativeMethods.cs
  - Added GetCountPerPage()

2009-01-23 07:52 (#411) - ObjectListView/TreeListView.cs
  - Added RevealAfterExpand property. If this is true (the default) after expanding a branch, the control scrolls to reveal as much of the expanded branch as possible.

2009-01-22 08:50 (#410) - ObjectListView/Renderers.cs
  - Changed to use TextRenderer rather than native GDI routines.
  - BaseRenderer now matches the per-pixel layout of native ListView more closely

2009-01-22 08:40 (#409) - ObjectListView/NativeMethods.cs
  - Removed GDI methods that were added in last revision

2009-01-21 09:29 (#406) - ObjectListView/Renderers.cs
  - Changed draw from image list if possible. 30% faster!
  - Tweaked some spacings to look more like native ListView
  - Text highlight for non FullRowSelect is now the right color when the control doesn't have focus.
  - Commented out experimental animations. Still needs work.

2009-01-21 09:22 (#405) - ObjectListView/ObjectListView.cs
  - Commented out experimental animations. Still needs work.

2009-01-21 05:58 (#404) - ObjectListView/ObjectListView.cs
  - Changed to always draw columns when owner drawn, rather than falling back on DrawDefault. This simplified several owner drawn problems
  - Added DefaultRenderer property to help with the above
  - HotItem background color is applied to all cells even when FullRowSelect is false
  - Allow grouping by CheckedAspectName columns

2009-01-21 05:55 (#403) - ObjectListView/Renderers.cs
  - Correctly animate hot item backgrounds

2009-01-20 21:16 (#402) - Tests/Program.cs, Tests/TestColumn.cs
  - Added tests for indexed access for column values

2009-01-20 21:15 (#401) - ObjectListView/Munger.cs
  - Made the Munger capable of handling indexed access. Incidentally, this removed the ugliness that the last change introduced.

2009-01-20 09:01 (#400) - Demo/Persons.xml
  - Added Tells Jokes field

2009-01-20 09:00 (#399) - ObjectListView/Renderers.cs
  - Changed to draw text using GDI routines. Looks more like native control this way. Set UseGdiTextRendering to false to revert to previous behavior.
  - Added IsPrinting property
  - IsDrawBackground is now calculated and cannot be set

2009-01-20 08:55 (#398) - ObjectListView/NativeMethods.cs
  - Added method need to draw text using GDI routines

2009-01-20 08:54 (#397) - ListViewPrinter/ListViewPrinter.cs
  - Use IsPrinting property on BaseRenderer

2009-01-20 03:55 (#394) - ObjectListView/CellEditors.cs
  - Added special handling for enums

2009-01-20 03:53 (#393) - ObjectListView/Events.cs
  - Moved SelectionChanged event to this file

2009-01-20 03:52 (#392) - ObjectListView/Munger.cs
  - Handle target objects from a DataListView (normally DataRowViews)

2009-01-20 03:52 (#391) - ObjectListView/DataListView.cs
  - Boolean columns are now handled as checkboxes
  - Auto-generated columns would fail if the data source was reseated, even to the same data source

2009-01-20 03:51 (#390) - ObjectListView/ObjectListView.cs
  - Added HotItemStyle and UseHotItem to highlight the row under the cursor
  - Added UseCustomSelectionColors property
  - Owner draw mode now honors ForeColor and BackColor settings on the list
  - Reorganisation all hot item handling

2009-01-20 03:48 (#389) - ObjectListView/Renderers.cs
  - Removed IsHotItem

2009-01-20 03:46 (#388) - ListViewPrinter/ListViewPrinter2008.csproj, Tests/Tests2008.csproj, Demo/ObjectListViewDemo2008.csproj, ObjectListView2008.sln, ObjectListView/ObjectListView2008.csproj, ListViewPrinterDemo/ListViewPrinterDemo2008.csproj
  - Added VS 2008 projects

2009-01-17 22:10 (#387) - ObjectListView/ObjectListView.cs, Demo/MainForm.Designer.cs, ObjectListView/VirtualObjectListView.cs, ObjectListView/CellEditors.cs, Demo/MainForm.resx
  - Improving hot tracking
  - Start enum editor

2009-01-17 20:27 (#386) - ObjectListView/ObjectListView.cs, Demo/MainForm.Designer.cs, Demo/MainForm.cs, ObjectListView/Renderers.cs
  - Polishing subitem checkboxes

2009-01-17 09:04 (#385) - ObjectListView/ObjectListView.cs, Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Checkboxes on subitems. Take I complete

2009-01-16 19:21 (#381) - ObjectListView/Renderers.cs
  - Changed the vertical position of owner drawn checkboxes a little

2009-01-16 19:20 (#380) - ObjectListView/ObjectListView.cs, ObjectListView/CellEditors.cs
  - Changed to use EditorRegistry

2009-01-16 04:57 (#379) - ObjectListView/ObjectListView.cs, ObjectListView/VirtualObjectListView.cs, ObjectListView/Renderers.cs
  - First take at animated hot tracking

2009-01-16 01:14 (#378) - ObjectListView/TreeListView.cs
  - Changed TreeRenderer to work with visual styles are disabled

2009-01-11 20:56 (#377) - ObjectListView/ObjectListView.cs
  - Changed to use Equals() method rather than == to compare model objects.

2009-01-11 02:20 (#374) - ObjectListView/Properties/AssemblyInfo.cs
  - Updated to version 2.0.1

2009-01-11 02:07 (#373) - ObjectListView/ObjectListView.cs
  - Made FinishCellEditing public



v2.0.1 - 10 January 2009
------------------------

2009-01-09 08:28 (#372) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/ObjectListViewDemo.csproj
  - Handle right click on complex list to show EnsureGroupVisible() in action

2009-01-09 08:27 (#371) - ObjectListView/ObjectListView.cs
  - Added EnsureGroupVisible()

2009-01-09 08:26 (#370) - ObjectListView/NativeMethods.cs
  - Added Scroll() method

2009-01-09 03:58 (#369) - Demo/Persons.xml
  - Made one name longer to test cell wrapping

2009-01-09 03:57 (#368) - ObjectListView/ObjectListView.cs
  - Fixed long-standing "multiple columns generated" problem. Thanks to pinkjones for his help with solving this one!
  - Made all public and protected methods virtual
  - PossibleFinishCellEditing and CancelCellEditing are now public

2009-01-09 03:51 (#367) - ObjectListView/TreeListView.cs
  - Made all public and protected methods virtual
  - Changed some classes from 'internal' to 'protected' so that they can be accessed by subclasses of TreeListView.

2009-01-09 03:50 (#366) - ObjectListView/Renderers.cs
  - Made all public and protected methods virtual

2009-01-09 03:50 (#365) - ObjectListView/DataListView.cs, ObjectListView/TypedObjectListView.cs, ObjectListView/VirtualObjectListView.cs, ObjectListView/FastObjectListView.cs
  - Made all public and protected methods virtual

2008-12-29 21:17 (#364) - ObjectListView/Renderers.cs
  - Render text correctly when HideSelection is true.

2008-12-29 21:16 (#363) - ObjectListView/TreeListView.cs
  - Minor documentation change

2008-12-29 20:18 (#362) - ObjectListView/ObjectListView.cs
  - Added Description for RowHeight property

2008-12-29 20:17 (#361) - ObjectListView/Renderers.cs
  - BaseRenderer now works correctly in all Views

2008-12-24 08:10 (#360) - ObjectListView/TreeListView.cs
  - Added UseWaitCursorWhenExpanding property
  - Fixed connection line problem when there is only a single root
  - Made TreeRenderer public so that it can be subclassed

2008-12-24 08:08 (#359) - ObjectListView/Renderers.cs
  - Fixed two small bugs in BarRenderer

2008-12-23 09:41 (#358) - ObjectListView/TreeListView.cs
  - Added LinePen property to TreeRenderer to allow the connection drawing pen to be changed
  - Fixed some rendering issues where the text highlight rect was miscalculated
  - Correctly draw connections for single root object

2008-12-23 09:39 (#357) - ObjectListView/Renderers.cs
  - Fixed bug with calculating the height of a custom bar
  - Added a little more space between icon and text

2008-12-23 09:38 (#356) - Demo/MainForm.cs
  - Added comment about how to use LinePen for a TreeRenderer

2008-12-21 09:23 (#355) - ObjectListView/Comparers.cs
  - Fixed bug with group comparisons when a group key was null (SF#2445761)

2008-12-21 08:59 (#353) - ObjectListView/ObjectListView.cs
  - Fixed bug with group comparisons when a group key was null (SF#2445761)

2008-12-20 09:01 (#352) - ObjectListView/ObjectListView.cs
  - Fixed bug with space filling columns and layout events
  - Fixed RowHeight so that it only changes the row height, not the width of the images.

2008-12-20 07:14 (#351) - ListViewPrinter/BrushPenData.cs, ListViewPrinter/ListViewPrinter.cs
  - Hide all obsolete properties from the code generator
  - Correctly set the default value of colors to be Color.Empty

2008-12-11 00:17 (#346) - Demo/MainForm.Designer.cs
  - Generated code no longer includes Color.Empty, since that is the default

2008-12-11 00:17 (#345) - Demo/MainForm.cs
  - Cleaned up TreeListView initialization

2008-12-11 00:16 (#344) - ObjectListView/TreeListView.cs
  - TreeListView now works even when it doesn't have a SmallImageList

2008-12-11 00:15 (#343) - ObjectListView/ObjectListView.cs
  - Handle Backspace key. Resets the seach-by-typing state without delay
  - Made some changes to the column collection editor to try and avoid the multiple column generation problem.
  - Column collection editor now shows the aspect name as well as the column name
  - Updated some documentation

2008-12-08 06:32 (#340) - Demo/MainForm.cs
  - Simplified initialization code

2008-12-08 05:37 (#339) - ObjectListView/VirtualObjectListView.cs
  - Trigger Before/AfterSearching events

2008-12-08 05:36 (#338) - ObjectListView/TreeListView.cs
  - Search-by-typing now works

2008-12-08 05:36 (#337) - ObjectListView/ObjectListView.cs
  - Search-by-typing now works when showing groups
  - Added BeforeSearching and AfterSearching events which are triggered when the user types into the list.
  - Added secondary sort information to Before/AfterSorting events
  - Reorganized group sorting code. Now triggers Sorting events.
  - Added GetItemIndexInDisplayOrder()
  - Tweaked in the interaction of the column editor with the IDE so that we (normally) don't rely on a hack to find the owning ObjectListView
  - Changed all 'DefaultValue(typeof(Color), "Empty")' to 'DefaultValue(typeof(Color), "")' since the first does not given Color.Empty as I thought, but the second does.

2008-12-08 05:34 (#335) - ObjectListView/Events.cs
  - Added BeforeSearching and AfterSearching events



v2.0 - 30 November 2008
-----------------------

2008-11-29 18:43 (#330) - Demo/MainForm.Designer.cs, Demo/MainForm.cs
  - Simplified Simple Tab by using CheckedAspectName

2008-11-29 18:43 (#329) - Tests/TestCheckBoxes.cs
  - Added tests for CheckedAspectName

2008-11-29 18:42 (#327) - ObjectListView/ObjectListView.cs
  - Added CheckedAspectName to simplify CheckBox handling
  - In the IDE, all ObjectListView behaviours now appear in a "Behavior - ObjectListView" category,

2008-11-29 18:41 (#326) - ObjectListView/HeaderControl.cs
  - Simplified implementation

2008-11-29 18:41 (#325) - ObjectListView/Events.cs
  - In the IDE, all ObjectListView behaviours now appear in a "Behavior - ObjectListView" category,

2008-11-29 17:38 (#324) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Added code that shows tooltips and custom selection colors

2008-11-29 17:36 (#323) - Tests/Program.cs, Tests/TestColumn.cs, Tests/TestSorting.cs
  - Added tests for updating values via OLVColumn

2008-11-29 03:26 (#322) - ObjectListView/Munger.cs, ObjectListView/ObjectListView.cs, ObjectListView/ObjectListView.csproj
  - Broke Reflection mechanism into Munger class

2008-11-28 22:54 (#320) - ObjectListView/NativeMethods.cs
  - Added WINDOWPOS
  - Remove several unused methods and corrected some return types [FXCOP]

2008-11-28 22:53 (#319) - ObjectListView/HeaderControl.cs
  - Made HeaderControl disposable [FXCCOP]
  - Changed several GetXXX() methods to properties [FXCCOP]

2008-11-28 22:51 (#318) - ObjectListView/Comparers.cs
  - Removed some redundant casts
  - Added StringComparison.CurrentCultureIgnoreCase to several string comparisons

2008-11-28 22:50 (#317) - ObjectListView/ObjectListView.cs
  - Fixed long standing bug with horizontal scrollbar when shrinking the window (thanks to Bartosz Borowik)
  - Fixed some more redundant casts [FXCOP]

2008-11-28 00:56 (#315) - ObjectListView/TreeListView.cs
  - Corrected calculation of expand/collapse icon (SF#2338819)
  - Fixed ugliness with dotted lines in renderer (SF#2332889)
  - Fixed problem with custom selection colors (SF#2338805)
  - Don't autoexpand branches when they are refreshed

2008-11-28 00:53 (#314) - ObjectListView/TypedObjectListView.cs
  - Added tool tip getting properties

2008-11-27 08:19 (#313) - ObjectListView2008.sln
  - Added VS 2008 format solution

2008-11-26 08:42 (#312) - ObjectListView/ObjectListView.cs, ObjectListView/ObjectListView.csproj, ObjectListView/HeaderControl.cs, ObjectListView/NativeMethods.cs
  - Added support for cell and header tool tips
  - Delay making the HeaderControl until after the ObjectListView is completely created
  - Moved comparers to Comparers.cs

2008-11-26 08:39 (#311) - ObjectListView/Comparers.cs
  - Collected all Comparers

2008-11-26 08:39 (#310) - ObjectListView/FastObjectListView.cs
  - Moved ModelObjectComparer to Comparers.cs file

2008-11-26 01:47 (#309) - ObjectListView/ObjectListView.cs, ObjectListView/NativeMethods.cs
  - First take at custom tooltips for headers and cells

2008-11-24 05:21 (#308) - ObjectListView/ObjectListView.cs
  - Preserve selection on virtual lists when sorting

2008-11-24 05:20 (#307) - ObjectListView/VirtualObjectListView.cs
  - Maintain sort order after adding objects
  - Changed column header click handling since ObjectListView now preserves selection when sorting

2008-11-24 05:18 (#306) - ObjectListView/Properties/AssemblyInfo.cs
  - Changed version number to 2.0.x

2008-11-24 05:18 (#305) - Tests/TestSorting.cs
  - Added tests for sorting events
  - Added tests for preserving selection

2008-11-24 05:17 (#304) - ListViewPrinterDemo/Form1.Designer.cs, ListViewPrinterDemo/Form1.cs
  - Made compatible with ListViewPrinter v2.0

2008-11-24 05:17 (#303) - ListViewPrinter/ListViewPrinter.csproj, ListViewPrinter/Properties/AssemblyInfo.cs, ListViewPrinter/ListViewPrinter.cs
  - Added more compatibility methods/Properties
  - Changed version number

2008-11-22 23:00 (#301) - Demo/MainForm.Designer.cs
  - Added Refresh Selected button to treeListView tab

2008-11-22 22:59 (#300) - Tests/MainForm.Designer.cs, Tests/Program.cs, Tests/Tests.csproj, Tests/TestSorting.cs, Tests/Person.cs
  - Added sorting tests

2008-11-22 22:58 (#299) - ObjectListView/ObjectListView.cs
  - Fixed bug where enabling grouping when there was not a sort column would not produce a grouped list. Grouping column now defaults to column 0.
  - Added ability to search by sort column to ObjectListView. Unified this with ability that was already in VirtualObjectListView
  - Objects property now always returns the objects of a control, even in virtual mode
  - Made ColumnComparer public so it can be used elsewhere

2008-11-22 22:54 (#298) - ObjectListView/NativeMethods.cs
  - Added search-by-typing structures NMLVFINDITEM, LVFINDITEM

2008-11-22 22:53 (#297) - ObjectListView/Events.cs
  - Moved ColumnRightClick event to here

2008-11-22 22:53 (#296) - ObjectListView/VirtualObjectListView.cs
  - Moved  IsSearchOnSortColumn to base class
  - Unified search-by-typing with ObjectListView

2008-11-20 09:01 (#295) - ObjectListView.sln
  - Added tests project to solution

2008-11-20 09:01 (#294) - Demo/MainForm.Designer.cs, Demo/MainForm.cs, Demo/MainForm.resx
  - Cleaned up tree list view demo a little

2008-11-20 09:00 (#293) - Tests/TestTreeView.cs
  - Test that selection is preserved when expanding or collapsing

2008-11-20 08:59 (#292) - ObjectListView/ObjectListView.cs
  - Fixed bug in ChangeToFilteredColumns() where DisplayOrder was not always restored correctly

2008-11-20 08:58 (#291) - ObjectListView/VirtualObjectListView.cs
  - Fixed some caching issues
  - Check upper bound on item index when selecting objects

2008-11-20 08:56 (#290) - ObjectListView/TreeListView.cs
  - AddObjects() and RemoveObjects() now operate on the root collection
  - Expand/collapse now preserve the selection -- more or less :)
  - Overrode RefreshObjects() to rebuild the given objects and their children

2008-11-18 22:19 (#280) - ListViewPrinterDemo/ListViewPrinterDemo.csproj, , Tests/TestTreeView.cs, ListViewPrinter/BrushForm.resx, Tests/AssemblyInfo.cs, ObjectListView/TypedObjectListView.cs, ObjectListView/VirtualObjectListView.cs, ListViewPrinter/Properties, ListViewPrinterDemo/Form1.cs, ObjectListView/ObjectListView.FxCop, ObjectListView/NativeMethods.cs, ListViewPrinterDemo/Properties, ObjectListView/FastObjectListView.cs, Demo/MainForm.resx, Tests/Program.cs, ObjectListView.shfb, Tests/TestCheckBoxes.cs, ListViewPrinter/BrushForm.cs, Demo/ObjectListViewDemo.csproj, ObjectListView/TreeListView.cs, ListViewPrinter/ListViewPrinter.cs, ObjectListView/Properties, Tests/MainForm.resx, ListViewPrinter/BrushPen.DesignTime.cs, ObjectListView/CustomDictionary.xml, ListViewPrinter/BrushPenData.cs, ObjectListView/ObjectListView.cs, Demo/MainForm.Designer.cs, Demo/Resource1.Designer.cs, Demo/MainForm.cs, ObjectListView/DataListView.cs, Tests/TestColumn.cs, Tests/Tests.csproj, ObjectListView/Events.cs, ListViewPrinter/RuntimePropertiesObject.cs, ListViewPrinterDemo/Form1.Designer.cs, ListViewPrinterDemo/Persons.xml, ObjectListView/CellEditors.cs, Tests/TestBasics.cs, ObjectListView/ObjectListView.shfb, Tests/Person.cs, Tests/MainForm.Designer.cs, Tests/MainForm.cs, Demo/ColumnSelectionForm.cs, Tests/SetupTestSuite.cs, Tests/OLVTests.nunit, ListViewPrinter/ListViewPrinter.csproj, ListViewPrinterDemo/Form1.resx, ListViewPrinter/BrushForm.Designer.cs, ObjectListView/ObjectListView.csproj, ListViewPrinterDemo/Resources, ObjectListView/Renderers.cs, ListViewPrinterDemo/Program.cs, Tests/TestSelection.cs, Demo/ShellUtilities.cs
  - Changed project structure for v2.0

2008-09-17 06:08 (#188) - ObjectListViewDemo.csproj, TypedObjectListView.cs
  - Added first take at strongly typed wrapper for OLV

2008-09-17 06:07 (#187) - MainForm.cs
  - First attempt at using strongly typed wrapper on OLV

2008-09-17 06:07 (#186) - ObjectListView.cs
  - If LastSortOrder is None when adding objects, don't force a resort.
  - Catch and ignore some problems with setting TopIndex on FastObjectListViews.
  - Sort columns by display order, rather than alphabetically



v1.13 - 24 July 2008
--------------------

2008-07-24 01:29 (#183) - MainForm.Designer.cs, MainForm.cs
  - Corrected small bug in BusinessCardRenderer

2008-07-24 01:21 (#182) - ObjectListView.cs
  - Consistently use copy-on-write semantics with Add/RemoveObject methods

2008-07-11 16:35 (#181) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Added code for cell validating on complex tab

2008-07-11 16:34 (#180) - ObjectListView.cs
  - Added LastSortColumn and LastSortOrder properties
  - Made SORT_INDICATOR_UP_KEY and SORT_INDICATOR_DOWN_KEY public

2008-07-11 09:05 (#179) - ObjectListView.cs
  - Enable validation on cell editors through a CellEditValidating event.

2008-07-10 03:48 (#178) - ObjectListView.cs
  - Added HeaderControl.Handle property

2008-06-24 08:10 (#177) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Added "Lock Groups" checkbox

2008-06-24 08:08 (#176) - ObjectListView.cs
  - Broke the more generally useful CopyObjectsToClipboard() method out of CopySelectionToClipboard()

2008-06-24 06:02 (#175) - ObjectListView.cs
  - Allow check boxes on FastObjectListViews
  - Added AlwaysGroupByColumn and AlwaysGroupBySortOrder
  - Don't do our context menu processing when in design mode
  - Separate showing and building our context menu so that the building can be used externally

2008-06-08 03:43 (#174) - ObjectListView.cs, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - First take at maing checkboxes work on virtual lists
  - Added RefreshItem() to virtua list

2008-06-03 03:01 (#173) - ObjectListView.cs
  - Corrected bug when setting SelectedIndex
  - Optimized getters for DataListView

2008-05-12 07:14 (#172) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Enable custom selection colors on data list view

2008-05-12 07:10 (#171) - ObjectListView.cs
  - Allow selection foreground and background colors to be changed.



v1.12 - 10 May 2008
-------------------

2008-05-09 19:04 (#169) - ObjectListView.cs
  - v1.12 released

2008-05-09 18:17 (#168) - ObjectListView.cs
  - Made the ObjectsAsList property protected
  - Placed UpdateSpaceFillingColumnsWhenDraggingColumnDivider into Behavior category

2008-05-09 17:26 (#167) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Changed to use OptionalRender method in BusinessCardRenderer

2008-05-09 00:04 (#166) - ObjectListView.cs
  - Changed RenderWithDefault to OptionalRender
  - Reversed sense of boolean returned from OptionalRender

2008-05-08 07:54 (#165) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Added context menu to Simple list to test that it works
  - Changed BusinessCardRenderer a little

2008-05-08 07:53 (#164) - ObjectListView.cs
  - Column selection context menu now appears even when the ObjectListView has it's own context menu installed.
  - Fix bug with owner drawing of non-detaila view.

2008-05-06 08:09 (#163) - Photos/mb.png, Photos/ns.png, Photos/cp.png, Photos/sp.png, Photos/cr.png, Photos/gp.png, Photos/es.png, Photos/gab.png, Photos/jp.png, Photos/ak.png, Photos/jr.png, Photos/sj.png
  - Smaller images please

2008-05-06 07:58 (#162) - ObjectListView.cs, ObjectListViewDemo.csproj, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Non detail views can now be owner drawn. The renderer installed for primary column is given the chance to render the whole item.
  - BREAKING CHANGE: RenderDelegate now returns a bool to indicate if default rendering should be done. Previously returned void.
  - Added BusinessCardRenderer to Complex tab as an example of owner drawing in Tile view

2008-05-06 07:46 (#161) - Photos/mb.png, Photos/ns.png, Photos/cp.png, Photos/sp.png, Photos/cr.png, Photos/gp.png, Photos/es.png, Photos/gab.png, Photos/jp.png, Photos/ak.png, Photos/jr.png, Photos/sj.png, Photos
  - Photos to demonstrate BusinessCardRenderer

2008-05-05 06:08 (#160) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Added code to test AddObjects()/RemoveObjects()

2008-05-05 06:08 (#159) - ObjectListView.cs
  - Made AddObjects() and RemoveObjects() work for all flavours (or at least not crash)
  - Changed cell editing to use values directly when the values are Strings. Previously, values were always handed to the AspectToStringConverter.
  - When editing a cell, tabbing no longer tries to edit the next subitem when not in details view!
  - MappedImageRenderer can now handle a Aspects that return a collection of values. Each value will be drawn as its own image.
  - Fixed bug with clearing virtual lists that has been scrolled vertically
  - Made TopItemIndex work with virtual lists.

2008-05-05 06:06 (#158) - ListViewPrinter.cs, ShellUtilities.cs, COPYING, ColumnSelectionForm.cs
  - Made sure that all public and protected methods have at least some form of comment

2008-05-02 08:19 (#157) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Added examples of using AddObjects() and RemoveObjects()

2008-05-02 08:18 (#156) - ObjectListView.cs
  - Added AddObjects() and RemoveObjects() to allow faster mods to the list
  - Reorganised public properties. Now alphabetical.
  - Made the class ObjectListViewState internal, as it always should have been.

2008-05-01 22:16 (#155) - ObjectListView.cs
  - Added GPLv3 text

2008-05-01 21:48 (#153) - ObjectListView.cs
  - Updated documentation on CustomSorter property

2008-05-01 17:06 (#152) - ListViewPrinter.cs, ObjectListView.shfb, ObjectListView.cs, ObjectListViewDemo.csproj, MainForm.cs
  - Minor formatting and documentation changes

2008-04-30 16:56 (#151) - ObjectListView.cs, MainForm.resx
  - Preserve scroll position when building the list or changing columns.
  - Added TopItemIndex property. Due to problems with the underlying control, this property is not always reliable.

2008-04-29 06:43 (#150) - ObjectListView.cs, MainForm.resx, MainForm.Designer.cs
  - Added ColumnRightClick event.
  - Made the assembly CLS-compliant.
  - Added SelectedIndex property
  - Made all NativeMethods 64-bit correct

2008-04-13 22:21 (#149) - ListViewPrinter.cs, AssemblyInfo.cs, ObjectListView.cs
  - Made CLS compliant

2008-04-13 07:04 (#148) - ObjectListView.cs
  - Remove unwanted WriteLine's

2008-04-13 07:02 (#147) - ObjectListView.cs
  - Changed HandleHeaderRightClick() to have a columnIndex parameter, which tells which column was right-clicked



v1.11 - 11 April 2008
---------------------

2008-04-10 16:50 (#146) - ObjectListView.cs
  - Minor code improvements

2008-04-02 08:05 (#145) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Added code to test SaveState() and RestoreState()

2008-04-02 08:05 (#144) - ObjectListView.cs
  - Added SaveState() and RestoreState()
  - When cell editing, scrolling with a mouse wheel now ends the edit operation.

2008-03-27 08:43 (#142) - ObjectListView.shfb, ListViewPrinter.cs, ObjectListView.cs, ObjectListViewDemo.csproj, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Merged Mono changes back into trunk
  - Fixed a funny interaction between cell editing and space filling columns

2008-03-27 07:31 (#141) - ObjectListView.cs
  - Update some methods and docs that I missed last time about changing proportional to space filling

2008-03-26 09:15 (#139) - ObjectListView.shfb, ObjectListView.cs, ObjectListViewDemo.csproj, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Add space filling columns
  - Remove most <code></code> brackets from docs because that tag doesn't do what I thought.



v1.10 - 19 March 2008
---------------------

2008-03-17 06:35 (#137) - AssemblyInfo.cs
  - Changed version number

2008-03-17 06:34 (#136) - ObjectListView.cs
  - Made some more methods thread safe.
  - Added some methods suggested by Chris Marlowe (thanks for the suggestions Chris)
  - - ClearObjects()
  - - GetCheckedObject(), GetCheckedObjects()
  - - GetItemAt() variation that gets both the item and the column under a point

2008-03-12 19:40 (#135) - MainForm.resx, MainForm.Designer.cs
  - Before Mono migration

2008-03-12 19:39 (#134) - ObjectListView.cs
  - Added CorrectSubItemBackColors()

2008-02-03 19:30 (#132) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - v1.9.1

2008-02-03 19:30 (#131) - ObjectListView.cs
  - Fixed bug that caused owner-drawn virtual lists to use 100% CPU
  - Added FlagRenderer to help draw bitwise-OR'ed flag values
  - Fixed bug (introduced in v1.9) that made alternate row colour with groups not quite right
  - Ensure that DesignerSerializationVisibility.Hidden is set on all non-browsable properties
  - Make sure that sort indicators are shown after changing which columns are visible
  - Added FastObjectListView



v1.9.1 - 02 February 2008
-------------------------

2008-01-20 05:41 (#129) - ObjectListView.cs
  - v1.9.0.2 but released to CodeProject as v1.9

2008-01-20 05:37 (#128) - ObjectListView.cs
  - v1.9.0.1 but was released to CodeProject as v1.9

2008-01-19 20:24 (#127) - ObjectListView.cs, ObjectListViewDemo.csproj, ShellUtilities.cs, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - v1.9

2008-01-18 09:04 (#125) - ObjectListView.cs, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - First take at IncrementalUpdate()

2008-01-17 09:33 (#124) - ListViewPrinter.cs, MainForm.resx, ColumnSelectionForm.cs, MainForm.Designer.cs, MainForm.cs
  - Candidate for v1.9

2008-01-17 09:33 (#123) - ObjectListView.cs
  - Added right click on columns to choose columns
  - Added ImagesRenderer
  - Batch the adding of list items (15% faster)
  - Redraw the control EmptyListMsg changes
  - Made RefreshObject/s thread safe



v1.9 - 16 January 2008
----------------------

2007-12-14 08:57 (#121) - ColumnSelectionForm.Designer.cs, ColumnSelectionForm.cs
  - Use new check box support in ObjectListView

2007-12-14 08:57 (#120) - ObjectListView.cs
  - Support for check boxes
  - Cleanup some column hiding code

2007-12-12 08:24 (#119) - ColumnSelectionForm.resx, ColumnSelectionForm.Designer.cs, ColumnSelectionForm.cs
  - Allow user to select which columns are visible, and in which order they should be displayed

2007-12-12 08:23 (#118) - ObjectListView.cs, ObjectListViewDemo.csproj
  - Added ability to make some columns hidden
  - Made ObjectListView and OLVColumn both partial classes

2007-12-12 08:15 (#117) - MainForm.Designer.cs, MainForm.cs
  - Added column selection button

2007-12-01 04:21 (#113) - ObjectListView.cs
  - Trigger CellEditFinishing when the user cancels editing
  - Correctly calculate the background color of a cell when the listview doesn't have the focus

2007-12-01 04:19 (#112) - MainForm.Designer.cs, MainForm.cs
  - Set correct tab order on all pages



v1.8 - 30 November 2007
-----------------------

2007-11-30 06:32 (#110) - ObjectListView.cs
  - Allow renderers to wrap text (only used when printing)

2007-11-30 06:31 (#109) - ListViewPrinter.cs
  - Made list cells able to wrap
  - Handle items having less subitems than there are columns

2007-11-29 19:45 (#108) - ObjectListView.cs, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Cell editing complete
  - Handle RTL layout

2007-11-25 23:44 (#107) - MainForm.Designer.cs, MainForm.cs
  - Allow user to control the editability of the list views

2007-11-25 23:44 (#106) - ObjectListView.cs
  - Intercept Enter and Escape rather than relying on key events, since some controls (like ComboBox) don't trigger them.
  - Refactored some code and improved some comments

2007-11-24 23:21 (#102) - MainForm.cs
  - Test out cell editing events
  - Added some AspectPutters
  - Added CanTellJokes boolean field to test handling of booleans

2007-11-24 23:19 (#101) - ObjectListView.cs
  - Added SelectionChanged event
  - Added GetItem() and GetItemCount() and used everywhere to help compatibility with virtual list
  - Added GetModelObject()
  - Documented cell editing methods
  - Use AutoCompleteCellEditor as default cell editor
  - Put cell editing events into "Behavior" category

2007-11-24 23:14 (#100) - ListViewPrinter.cs
  - Fixed bug where icon was overdrawn by background

2007-11-21 18:40 (#97) - ObjectListView.cs
  - Cell editing working. Still needs docs

2007-11-21 18:38 (#96) - ListViewPrinter.cs
  - Changed to use DefaultValue(typeof(Color), "Empty")

2007-11-18 00:14 (#94) - ObjectListView.cs
  - Don't sort group items if the lastSortOrder is None

2007-11-13 22:30 (#93) - ObjectListView.cs
  - Correctly draw background of text of selected item
  - Fixed interaction between ListViewPrinter and owner-drawn mode

2007-11-13 22:27 (#91) - ListViewPrinter.cs
  - Fixed bug with page handling
  - Fixed some problem with text formatting

2007-11-11 01:16 (#89) - MainForm.cs
  - Refresh the print preview when we switch to that tab
  - Warn when trying to print the virtual list

2007-11-11 01:15 (#88) - Persons.xml
  - Added lots more people

2007-11-11 01:14 (#87) - ObjectListView.cs
  - Handle an image selector of an empty string

2007-11-11 01:14 (#86) - ListViewPrinter.cs
  - Added ability to print list header on top of each page

2007-11-09 20:41 (#82) - ObjectListView.cs
  - Pin column width to valid value when changing min or max values

2007-11-09 20:41 (#81) - ListViewPrinter.cs, MainForm.Designer.cs, MainForm.cs
  - Added support for virtual lists

2007-11-09 06:51 (#79) - MainForm.cs
  - Changed to use Pens for BlockFOrmat

2007-11-09 06:50 (#78) - ListViewPrinter.cs
  - Changed to use Pen internally
  - Lots of other cleanups

2007-11-07 23:50 (#77) - ListViewPrinter.cs, ObjectListView.cs, MainForm.Designer.cs, MainForm.cs
  - Use BlockFormat instance for cells
  - Properly filling row background
  - Corrected miscalculations with borders and text insets

2007-11-06 06:30 (#75) - ListViewPrinter.cs, ObjectListViewDemo.csproj, ShellUtilities.cs, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - v1.7 release

2007-11-05 07:15 (#73) - ListViewPrinter.cs, MainForm.Designer.cs, MainForm.cs
  - Refactored all formatting

2007-11-04 05:21 (#72) - ListViewPrinter.cs
  - First take a group printing

2007-11-03 23:18 (#71) - ListViewPrinter.cs, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - ListViewPrinter and example v1.0 complete!

2007-11-03 17:52 (#70) - ListViewPrinter.cs, ObjectListView.cs, ObjectListViewDemo.csproj, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - ListViewPrinter more or less complete

2007-11-02 06:25 (#69) - ListViewPrinter.cs
  - First basic working version

2007-11-01 04:05 (#68) - ObjectListView.cs, MainForm.resx, MainForm.Designer.cs
  - Tidy up prior to v1.6 release

2007-10-31 17:36 (#67) - ObjectListView.cs, ObjectListViewDemo.csproj, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Version 1.6b almost ready

2007-10-31 07:59 (#66) - ObjectListView.cs
  - Improved DataListView

2007-10-18 07:20 (#64) - oject/ObjectListView.html, oject/ObjectListViewDemo.zip, ObjectListViewDemo.csproj, oject/ObjectListView.zip
  - v1.6 release

2007-10-18 07:08 (#63) - ObjectListView.cs, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Get ready for 1.6 release

2007-10-07 04:27 (#62) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Give an example of a custom sorter on virtual lists
  - Optimise value getters

2007-10-07 04:18 (#61) - ObjectListView.cs
  - Optimized aspect-to-string conversion. BuildList() 15% faster.
  - Added empty implementation of RefreshObjects() to VirtualObjectListView since
  - RefreshObjects() cannot work on virtual lists.
  - Corrected bug with custom sorter in VirtualObjectListView
  - Corrected image scaling bug in DrawAlignedImage()
  - Allow item count labels on groups to be set per column



v1.6 - 30 September 2007
------------------------

2007-08-21 06:29 (#59) - ObjectListView.cs, MainForm.cs
  - Massive rework of DataListView to make it truly bindable.

2007-08-15 06:31 (#58) - ObjectListView.cs
  - Sync with changes from cmarlow

2007-08-11 19:25 (#50) - ObjectListView.cs, ObjectListViewDemo.csproj, MainForm.resx, MainForm.Designer.cs
  - Added List Empty msg capability



v1.5 - 03 August 2007
---------------------

2007-08-03 07:07 (#48) - ObjectListViewDemo.sln, ObjectListView.cs, ObjectListViewDemo.csproj, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - v1.5 Release

2007-08-03 07:06 (#47) - AnimatedGifRenderer.cs
  - Last use before being replaced

2007-07-31 22:45 (#43) - AnimatedGifRenderer.cs
  - Change to use Image rather than GifDecoder

2007-07-31 05:07 (#42) - ObjectListViewDemo.sln, ObjectListView.cs, ObjectListViewDemo.csproj, MainForm.resx, Persons.xml, MainForm.Designer.cs, MainForm.cs
  - RowHeight now works
  - AnimatedGifs work - Mark I

2007-07-28 08:10 (#41) - AnimatedGifs/constrct.gif, AnimatedGifs/enter3.gif, GifDecoder.cs, AnimatedGifs/eye~1.gif, AnimatedGifs/free1.gif, ObjectListView.cs, ObjectListViewDemo.csproj, AnimatedGifs/eye2.gif, AnimatedGifRenderer.cs, AnimatedGifs/3dlink1.gif, AnimatedGifs/floppydisk2.gif, AnimatedGifs/cd1.gif, AnimatedGifs/email1.gif, AnimatedGifs/handright.gif, AnimatedGifs/net2.gif, AnimatedGifs/clickhere1.gif, AnimatedGifs/hot1.gif, MainForm.Designer.cs, AnimatedGifs/envelope.gif, AnimatedGifs/exclame.gif, AnimatedGifs/new5.gif, AnimatedGifs/email8.gif, AnimatedGifs/cool3.gif, AnimatedGifs/laptop1.gif, AnimatedGifs/circum.gif, AnimatedGifs/handleft.gif, MainForm.resx, Persons.xml, AnimatedGifs
  - Gif animation now works reasonably well

2007-07-27 18:46 (#40) - ObjectListView.cs, ObjectListViewDemo.csproj, AnimatedGifRenderer.cs, ShellUtilities.cs, MainForm.resx, Persons.xml, MainForm.Designer.cs, MainForm.cs
  - AnimatedGifRenderer mark I working

2007-05-24 17:46 (#38) - ShellUtilities.cs
  - Changed documentation

2007-05-24 17:45 (#37) - ObjectListView.cs
  - Changed "ListViewNative" to "NativeMethods"
  - Made OLVColumn.GetImage() pay attention to ImageIndex and ImageKey properties
  - Improved some documentation

2007-05-04 07:07 (#34) - ObjectListView.cs
  - Freeze control while switching views
  - Handle a null binding source
  - Use SystemColors rather than caching FromKnownColor results

2007-05-04 07:05 (#33) - ObjectListViewDemo.csproj
  - Added ShellUtilities.cs

2007-05-04 07:05 (#32) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Added FileExplorer tab
  - Cleanup event handlers

2007-05-02 00:27 (#31) - ObjectListView.cs
  - Sort by column rather than by index (still not sure about this one!)
  - Swap columns when using tile view

2007-05-02 00:20 (#30) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Add view comboboxes and owner draw check boxes



v1.4 - 30 April 2007
--------------------

2007-04-21 18:19 (#29) - ObjectListView.cs, MainForm.resx, Persons.xml, MainForm.Designer.cs, MainForm.cs
  - Made OwnerDraw optional.
  - Added list sort indicators on columns
  - Moved all native calls to their own class

2007-04-18 07:30 (#26) - ObjectListView.cs, ObjectListViewDemo.csproj, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Owner drawing almost complete

2007-04-10 07:49 (#24) - ObjectListView.cs, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Release 1.3

2007-04-07 17:58 (#22) - ObjectListView.cs
  - First attempt to generalise DataListView
  - Added more method comments

2007-04-06 15:00 (#21) - ObjectListView.cs
  - Added DataTableListView and VirtualObjectListView
  - Added CustomSorter property
  - Massively simplified sorting strategy
  - Separated all owner-drawing code -- until complete
  - Improved comments

2007-04-06 14:56 (#20) - Persons.xml
  - Added some more people to the list

2007-04-06 14:56 (#19) - ObjectListViewDemo.sln, ObjectListViewDemo.csproj
  - v1.3 release

2007-04-06 14:55 (#18) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Changed DataSet example to use DataTableListView
  - Removed some unwanted code



Previous versions - 04 April 2007
---------------------------------

2007-01-18 00:01 (#17) - MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Added virtual list example
  - Added selection status message

2007-01-17 23:55 (#16) - ObjectListView.cs
  - Added VirtualObjectListView class
  - Big change: Owner draw list
  - Removed all Windows specific code
  - Fixed bug with Sorting variable

2007-01-07 08:13 (#12) - oject/ObjectListView.html, oject/ObjectListViewDemo.zip, ObjectListView.cs, MainForm.resx, MainForm.Designer.cs, oject/ObjectListView.zip, MainForm.cs
  - v1.2 alternate line colouring, speed improvements

2007-01-06 07:34 (#11) - ObjectListView.cs
  - Clear the sorter before rebuilding the list. 10x faster!
  - Include fields in InvokeMember() options

2006-12-20 09:14 (#10) - ObjectListView.cs
  - Changed default AlternateRowBackColor

2006-11-10 00:35 (#9) - ObjectListView.cs, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Added alternate row back colouring

2006-11-02 09:28 (#8) - ObjectListView.cs, MainForm.resx, MainForm.Designer.cs, MainForm.cs
  - Added alternate row colouring

2006-10-27 01:38 (#6) - ObjectListView.cs
  - Added object level manipulation methods
  - Shadowed Columns property

2006-10-27 01:37 (#5) - MainForm.Designer.cs, MainForm.cs
  - Use new object level manipulation methods

