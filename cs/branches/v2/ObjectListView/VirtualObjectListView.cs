/*
 * VirtualObjectListView - A virtual listview to show various aspects of a collection of objects
 *
 * Author: Phillip Piper
 * Date: 27/09/2008 9:15 AM
 *
 * Change log:
 * 2008-11-05   JPP  - Rewrote handling of check boxes
 * 2008-10-28   JPP  - Handle SetSelectedObjects(null)
 * 2008-10-02   JPP  - MAJOR CHANGE: Use IVirtualListDataSource
 * 2008-09-27   JPP  - Separated from ObjectListView.cs
 * 
 * Copyright (C) 2006-2008 Phillip Piper
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * If you wish to use this code in a closed source application, please contact phillip_piper@bigfoot.com.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BrightIdeasSoftware
{
    /// <summary>
    /// A virtual object list view operates in virtual mode, that is, it only gets model objects for
    /// a row when it is needed. This gives it the ability to handle very large numbers of rows with
    /// minimal resources.
    /// </summary>
    /// <remarks><para>A listview is not a great user interface for a large number of items. But if you've
    /// ever wanted to have a list with 10 million items, go ahead, knock yourself out.</para>
    /// <para>Virtual lists can never iterate their contents. That would defeat the whole purpose.</para>
    /// <para>Given the above, grouping is not possible on virtual lists.</para>
    /// <para>For the same reason, animate GIFs should not be used in virtual lists. Animated GIFs require some state
    /// information to be stored for each animation, but virtual lists specifically do not keep any state information.
    /// In any case, you really do not want to keep state information for 10 million animations!</para>
    /// <para>
    /// Although it isn't documented, .NET virtual lists cannot have checkboxes. This class codes around this limitation,
    /// but you must use the functions provided by ObjectListView: CheckedObjects, CheckObject(), UncheckObject() and their friends. 
    /// </para>
    /// <para>
    /// If you use the normal check box properties (CheckedItems or CheckedIndicies), they will throw an exception, since the
    /// list is in virtual mode, and .NET "knows" it can't handle checkboxes in virtual mode.
    /// The "CheckBoxes" property itself can be set once, but trying to unset it later will throw an exception.
    /// </para>
    /// <para>Due to the limits of the underlying Windows control, virtual lists do not trigger ItemCheck/ItemChecked events. 
    /// Use a CheckStatePutter instead.</para>
    /// </remarks>
    public class VirtualObjectListView : ObjectListView
    {
        /// <summary>
        /// Create a VirtualObjectListView
        /// </summary>
        public VirtualObjectListView()
            : base()
        {
            this.ShowGroups = false; // virtual lists can never show groups
            this.VirtualMode = true; // Virtual lists have to be virtual -- no prizes for guessing that :)

            this.CacheVirtualItems += new CacheVirtualItemsEventHandler(this.HandleCacheVirtualItems);
            this.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(this.HandleRetrieveVirtualItem);
            this.SearchForVirtualItem += new SearchForVirtualItemEventHandler(this.HandleSearchForVirtualItem);
            
            // At the moment, we don't need to handle this event. But we'll keep this comment to remind us about it.
            //this.VirtualItemsSelectionRangeChanged += new ListViewVirtualItemsSelectionRangeChangedEventHandler(VirtualObjectListView_VirtualItemsSelectionRangeChanged);
            
            this.DataSource = new VirtualListVersion1DataSource(this);
        }


        #region Public Properties

        /// <summary>
        /// Get or set the collection of model objects that are checked.
        /// When setting this property, any row whose model object isn't
        /// in the given collection will be unchecked. Setting to null is
        /// equivilent to unchecking all.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This property returns a simple collection. Changes made to the returned
        /// collection do NOT affect the list. This is different to the behaviour of
        /// CheckedIndicies collection.
        /// </para>
        /// <para>
        /// When getting CheckedObjects, the performance of this method is O(n) where n is the number of checked objects.
        /// When setting CheckedObjects, the performance of this method is O(n) where n is the number of checked objects plus
        /// the number of objects to be checked.
        /// </para>
        /// <para>
        /// If the ListView is not currently showing CheckBoxes, this property does nothing. It does
        /// not remember any check box settings made.
        /// </para>
        /// </remarks>
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        override public IList CheckedObjects
        {
            get {
                ArrayList objects = new ArrayList();

                if (!this.CheckBoxes)
                    return objects;

                if (this.CheckStateGetter != null)
                    return base.CheckedObjects;

                foreach (KeyValuePair<Object, CheckState> kvp in this.checkStateMap) {
                    if (kvp.Value == CheckState.Checked)
                        objects.Add(kvp.Key);
                }
                return objects;
            }
            set {
                if (!this.CheckBoxes) 
                    return;

                if (value == null)
                    value = new ArrayList();

                Object[] keys = new Object[this.checkStateMap.Count];
                this.checkStateMap.Keys.CopyTo(keys, 0);
                foreach (Object key in keys) {
                    if (value.Contains(key)) 
                        this.SetObjectCheckedness(key, CheckState.Checked);
                    else
                        this.SetObjectCheckedness(key, CheckState.Unchecked);
                }

                foreach (Object x in value)
                    this.SetObjectCheckedness(x, CheckState.Checked);
            }
        }

        /// <summary>
        /// Get/set the data source that is behind this virtual list
        /// </summary>
        /// <remarks>Setting this will cause the list to redraw.</remarks>
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IVirtualListDataSource DataSource
        {
            get {
                return this.dataSource;
            }
            set {
                this.dataSource = value;
                this.CustomSorter = delegate(OLVColumn column, SortOrder sortOrder) {
                    this.ClearCachedInfo();
                    this.dataSource.Sort(column, sortOrder);
                };
                this.UpdateVirtualListSize();
                this.Invalidate();
            }
        }
        private IVirtualListDataSource dataSource;

        /// <summary>
        /// When the user types into a list, should the values in the current sort column be searched to find a match?
        /// If this is false, the primary column will always be used regardless of the sort column.
        /// </summary>
        /// <remarks>When this is true, the behavior is like that of ITunes.</remarks>
        [Category("Behavior"),
        Description("When the user types into a list, should the values in the current sort column be searched to find a match?"),
        DefaultValue(false)]
        public bool IsSearchOnSortColumn
        {
            get { return isSearchOnSortColumn; }
            set { isSearchOnSortColumn = value; }
        }
        private bool isSearchOnSortColumn = false;

        /// <summary>
        /// This delegate is used to fetch a rowObject, given it's index within the list
        /// </summary>
        /// <remarks>Only use this property if you are not using a DataSource.</remarks>
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RowGetterDelegate RowGetter
        {
            get { return ((VirtualListVersion1DataSource)this.dataSource).RowGetter; }
            set { ((VirtualListVersion1DataSource)this.dataSource).RowGetter = value; }
        }

        #endregion

        #region OLV accessing

        /// <summary>
        /// Return the number of items in the list
        /// </summary>
        /// <returns>the number of items in the list</returns>
        override public int GetItemCount()
        {
            return this.VirtualListSize;
        }

        /// <summary>
        /// Return the model object at the given index
        /// </summary>
        /// <param name="index">Index of the model object to be returned</param>
        /// <returns>A model object</returns>
        override public object GetModelObject(int index)
        {
            if (this.DataSource != null)
                return this.DataSource.GetNthObject(index);
            else
                return null;
        }

        /// <summary>
        /// Return the OLVListItem that displays the given model object
        /// </summary>
        /// <param name="modelObject">The modelObject whose item is to be found</param>
        /// <returns>The OLVListItem that displays the model, or null</returns>
        /// <remarks>This method has O(n) performance.</remarks>
        override public OLVListItem ModelToItem(object modelObject)
        {
            if (this.DataSource == null || modelObject == null)
                return null;

            int idx = this.DataSource.GetObjectIndex(modelObject);
            if (idx >= 0)
                return this.GetItem(idx);
            else
                return null;
        }

        #endregion

        #region Object manipulation

        /// <summary>
        /// Add the given collection of model objects to this control.
        /// </summary>
        /// <param name="modelObjects">A collection of model objects</param>
        /// <remarks>
        /// <para>The added objects will appear in their correct sort position, if sorting
        /// is active. Otherwise, they will appear at the end of the list.</para>
        /// <para>No check is performed to see if any of the objects are already in the ListView.</para>
        /// <para>Null objects are silently ignored.</para>
        /// </remarks>
        override public void AddObjects(ICollection modelObjects)
        {
            if (this.DataSource == null) 
                return;

            // Give the world a chance to cancel or change the added objects
            ItemsAddingEventArgs args = new ItemsAddingEventArgs(modelObjects);
            this.OnItemsAdding(args);
            if (args.Canceled)
                return;

            this.DataSource.AddObjects(args.ObjectsToAdd);
            this.UpdateVirtualListSize();
        }


        /// <summary>
        /// Remove all items from this list
        /// </summary>
        /// <remark>This method can safely be called from background threads.</remark>
        override public void ClearObjects()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(this.ClearObjects));
            else {
                this.ClearCachedInfo();
                this.SetVirtualListSize(0);
            }
        }


        /// <summary>
        /// Update the rows that are showing the given objects
        /// </summary>
        override public void RefreshObjects(IList modelObjects)
        {
            // Without a data source, we can't do this.
            if (this.DataSource == null)
                return;

            foreach (object modelObject in modelObjects) {
                int index = this.DataSource.GetObjectIndex(modelObject);
                if (index >= 0)
                    this.RedrawItems(index, index, true);
            }
        }


        /// <summary>
        /// Remove all of the given objects from the control
        /// </summary>
        /// <param name="modelObjects">Collection of objects to be removed</param>
        /// <remarks>
        /// <para>Nulls and model objects that are not in the ListView are silently ignored.</para>
        /// <para>Due to problems in the underlying ListView, if you remove all the objects from
        /// the control using this method and the list scroll vertically when you do so,
        /// then when you subsequenially add more objects to the control,
        /// the vertical scroll bar will become confused and the control will draw one or more
        /// blank lines at the top of the list. </para>
        /// </remarks>
        override public void RemoveObjects(ICollection modelObjects)
        {
            if (this.DataSource == null) 
                return;

            // Give the world a chance to cancel or change the removed objects
            ItemsRemovingEventArgs args = new ItemsRemovingEventArgs(modelObjects);
            this.OnItemsRemoving(args);
            if (args.Canceled)
                return;

            this.DataSource.RemoveObjects(args.ObjectsToRemove);
            this.UpdateVirtualListSize();
        }


        /// <summary>
        /// Select the row that is displaying the given model object. All other rows are deselected.
        /// </summary>
        /// <param name="setFocus">Should the object be focused as well?</param>
        override public void SelectObject(object modelObject, bool setFocus)
        {
            // Without a data source, we can't do this.
            if (this.DataSource == null)
                return;

            // Check that the object is in the list (plus not all data sources can locate objects)
            int index = this.DataSource.GetObjectIndex(modelObject);
            if (index == -1)
                return;

            // If the given model is already selected, don't do anything else (prevents an flicker)
            if (this.SelectedIndices.Count == 1 && this.SelectedIndices[0] == index)
                return;

            // Finally, select the row
            this.SelectedIndices.Clear();
            this.SelectedIndices.Add(index);
            if (setFocus)
                this.SelectedItem.Focused = true;
        }


        /// <summary>
        /// Select the rows that is displaying any of the given model object. All other rows are deselected.
        /// </summary>
        /// <param name="modelObjects">A collection of model objects</param>
        /// <remarks>This method has O(n) performance where n is the number of model objects passed.
        /// Do not use this to select all the rows in the list -- use SelectAll() for that.</remarks>
        override public void SelectObjects(IList modelObjects)
        {
            // Without a data source, we can't do this.
            if (this.DataSource == null)
                return;

            this.SelectedIndices.Clear();

            if (modelObjects == null)
                return;

            foreach (object modelObject in modelObjects) {
                int index = this.DataSource.GetObjectIndex(modelObject);
                if (index >= 0)
                    this.SelectedIndices.Add(index);
            }
        }


        /// <summary>
        /// Set the collection of objects that this control will show.
        /// </summary>
        /// <param name="collection"></param>
        /// <remark>This method can safely be called from background threads.</remark>
        override public void SetObjects(IEnumerable collection)
        {
            if (this.InvokeRequired) {
                this.Invoke((MethodInvoker)delegate { this.SetObjects(collection); });
                return;
            }

            if (this.DataSource == null)
                return;

            this.BeginUpdate();
            try {            
                // Give the world a chance to cancel or change the assigned collection
                ItemsChangingEventArgs args = new ItemsChangingEventArgs(null, collection);
                this.OnItemsChanging(args);
                if (args.Canceled)
                    return;

                this.DataSource.SetObjects(args.NewObjects);
                this.UpdateVirtualListSize();
                this.Sort();
            }
            finally {
                this.EndUpdate();
            }
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Invalidate any cached information when we rebuild the list.
        /// </summary>
        public override void BuildList(bool shouldPreserveSelection)
        {
            this.ClearCachedInfo();
            this.Invalidate();
        }

        /// <summary>
        /// Clear any cached info this list may have been using
        /// </summary>
        public void ClearCachedInfo()
        {
            this.lastRetrieveVirtualItemIndex = -1;
        }

        /// <summary>
        /// Get the checkedness of an object from the model. Returning null means the
        /// model does know and the value from the control will be used.
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        protected override CheckState? GetCheckState(object modelObject)
        {
            if (this.CheckStateGetter != null)
                return base.GetCheckState(modelObject);

            CheckState state = CheckState.Unchecked;
            if (modelObject != null)
                this.checkStateMap.TryGetValue(modelObject, out state);
            return state;
        }

        /// <summary>
        /// Create a OLVListItem for given row index
        /// </summary>
        /// <param name="itemIndex">The index of the row that is needed</param>
        /// <returns>An OLVListItem</returns>
        virtual public OLVListItem MakeListViewItem(int itemIndex)
        {
            OLVListItem olvi = new OLVListItem(this.GetModelObject(itemIndex));
            this.FillInValues(olvi, olvi.RowObject);
            if (this.UseAlternatingBackColors) {
                if (this.View == View.Details && itemIndex % 2 == 1)
                    olvi.BackColor = this.AlternateRowBackColorOrDefault;
                else
                    olvi.BackColor = this.BackColor;

                this.CorrectSubItemColors(olvi);
            }

            this.SetSubItemImages(itemIndex, olvi);
            return olvi;
        }

        /// <summary>
        /// Record the change of checkstate for the given object in the model.
        /// This does not update the UI -- only the model
        /// </summary>
        /// <param name="modelObject"></param>
        /// <param name="state"></param>
        /// <returns>The check state that was recorded and that should be used to update
        /// the control.</returns>
        protected override CheckState PutCheckState(object modelObject, CheckState state)
        {
            state = base.PutCheckState(modelObject, state);
            this.checkStateMap[modelObject] = state;
            return state;
        }

        /// <summary>
        /// Prepare the listview to show alternate row backcolors
        /// </summary>
        /// <remarks>Alternate colored backrows can't be handle in the same way as our base class.
        /// With virtual lists, they are handled at RetrieveVirtualItem time.</remarks>
        protected override void PrepareAlternateBackColors()
        {
            // do nothing
        }

        /// <summary>
        /// Refresh the given item in the list
        /// </summary>
        /// <param name="olvi">The item to refresh</param>
        public override void RefreshItem(OLVListItem olvi)
        {
            this.ClearCachedInfo();
            this.RedrawItems(olvi.Index, olvi.Index, false);
        }

        /// <summary>
        /// Change the size of the list
        /// </summary>
        /// <param name="newSize"></param>
        protected void SetVirtualListSize(int newSize)
        {
            if (newSize < 0 || this.VirtualListSize == newSize)
                return;

            int oldSize = this.VirtualListSize;

            this.ClearCachedInfo();

            // There is a bug in .NET when a virtual ListView is cleared
            // (i.e. VirtuaListSize set to 0) AND it is scrolled vertically: the scroll position 
            // is wrong when the list is next populated. To avoid this, before 
            // clearing a virtual list, we make sure the list is scrolled to the top.
            // [6 weeks later] Damn this is a pain! There are cases where this can also throw exceptions!
            try {
                if (newSize == 0 && this.TopItemIndex > 0)
                    this.TopItemIndex = 0;
            }
            catch (Exception) {
                // Ignore any failures
            }

            // In strange cases, this can throw the exceptions too. The best we can do is ignore them :(
            try {
                this.VirtualListSize = newSize;
            }
            catch (ArgumentOutOfRangeException) {
                // pass
            }
            catch (NullReferenceException) {
                // pass
            }

            // Tell the world that the size of the list has changed
            this.OnItemsChanged(new ItemsChangedEventArgs(oldSize, this.VirtualListSize));
        }

        /// <summary>
        /// Take ownership of the 'objects' collection. This separates our collection from the source.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method
        /// separates the 'objects' instance variable from its source, so that any AddObject/RemoveObject
        /// calls will modify our collection and not the original colleciton.
        /// </para>
        /// <para>
        /// VirtualObjectListViews always own their collections, so this is a no-op.
        /// </para>
        /// </remarks>
        override protected void TakeOwnershipOfObjects()
        {
        }

        /// <summary>
        /// Change the size of the virtual list so that it matches its data source
        /// </summary>
        public void UpdateVirtualListSize()
        {
            if (this.DataSource != null)
                this.SetVirtualListSize(this.DataSource.GetObjectCount());
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Handle the CacheVirtualItems event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HandleCacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            if (this.DataSource != null)
                this.DataSource.PrepareCache(e.StartIndex, e.EndIndex);
        }

        /// <summary>
        /// Event handler for the column click event
        /// </summary>
        /// <remarks>
        /// <para>
        /// This differs from its base version by explicitly preserving selection.
        /// The base class (ObjectListView) stores the selection state in the ListViewItem
        /// objects, so when they are sorted, the selected-ness is automatically preserved.
        /// But a virtual list only knows which indices are selected, so the same rows are
        /// selected after sorting, even if they are showing different objects. So, we have
        /// to specifically remember which objects were selected, and then reselected them
        /// afterwards. 
        /// </para>
        /// <para>
        /// For large lists when many objects are selected, this re-selection
        /// is the slowest part of sorting the list.
        /// </para>
        /// </remarks>
        override protected void HandleColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (!this.PossibleFinishCellEditing())
                return;

            // Toggle the sorting direction on successive clicks on the same column
            if (this.LastSortColumn != null && e.Column == this.LastSortColumn.Index)
                this.LastSortOrder = (this.LastSortOrder == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending);
            else
                this.LastSortOrder = SortOrder.Ascending;

            this.BeginUpdate();
            try {
                IList previousSelection = this.SelectedObjects;
                this.Sort(e.Column);
                this.SelectedObjects = previousSelection;
            }
            finally {
                this.EndUpdate();
            }
        }

        /// <summary>
        /// Handle a RetrieveVirtualItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HandleRetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            // .NET 2.0 seems to generate a lot of these events. Before drawing *each* sub-item,
            // this event is triggered 4-8 times for the same index. So we save lots of CPU time
            // by caching the last result.
            if (this.lastRetrieveVirtualItemIndex != e.ItemIndex) {
                this.lastRetrieveVirtualItemIndex = e.ItemIndex;
                this.lastRetrieveVirtualItem = this.MakeListViewItem(e.ItemIndex);
            }
            e.Item = this.lastRetrieveVirtualItem;
        }

        /// <summary>
        /// Handle the SearchForVirtualList event, which is called when the user types into a virtual list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void HandleSearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
            // We can't do anything if we don't have a data source
            if (this.DataSource == null)
                return;

            // We also can't do anything if we don't have data
            if (this.DataSource.GetObjectCount() == 0)
                return;

            // The event has e.IsPrefixSearch, but as far as I can tell, this is always false (maybe that's different under Vista)
            // So we ignore IsPrefixSearch and IsTextSearch and always to a case insensitve prefix match
            OLVColumn column = this.GetColumn(0);
            if (this.IsSearchOnSortColumn && this.View == View.Details && this.LastSortColumn != null)
                column = this.LastSortColumn;

            // Where should we start searching? If the last row is focused, the SearchForVirtualItemEvent starts searching
            // from the next row, which is actually an invalidate index -- in that case, we rewind one row to the last row.
            int start = e.StartIndex;
            if (e.StartIndex == this.DataSource.GetObjectCount())
                start--;

            // Do two searches if necessary to find a match. The second search is the wrap-around part of searching
            int i;
            if (e.Direction == SearchDirectionHint.Down) {
                i = this.DataSource.SearchText(e.Text, start, this.DataSource.GetObjectCount() - 1, column);
                if (i == -1 && e.StartIndex > 0)
                    i = this.DataSource.SearchText(e.Text, 0, start-1, column);
            } else {
                i = this.DataSource.SearchText(e.Text, start, 0, column);
                if (i == -1 && e.StartIndex != this.DataSource.GetObjectCount())
                    i = this.DataSource.SearchText(e.Text, this.DataSource.GetObjectCount() - 1, start + 1, column);
            }
            if (i != -1)
                e.Index = i;
        }

        /// <summary>
        /// Handle a mouse down event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!this.CheckBoxes)
                return;

            // Did the user click the state icon? If so, toggle the clicked row. 
            // If the given row is selected, all selected rows are given the same checkedness.
            ListViewHitTestInfo htInfo = this.HitTest(e.Location);
            if ((htInfo.Location & ListViewHitTestLocations.StateImage) != 0) {
                OLVListItem clickedItem = (OLVListItem)htInfo.Item;
                this.ToggleCheckObject(clickedItem.RowObject);
                if (clickedItem.Selected) {
                    CheckState state = this.ModelToItem(clickedItem.RowObject).CheckState;
                    foreach (Object x in this.SelectedObjects)
                        this.SetObjectCheckedness(x, state);
                }
            }
        }

        #endregion

        #region Variable declaractions

        private Dictionary<Object, CheckState> checkStateMap = new Dictionary<object, CheckState>();
        private OLVListItem lastRetrieveVirtualItem;
        private int lastRetrieveVirtualItemIndex = -1;

        #endregion
    }

    /// <summary>
    /// A VirtualListDataSource is a complete manner to provide functionality to a virtual list.
    /// An object that implements this interface provides a VirtualObjectListView with all the
    /// information it needs to be fully functional.
    /// </summary>
    public interface IVirtualListDataSource
    {
        /// <summary>
        /// Return the object that should be displayed at the n'th row.
        /// </summary>
        /// <param name="n">The index of the row whose object is to be returned.</param>
        /// <returns>The model object at the n'th row, or null if the fetching was unsuccessful.</returns>
        Object GetNthObject(int n);

        /// <summary>
        /// Return the number of rows that should be visible in the virtual list
        /// </summary>
        /// <returns>The number of rows the list view should have.</returns>
        int GetObjectCount();

        /// <summary>
        /// Get the index of the row that is showing the given model object
        /// </summary>
        /// <param name="model">The model object sought</param>
        /// <returns>The index of the row showing the model, or -1 if the object could not be found.</returns>
        int GetObjectIndex(Object model);

        /// <summary>
        /// The ListView is about to request the given range of items. Do
        /// whatever caching seems appropriate.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        void PrepareCache(int first, int last);

        /// <summary>
        /// Find the first row that "matches" the given text in the given range.
        /// </summary>
        /// <param name="value">The text typed by the user</param>
        /// <param name="first">Start searching from this index. This may be greater than the 'to' parameter, 
        /// in which case the search should descend</param>
        /// <param name="last">Do not search beyond this index. This may be less than the 'from' parameter.</param>
        /// <param name="column">The column that should be considered when looking for a match.</param>
        /// <returns>Return the index of row that was matched, or -1 if no match was found</returns>
        int SearchText(string value, int first, int last, OLVColumn column);

        /// <summary>
        /// Sort the model objects in the data source.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="order"></param>
        void Sort(OLVColumn column, SortOrder order);

        //-----------------------------------------------------------------------------------
        // Modification commands
        // THINK: Should we split these three into a separate interface?

        /// <summary>
        /// Add the given collection of model objects to this control.
        /// </summary>
        /// <param name="modelObjects">A collection of model objects</param>
        void AddObjects(ICollection modelObjects);

        /// <summary>
        /// Remove all of the given objects from the control
        /// </summary>
        /// <param name="modelObjects">Collection of objects to be removed</param>
        void RemoveObjects(ICollection modelObjects);

        /// <summary>
        /// Set the collection of objects that this control will show.
        /// </summary>
        /// <param name="collection"></param>
        void SetObjects(IEnumerable collection);
    }

    /// <summary>
    /// A do-nothing implementation of the VirtualListDataSource interface.
    /// </summary>
    public class AbstractVirtualListDataSource : IVirtualListDataSource
    {
        public AbstractVirtualListDataSource(VirtualObjectListView listView)
        {
            this.listView = listView;
        }

        /// <summary>
        /// The list view that this data source is giving information to.
        /// </summary>
        protected VirtualObjectListView listView;

        virtual public object GetNthObject(int n)
        {
            return null;
        }

        virtual public int GetObjectCount()
        {
            return -1;
        }

        virtual public int GetObjectIndex(object model)
        {
            return -1;
        }

        virtual public void PrepareCache(int from, int to)
        {
        }

        virtual public int SearchText(string value, int first, int last, OLVColumn column)
        {
            return -1;
        }

        virtual public void Sort(OLVColumn column, SortOrder order)
        {
        }

        virtual public void AddObjects(ICollection modelObjects)
        {
        }

        virtual public void RemoveObjects(ICollection modelObjects)
        {
        }

        virtual public void SetObjects(IEnumerable collection)
        {
        }

        /// <summary>
        /// This is a useful default implementation of SearchText method, intended to be called
        /// by implementors of IVirtualListDataSource.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="column"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        static public int DefaultSearchText(string value, int first, int last, OLVColumn column, IVirtualListDataSource source)
        {
            if (first <= last) {
                for (int i = first; i <= last; i++) {
                    string data = column.GetStringValue(source.GetNthObject(i));
                    if (data.StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
                        return i;
                }
            } else {
                for (int i = first; i >= last; i--) {
                    string data = column.GetStringValue(source.GetNthObject(i));
                    if (data.StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
                        return i;
                }
            }

            return -1;
        }
    }

    /// <summary>
    /// This class mimics the behavior of VirtualObjectListView v1.x.
    /// </summary>
    public class VirtualListVersion1DataSource : AbstractVirtualListDataSource
    {
        public VirtualListVersion1DataSource(VirtualObjectListView listView) : base (listView)
        {
        }

        #region Public properties

        /// <summary>
        /// How will the n'th object of the data source be fetched?
        /// </summary>
        public RowGetterDelegate RowGetter
        {
            get { return rowGetter; }
            set { rowGetter = value; }
        }
        private RowGetterDelegate rowGetter;

        #endregion

        #region IVirtualListDataSource implementation

        override public object GetNthObject(int n)
        {
            if (this.RowGetter == null)
                return null;
            else
                return this.RowGetter(n);
        }

        public override int SearchText(string value, int first, int last, OLVColumn column)
        {
            return DefaultSearchText(value, first, last, column, this);
        }

        #endregion
    }
}
