using System;

namespace LaMa.Framework.Core.Web.HtmlControls.Bootstrap
{
    public class BootstrapTableControlSettings
    {
        public BootstrapTableControlSettings()
        {
            //default values
            IsCondensed = false;
            IsHovered = false;
            IsBordered = false;
            IsStriped = false;
            DisplayHeader = true;
            HasSearch = false;
        }

        internal string CssClass { get; set; }
        

        internal bool DisplayHeader { get; set; }
        //TODO add search
        internal bool HasSearch { get; set; }

        internal bool IsStriped { get; set; }

        internal bool IsBordered { get; set; }

        internal bool IsHovered { get; set; }

        internal bool IsCondensed { get; set; }

        public static BootstrapTableControlSettings Create()
        {
            return new BootstrapTableControlSettings();
        }
        /// <summary>
        /// include a header row with the column description
        /// Default: <c>shows header</c>
        /// </summary>
        /// <param name="value">default <c>true</c></param>
        /// <returns></returns>
        public BootstrapTableControlSettings SetDisplayHeader(bool value)
        {
            DisplayHeader = value;
            return this;
        }

        /// <summary>
        /// Set the table stripped
        /// Default: <c>Not stripped</c>
        /// </summary>
        /// <param name="value">default <c>false</c></param>
        /// <returns></returns>
        public BootstrapTableControlSettings SetStripped(bool value)
        {
            IsStriped  = value;
            return this;
        }
        /// <summary>
        /// Draws the border of the table
        /// Default: <c>Not Bordered</c>
        /// </summary>
        /// <param name="value">default <c>false</c></param>
        /// <returns></returns>
        public BootstrapTableControlSettings SetBordered(bool value)
        {
            IsBordered = value;
            return this;
        }
        /// <summary>
        /// marks the row when hoovered
        /// Default: <c>Not Hoovered</c> 
        /// </summary>
        /// <param name="value">default <c>false</c></param>
        /// <returns></returns>
        public BootstrapTableControlSettings SetHoovered(bool value)
        {
            IsHovered = value;
            return this;
        }
        /// <summary>
        /// Make the table more compact
        /// Default: <c>Not Condensed</c>
        /// </summary>
        /// <param name="value">default <c>false</c></param>
        /// <returns></returns>
        public BootstrapTableControlSettings SetCondensed(bool value)
        {
            IsCondensed = value;
            return this;
        }
         
        /// <summary>
        /// Sets the css class of the table
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public BootstrapTableControlSettings SetCssClass(string value)
        {
            CssClass = value;
            return this;
        }
        /// <summary>
        /// Appends the css class of the table
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public BootstrapTableControlSettings AppendCssClass(string value)
        {
            CssClass += value;
            return this;
        }
    }
}