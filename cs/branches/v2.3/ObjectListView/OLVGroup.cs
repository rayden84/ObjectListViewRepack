﻿/*
 * Groups - Enhancements to the normal ListViewGroup
 *
 * Author: Phillip Piper
 * Date: 22/08/2009 6:03PM
 *
 * Change log:
 * 2009-09-01   JPP  - Cleaned up code, added more docs
 *                   - Works under VS2005 again
 * 2009-08-22   JPP  - Initial version
 *
 * To do:
 *
 * Copyright (C) 2009 Phillip Piper
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
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BrightIdeasSoftware
{
    /// <summary>
    /// These values indicate what is the state of the group
    /// </summary>
    [Flags]
    public enum GroupState
    {
        LVGS_NORMAL = 0x0,
        LVGS_COLLAPSED = 0x1,
        LVGS_HIDDEN = 0x2,
        LVGS_NOHEADER = 0x4,
        LVGS_COLLAPSIBLE = 0x8,
        LVGS_FOCUSED = 0x10,
        LVGS_SELECTED = 0x20,
        LVGS_SUBSETED = 0x40,
        LVGS_SUBSETLINKFOCUSED = 0x80,
    }

    /// <summary>
    /// This mask indicates which members of a LVGROUP have valid data
    /// </summary>
    [Flags]
    public enum GroupMask
    {
        LVGF_NONE = 0,
        LVGF_HEADER = 1,
        LVGF_FOOTER = 2,
        LVGF_STATE = 4,
        LVGF_ALIGN = 8,
        LVGF_GROUPID = 0x10,
        LVGF_SUBTITLE = 0x00100,  // pszSubtitle is valid
        LVGF_TASK = 0x00200, // pszTask is valid
        LVGF_DESCRIPTIONTOP = 0x00400,  // pszDescriptionTop is valid
        LVGF_DESCRIPTIONBOTTOM = 0x00800,  // pszDescriptionBottom is valid
        LVGF_TITLEIMAGE = 0x01000,  // iTitleImage is valid
        LVGF_EXTENDEDIMAGE = 0x02000,  // iExtendedImage is valid
        LVGF_ITEMS = 0x04000,  // iFirstItem and cItems are valid
        LVGF_SUBSET = 0x08000,  // pszSubsetTitle is valid
        LVGF_SUBSETITEMS = 0x10000  // readonly, cItems holds count of items in visible subset, iFirstItem is valid
    }

    /// <summary>
    /// This mask indicates which members of a GROUPMETRICS structure are valid
    /// </summary>
    [Flags]
    public enum GroupMetricsMask
    {
        LVGMF_NONE = 0,
        LVGMF_BORDERSIZE = 1,
        LVGMF_BORDERCOLOR = 2,
        LVGMF_TEXTCOLOR = 4
    }

    /// <summary>
    /// Instances of this class enhance the capabilities of a normal ListViewGroup,
    /// enabling the functionality that was released in v6 of the common controls.
    /// </summary>
    /// <remarks>
    /// In this implementation (2009-09), this objects are essentially passive.
    /// Setting properties does not automatically change the associated group in
    /// the listview. 
    /// </remarks>
    public class OLVGroup
    {
        #region Creation

        public OLVGroup() : this("Default group header") {
        }

        public OLVGroup(string header) {
            this.Header = header;
            this.Id = OLVGroup.nextId++;
            this.TitleImage = -1;
            this.ExtendedImage = -1;
        }
        private static int nextId = 0;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the bottom description of the group
        /// </summary>
        /// <remarks>
        /// Descriptions only appear when group is centered and there is a title image
        /// </remarks>
        public string BottomDescription {
            get { return this.bottomDescription; }
            set { this.bottomDescription = value; }
        }
        private string bottomDescription;

        /// <summary>
        /// Gets or sets whether or not this group can be collapsed
        /// </summary>
        public bool Collapsible {
            get {
                return (this.State & GroupState.LVGS_COLLAPSIBLE) == GroupState.LVGS_COLLAPSIBLE;
            }
            set {
                this.StateMask ^= GroupState.LVGS_COLLAPSIBLE;
                if (value)
                    this.State ^= GroupState.LVGS_COLLAPSIBLE;
                else
                    this.State |= ~GroupState.LVGS_COLLAPSIBLE;
            }
        }

        /// <summary>
        /// Gets or sets some representation of the contents of this group
        /// </summary>
        /// <remarks>This is user defined (like Tag)</remarks>
        public IList Contents {
            get { return this.contents; }
            set { this.contents = value; }
        }
        private IList contents;

        /// <summary>
        /// Gets or sets the int or string that will select the extended image to be shown against the title
        /// </summary>
        public object ExtendedImage {
            get { return this.extendedImage; }
            set { this.extendedImage = value; }
        }
        private object extendedImage;

        /// <summary>
        /// Gets or sets the footer of the group
        /// </summary>
        public string Footer {
            get { return this.footer; }
            set { this.footer = value; }
        }
        private string footer;

        /// <summary>
        /// Gets the internal id of our associated ListViewGroup.
        /// </summary>
        public int GroupId {
            get {
                if (this.ListViewGroup == null)
                    return this.Id;

                // Use reflection to get around the access control on the ID property
                if (OLVGroup.groupIdPropInfo == null) {
                    OLVGroup.groupIdPropInfo = typeof(ListViewGroup).GetProperty("ID", 
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    System.Diagnostics.Debug.Assert(OLVGroup.groupIdPropInfo != null);
                }
                
                int? groupId = OLVGroup.groupIdPropInfo.GetValue(this.ListViewGroup, null) as int?;
                if (groupId.HasValue)
                    return groupId.Value;
                else
                    return -1;
            }
        }
        private static PropertyInfo groupIdPropInfo;

        /// <summary>
        /// Gets or sets the header of the group
        /// </summary>
        public string Header {
            get { return this.header; }
            set { this.header = value; }
        }
        private string header;

        /// <summary>
        /// Gets or sets the horizontal alignment of the group header
        /// </summary>
        public HorizontalAlignment HeaderAlignment {
            get { return this.headerAlignment; }
            set { this.headerAlignment = value; }
        }
        private HorizontalAlignment headerAlignment;

        /// <summary>
        /// Gets or sets the internally created id of the group
        /// </summary>
        public int Id {
            get { return this.id; }
            set { this.id = value; }
        }
        private int id;

        /// <summary>
        /// Gets or sets ListViewItems that are members of this group
        /// </summary>
        /// <remarks>Listener of the BeforeCreatingGroups event can populate this collection.
        /// It is only used on non-virtual lists.</remarks>
        public IList<OLVListItem> Items {
            get { return this.items; }
            set { this.items = value; }
        }
        private IList<OLVListItem> items = new List<OLVListItem>();

        /// <summary>
        /// Gets or sets the key that was used to partition objects into this group
        /// </summary>
        /// <remarks>This is user defined (like Tag)</remarks>
        public object Key {
            get { return this.key; }
            set { this.key = value; }
        }
        private object key;

        /// <summary>
        /// Gets or sets the name of the group
        /// </summary>
        /// <remarks>As of 2009-09-01, this property is not used.</remarks>
        public string Name {
            get { return this.name; }
            set { this.name = value; }
        }
        private string name;

        /// <summary>
        /// Gets or sets the text that will show that this group is subsetted
        /// </summary>
        /// <remarks>
        /// As of WinSDK v7.0, subsetting of group is officially unimplemented.
        /// We can get around this using undocumented interfaces and may do so.
        /// </remarks>
        public string SubsetTitle {
            get { return this.subsetTitle; }
            set { this.subsetTitle = value; }
        }
        private string subsetTitle;

        /// <summary>
        /// Gets or set the subtitleof the task
        /// </summary>
        public string Subtitle {
            get { return this.subtitle; }
            set { this.subtitle = value; }
        }
        private string subtitle;

        /// <summary>
        /// Gets or sets the value by which this group will be sorted.
        /// </summary>
        public IComparable SortValue {
            get { return this.sortValue; }
            set { this.sortValue = value; }
        }
        private IComparable sortValue;

        /// <summary>
        /// Gets or sets the state of the group
        /// </summary>
        public GroupState State {
            get { return this.state; }
            set { this.state = value; }
        }
        private GroupState state;

        /// <summary>
        /// Gets or sets which bits of State are valid
        /// </summary>
        public GroupState StateMask {
            get { return this.stateMask; }
            set { this.stateMask = value; }
        }
        private GroupState stateMask;

        /// <summary>
        /// Gets or sets whether this group is showing only a subset of its elements
        /// </summary>
        /// <remarks>
        /// As of WinSDK v7.0, this property officially does nothing.
        /// </remarks>
        public bool Subseted {
            get {
                return (this.State & GroupState.LVGS_SUBSETED) == GroupState.LVGS_SUBSETED;
            }
            set {
                this.StateMask ^= GroupState.LVGS_SUBSETED;
                if (value)
                    this.State ^= GroupState.LVGS_SUBSETED;
                else
                    this.State |= ~GroupState.LVGS_SUBSETED;
            }
        }

        /// <summary>
        /// Gets or sets the user-defined data attached to this group
        /// </summary>
        public object Tag {
            get { return this.tag; }
            set { this.tag = value; }
        }
        private object tag;

        /// <summary>
        /// Gets or sets the task of this group
        /// </summary>
        /// <remarks>This task is the clickable text that appears on the right margin
        /// of the group header.</remarks>
        public string Task {
            get { return this.task; }
            set { this.task = value; }
        }
        private string task;

        /// <summary>
        /// Gets or sets the int or string that will select the image to be shown against the title
        /// </summary>
        public object TitleImage {
            get { return this.titleImage; }
            set { this.titleImage = value; }
        }
        private object titleImage;

        /// <summary>
        /// Gets or sets the top description of the group
        /// </summary>
        /// <remarks>
        /// Descriptions only appear when group is centered and there is a title image
        /// </remarks>
        public string TopDescription {
            get { return this.topDescription; }
            set { this.topDescription = value; }
        }
        private string topDescription;

        /// <summary>
        /// Gets or sets the number of items that are within this group.
        /// </summary>
        /// <remarks>This should only be used for virtual groups.</remarks>
        public int VirtualItemCount {
            get { return this.virtualItemCount; }
            set { this.virtualItemCount = value; }
        }
        private int virtualItemCount;

        #endregion

        #region Protected properties

        /// <summary>
        /// Gets or sets the ListViewGroup that is shadowed by this group.
        /// </summary>
        /// <remarks>For virtual groups, this will always be null.</remarks>
        protected ListViewGroup ListViewGroup {
            get { return this.listViewGroup; }
            set { this.listViewGroup = value; }
        }
        private ListViewGroup listViewGroup;
        #endregion

        #region Calculations/Conversions

        /// <summary>
        /// Calculate the index into the group image list of the given image selector
        /// </summary>
        /// <param name="olv"></param>
        /// <param name="imageSelector"></param>
        /// <returns></returns>
        public int GetImageIndex(ObjectListView olv, object imageSelector) {
            if (imageSelector == null || olv.GroupImageList == null)
                return -1;

            if (imageSelector is Int32)
                return (int)imageSelector;

            String imageSelectorAsString = imageSelector as String;
            if (imageSelectorAsString != null)
                return olv.GroupImageList.Images.IndexOfKey(imageSelectorAsString);

            return -1;
        }

        /// <summary>
        /// Convert this object to a string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return this.Header;
        }

        #endregion

        #region Commands

        /// <summary>
        /// Insert a native group into the underlying Windows control,
        /// *without* using a ListViewGroup
        /// </summary>
        /// <param name="olv"></param>
        /// <remarks>This is used when creating virtual groups</remarks>
        public void InsertGroupNewStyle(ObjectListView olv) {
            NativeMethods.InsertGroup(olv, this.AsNativeGroup(olv, true));
            this.SetGroupSpacing(olv);
        }

        /// <summary>
        /// Insert a native group into the underlying control via a ListViewGroup
        /// </summary>
        /// <param name="olv"></param>
        public void InsertGroupOldStyle(ObjectListView olv) {
            if (this.ListViewGroup == null)
                this.ListViewGroup = new ListViewGroup();
            this.ListViewGroup.Header = this.Header;
            this.ListViewGroup.HeaderAlignment = this.HeaderAlignment;
            this.ListViewGroup.Name = this.Name;
            this.ListViewGroup.Tag = this.Tag;
            olv.Groups.Add(this.ListViewGroup);

            // Add any extra information
            NativeMethods.SetGroupInfo(olv, this.GroupId, this.AsNativeGroup(olv, false));
            this.SetGroupSpacing(olv);
        }

        /// <summary>
        /// Change the members of the group to match the current contents of Items,
        /// using a ListViewGroup
        /// </summary>
        /// <param name="olv"></param>
        public void SetItemsOldStyle(ObjectListView olv) {
            List<OLVListItem> list = this.Items as List<OLVListItem>;
            if (list == null) {
                foreach (OLVListItem item in this.Items) {
                    this.ListViewGroup.Items.Add(item);
                }
            } else {
                this.ListViewGroup.Items.AddRange(list.ToArray());
            }
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Create a native LVGROUP structure that matches this group
        /// </summary>
        internal NativeMethods.LVGROUP2 AsNativeGroup(ObjectListView olv, bool withId) {

            NativeMethods.LVGROUP2 group = new NativeMethods.LVGROUP2();
            group.cbSize = ((uint)Marshal.SizeOf(typeof(NativeMethods.LVGROUP2)));
            group.mask = (uint)(GroupMask.LVGF_HEADER ^ GroupMask.LVGF_ALIGN ^ GroupMask.LVGF_STATE);
            group.pszHeader = this.Header;
            group.uAlign = (uint)this.HeaderAlignment;
            group.stateMask = (uint)this.StateMask;
            group.state = (uint)this.State;

            if (withId) {
                group.iGroupId = this.GroupId;
                group.mask ^= (uint)GroupMask.LVGF_GROUPID;
            }

            if (!String.IsNullOrEmpty(this.Footer)) {
                group.pszFooter = this.Footer;
                group.mask ^= (uint)GroupMask.LVGF_FOOTER;
            }

            if (!String.IsNullOrEmpty(this.Subtitle)) {
                group.pszSubtitle = this.Subtitle;
                group.mask ^= (uint)GroupMask.LVGF_SUBTITLE;
            }

            if (!String.IsNullOrEmpty(this.Task)) {
                group.pszTask = this.Task;
                group.mask ^= (uint)GroupMask.LVGF_TASK;
            }

            if (!String.IsNullOrEmpty(this.TopDescription)) {
                group.pszDescriptionTop = this.TopDescription;
                group.mask ^= (uint)GroupMask.LVGF_DESCRIPTIONTOP;
            }

            if (!String.IsNullOrEmpty(this.BottomDescription)) {
                group.pszDescriptionBottom = this.BottomDescription;
                group.mask ^= (uint)GroupMask.LVGF_DESCRIPTIONBOTTOM;
            }

            int imageIndex = this.GetImageIndex(olv, this.TitleImage);
            if (imageIndex >= 0) {
                group.iTitleImage = imageIndex;
                group.mask ^= (uint)GroupMask.LVGF_TITLEIMAGE;
            }

            imageIndex = this.GetImageIndex(olv, this.ExtendedImage);
            if (imageIndex >= 0) {
                group.iExtendedImage = imageIndex;
                group.mask ^= (uint)GroupMask.LVGF_EXTENDEDIMAGE;
            }

            if (!String.IsNullOrEmpty(this.SubsetTitle)) {
                group.pszSubsetTitle = this.SubsetTitle;
                group.mask ^= (uint)GroupMask.LVGF_SUBSET;
            }

            if (this.VirtualItemCount > 0) {
                group.cItems = this.VirtualItemCount;
                group.mask ^= (uint)GroupMask.LVGF_ITEMS;
            }

            return group;
        }

        /// <summary>
        /// Modify the space between groups
        /// </summary>
        /// <param name="olv"></param>
        /// <returns></returns>
        protected int SetGroupSpacing(ObjectListView olv) {

            if (olv.SpaceBetweenGroups <= 0)
                return 0;

            NativeMethods.LVGROUPMETRICS metrics = new NativeMethods.LVGROUPMETRICS();
            metrics.cbSize = ((uint)Marshal.SizeOf(typeof(NativeMethods.LVGROUPMETRICS)));
            metrics.mask = (uint)GroupMetricsMask.LVGMF_BORDERSIZE;
            metrics.Bottom = (uint)olv.SpaceBetweenGroups;
            int x = NativeMethods.SetGroupMetrics(olv, this.GroupId, metrics);
            return x;
        }
        
        #endregion
    }
}
